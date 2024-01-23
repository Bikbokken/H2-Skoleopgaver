using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class GuiService
    {
        private void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintNewCan(Container container)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintMessage($"New container added: {container.GetType()} - ID: {container.Id} -> {container.Name}");
            ResetColor();
        }

        public void PrintSortedCan(Container container)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintMessage($"Sorted Container: {container.GetType()} - ID: {container.Id} -> {container.Name}");
            ResetColor();
        }

        public void RemoveCan(Container container)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintMessage($"Removed one container: {container.GetType()} - ID: {container.Id} -> {container.Name}");
            ResetColor();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine("[{0}] {1}", Thread.CurrentThread.Name, message);
        }
        public GuiService() { }
    }
}
