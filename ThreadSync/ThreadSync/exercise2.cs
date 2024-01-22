using System.Diagnostics.Metrics;

public class Writer
{
    static int count = 0;
    static readonly object _lock = new object();

    private void WriteChar(string c)
    {
        lock(_lock)
        {
            count += 60;
            for (int i = 0; i < 60; i++)
            {
                Console.Write(c);
            }
            Console.Write(count);
            Console.WriteLine();
        }
       
    }

    public void WriteStar()
    {
        while(true)
        {
            lock (_lock)
            {
                WriteChar("*");
            }
            Thread.Sleep(1000);
        }
        
       
    }

    public void WriteHashtag()
    {
        while(true)
        {

        lock(_lock)
        {
            WriteChar("#");
        }
            Thread.Sleep(1000);
        }

    }

}



public class Program
{
    static void Main(string[] args)
    {
        Writer writer = new Writer();

        Thread thread = new Thread(new ThreadStart(writer.WriteHashtag));
        thread.Name = "Write #";
        thread.Start();

        Thread thread2 = new Thread(new ThreadStart(writer.WriteStar));
        thread2.Name = "Write *";
        thread2.Start();
    }
}