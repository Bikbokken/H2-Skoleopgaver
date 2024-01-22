public class Program
{
    static int sum = 0;
    static void AddOne()
    {
        Interlocked.Increment(ref sum);
    }

    static void Main()
    {
        Thread[] threads = new Thread[1000];

        for (int n = 0; n < threads.Length; n++)
        {
            threads[n] = new Thread(AddOne);
            threads[n].Start();
        }

        for (int n = 0; n < threads.Length ; n++)
        {
            threads[n].Join();  
        }

        Console.WriteLine(sum);
    }
}