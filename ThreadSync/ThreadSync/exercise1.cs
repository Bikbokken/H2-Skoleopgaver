
public class Counter
{
    static int counter = 0;
    static readonly object _lock = new object();

    public void CountUp()
    {
        while(true)
        {

            lock(_lock)
            {
                counter += 2;
            }
            Console.WriteLine("({0}) Counting up - ({1})", Thread.CurrentThread.Name, counter);
            Thread.Sleep(1000);

        }


    }
    public void CountDown()
    {
        while(true)
        {

        lock(_lock)
        {
            counter--;
        }
        Console.WriteLine("({0}) Counting down - ({1})", Thread.CurrentThread.Name, counter);
            Thread.Sleep(1000);
        }

    }
}

public class Program
{
    static void Main(string[] args)
    {

        Counter counter = new Counter();

        Thread thread = new Thread(new ThreadStart(counter.CountUp));
        thread.Name = "Counter Up";
        thread.Start();

        Thread thread2 = new Thread(new ThreadStart(counter.CountDown));
        thread2.Name = "Counter Down";
        thread2.Start();
    }
}