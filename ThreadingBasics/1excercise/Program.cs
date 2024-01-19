using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
class Writer
{
    string msg;
    public void Write()
    {
        for (int i = 0; i < 5; i++) // Loop 5 times
        {
            Console.WriteLine(msg);
            Thread.Sleep(1000);
        }
    }

    public Writer(string text)
    {
        msg = text;
    }
}
class Program
{
    public static void Main()
    {
        Writer wr = new Writer("C#-tråding er nemt"); 
        Thread thread1 = new Thread(new ThreadStart(wr.Write)); 
        thread1.Name = "Writer 1 thread";
        thread1.Start();

        Writer wr2 = new Writer("Også med flere tråde...");
        Thread thread2 = new Thread(new ThreadStart(wr2.Write));
        thread2.Name = "Writer 2 thread";
        thread2.Start();


        Console.Read();
    }
}