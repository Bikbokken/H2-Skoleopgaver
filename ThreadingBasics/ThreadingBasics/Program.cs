using System.Threading;

/*
* C# Program to Create a Simple Thread
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
class program
{
    public void WorkThreadFunction()
    {
        for (int i = 0; i < 5; i++) // Loop 5 times
        {
            Console.WriteLine("({0}) Simple Thread", Thread.CurrentThread.Name);
        }
    }
}
class threprog
{
    public static void Main()
    {
        program pg = new program(); // Intialize the class Program
        Thread thread1 = new Thread(new ThreadStart(pg.WorkThreadFunction)); // Create a new thread that executes the method WorkThreafFunction from the intialized Program
        thread1.Name = "1. thread";
        thread1.Start(); // Start the newly created Thread
        
        Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFunction)); // Create a new thread that executes the method WorkThreafFunction from the intialized Program
        thread2.Name = "2. thread";
        thread2.Start(); // Start the newly created Thread

        Console.Read(); // Read for input keys
    }
}