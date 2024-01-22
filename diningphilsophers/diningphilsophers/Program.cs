using System;
using System.Threading;

public class Fork
{
    public string Name { get; set; }
    public Fork(string name) {
        Name = name;
    }
}


public enum PhilospherState
{
    Waiting,
    Eating,
    Thinking
}


public class Philsopher
{
    public string Name { get; set; }
    public Fork LeftFork { get; set; }
    public Fork RightFork { get; set; }

    private int randomThinkingTime = new Random().Next(1000,3000);
    private int consoleColor = new Random().Next(0, 15);
    
    public PhilospherState State { get; set; }  

    private void PrintMessage(string message)
    {
        Console.ForegroundColor = (ConsoleColor)(consoleColor);
        Console.WriteLine("({0}) -> {1}", Thread.CurrentThread.Name, message);
    } 


    private void Think()
    {
        PrintMessage("Thinking...");
        Thread.Sleep(randomThinkingTime);
        State = PhilospherState.Waiting;
    }

    private void TryEat()
    {

        if(Monitor.TryEnter(LeftFork))
        {
            try
            {
                PrintMessage("Got Left fork - trying to get right fork!");
                // Yes, i can take at least one fork
                if (Monitor.TryEnter(RightFork))
                {
                    try
                    {
                        // Yay, i can take both forks!
                        State = PhilospherState.Eating;
                        PrintMessage("Got both forks - Yum yum!");
                        Thread.Sleep(1000); // Eating in one second
                    } finally
                    {
                        Monitor.Exit(RightFork);
                    }
                  
                }
            } finally
            {
                Monitor.Exit(LeftFork);
            }
           
        }
        State = PhilospherState.Thinking;
    }


    private void Run()
    {
        while(true)
        {
            switch(State)
            {
                case PhilospherState.Waiting:
                    PrintMessage("Waiting...");
                    TryEat();
                    break;
                case PhilospherState.Thinking:
                    Think();
                    break;
                case PhilospherState.Eating:
                    PrintMessage("Eating...");
                    break;
                default:
                    break;
            }
        }
    }

    public void Start()
    {
        Thread thread = new Thread(new ThreadStart(Run));
        thread.Name = "Philosphers - " + Name;
        thread.Start();
    }



    public Philsopher(string name, Fork leftFork, Fork rightFork) {
        Name = name;
        LeftFork = leftFork;
        RightFork = rightFork;
        State = PhilospherState.Thinking;
    }
}


public class Program
{
    static void Main(string[] args)
    {

        // Create forks
        Fork fork1 = new Fork("Fork - 1");
        Fork fork2 = new Fork("Fork - 2");
        Fork fork3 = new Fork("Fork - 3");

        // Create Philsopbhers

        Philsopher philsopher1 = new Philsopher("Philsopher - Benjamin", fork1, fork3);
        Philsopher philsopher2 = new Philsopher("Philsopher - Tobias", fork1, fork2);
        Philsopher philsopher3 = new Philsopher("Philsopher - Rasmus", fork3, fork2);


        philsopher1.Start();
        philsopher2.Start();
        philsopher3.Start();

    }
}