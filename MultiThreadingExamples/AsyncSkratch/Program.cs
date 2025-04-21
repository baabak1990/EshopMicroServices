namespace AsyncSkratch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Note : you can see these are running under different Thread 
            Console.WriteLine("This is First Thread ID :"+Thread.CurrentThread.ManagedThreadId);

            DomeTrainTask.Run(() => Console.WriteLine("This is Second Thread ID :"+Thread.CurrentThread.ManagedThreadId)).Wait();
            Console.WriteLine("This is Third 3th ID :" + Thread.CurrentThread.ManagedThreadId);
            DomeTrainTask.Run(() => Console.WriteLine("This is 4th Thread ID :" + Thread.CurrentThread.ManagedThreadId)).Wait();
        
                 

            //Console.ReadLine();
        }
    }
}
