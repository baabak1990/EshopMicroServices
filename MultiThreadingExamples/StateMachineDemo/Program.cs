using System.Runtime.CompilerServices;

namespace StateMachineDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static async void FoodAsync()
        {

        }

        static void Food()
        {
            
        }

        struct FoodAsyncStateMachine : IAsyncStateMachine
        { 
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
