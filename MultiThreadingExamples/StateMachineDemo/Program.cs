using System.Runtime.CompilerServices;

namespace StateMachineDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static async void FooAsync()
        {

        }
         
        static void Foo()
        {
            var stateMachine = new FooAsyncStateMachine();
            stateMachine.MethodBuilder = new AsyncVoidMethodBuilder();
        }

        struct FooAsyncStateMachine : IAsyncStateMachine
        {
            public AsyncVoidMethodBuilder MethodBuilder;
            public void MoveNext()
            {
                throw new NotImplementedException();
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                throw new NotImplementedException();
            }
        }

    }


}
