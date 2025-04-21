using System;
using System.Collections.Generic;
using System.Linq;
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
        private ExecutionContext? _context;

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

        public void SetResult() => CompleteTask(null);
        public void SetException(Exception exception) => CompleteTask(exception);
        private void CompleteTask(Exception? exception)
        {
            lock (_lock)
            {
                if (_completed)
                    throw new InvalidOperationException("DomeTrainTask already completed .Cannot set result for it");

            }

        }
    }
}
