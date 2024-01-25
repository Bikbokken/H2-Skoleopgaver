using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class GuiService
    {
        private void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintMessage(message);
            ResetColor();
        }

        public void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintMessage(message);
            ResetColor();
        }

        public void YellowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintMessage(message);
            ResetColor();
        }

        public void BlueMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintMessage(message);
            ResetColor();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine("[{0}] {1}", Thread.CurrentThread.Name, message);
        }
        public GuiService() { }
    }
}
