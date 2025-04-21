namespace AsyncSkratch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Note : you can see these are running under different Thread 
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            DomeTrainTask.Run(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));

            Console.ReadLine();
        }
    }
}
