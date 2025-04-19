namespace MultiThreadingExamples
{
    internal class Program
    {

        static async Task<decimal> calcualte(decimal a, decimal b)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));
            Console.WriteLine($"Sum is running in a thread{Environment.CurrentManagedThreadId}");

            return a + b;
        }
        static async Task Main(string[] args)
        {
            await calcualte(5, 6);

        }
    }
}
