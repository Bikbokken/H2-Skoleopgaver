using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;



class Temperature
{

    private int alarms;

    private static int GetRandomTemperature()
    {
        Random rnd = new Random();
        return rnd.Next(-20, 120);
    }

    private static bool BetweenRanges(int a, int b, int number)
    {
        return (a <= number && number <= b);
    }

    public void CheckTemp()
    {
        while(alarms < 3) // If thers is less than 3 alarms
        {
            int temperature = GetRandomTemperature(); // Get rnadom temperature
            Console.WriteLine("Temperatur: ({0}) - Nuværende alarmer: ({1})", temperature, alarms);
            if (!BetweenRanges(0, 100, temperature)) // Check if the tempeature is NOT between 0 an d100
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALARM TEMPERATUR FOR HØJ ELLER FOR LAV");
                Console.ForegroundColor = ConsoleColor.Gray;
                alarms++;
            }
        }
    }

    public Temperature()
    {
        alarms = 0;
    }
}


class Program
{
    public static void Main()
    {
        Temperature temp = new Temperature();
        Thread thread = new Thread(new ThreadStart(temp.CheckTemp));
        thread.Name = "Temperature Checker";
        thread.Start();

        while (thread.IsAlive)
        {
            return; 
        }
        
        Console.Read();
    }
}