using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSkratch
{
    public class DomeTrainTask
    {
        private readonly Lock _lock = new(); //Lock class ensure  that to different thread don`t make any changes in this class
        private bool _completed;
        private Exception _exception;
        private Action? _action;
        private ExecutionContext? _context; // in short is all the security information or crucial information to give to thread 

        public bool IsCompleted
        {
            get
            {
                lock (_lock)
                {
                    return _completed;
                }
            }
        }


        public static DomeTrainTask Run(Action action)
        {
            DomeTrainTask task = new();
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    action();
                    task.SetResult();
                }
                catch (Exception e)
                {
                    task.SetException(e);
                }
            });
            return task;
        }

        public DomeTrainTask Continue(Action action)
        {
            DomeTrainTask task = new();
            lock (_lock)
            {
                if (_completed)
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        try
                        {
                            action();
                            task.SetResult();

                        }
                        catch (Exception e)
                        {
                            task.SetException(e);
                        }
                    });
                }
                else
                {
                    _action = action;
                    _context = ExecutionContext.Capture();
                }
            }

            return task;
        }

        public void Wait()
        {
            ManualResetEventSlim resetEventSlim = null;
            lock (_lock)
            {
                if (!_completed)
                {
                    resetEventSlim=new ManualResetEventSlim();
                    Continue(() => resetEventSlim.Set());
                }

            }

            resetEventSlim?.Wait();

            if(_exception is not  null)
                ExceptionDispatchInfo.Throw(_exception);
        }

        public void SetResult() => CompleteTask(null);
        public void SetException(Exception exception) => CompleteTask(exception);
        private void CompleteTask(Exception? exception)
        {
            lock (_lock)
            {
                if (_completed)
                    throw new InvalidOperationException("DomeTrainTask already completed .Cannot set result for it");


                _completed=true;
                _exception = exception;

                if (_action is not null)
                {
                    if (_context is null)
                    {
                        _action.Invoke();
                    }
                    else
                    {
                        ExecutionContext.Run(_context,state=>((Action)state)?.Invoke(),_action);
                    }
                }
            }

        }
    }
}
