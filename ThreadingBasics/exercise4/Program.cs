using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Keyboard
{
    private string _key;

    public void HandleKeyInput()
    {
        while(true)
        {
            _key = Console.ReadKey().KeyChar.ToString();
        }
    }

    public void PrintKey()
    {
        while (true)
        {
            Console.Write(_key);
        }
    }

    public Keyboard()
    {
        _key = "*";
    }
    
}

class Program
{
    public static void Main()
    {
        Keyboard keyboard = new Keyboard();
        Thread reader = new Thread(new ThreadStart(keyboard.HandleKeyInput));
        reader.Start();

        Thread printer = new Thread(new ThreadStart(keyboard.PrintKey));
        printer.Start();    
    }
}