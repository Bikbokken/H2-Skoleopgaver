using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class Bagsystem
    {
        public Queue<Baggage> Bags { get; set; }
        public Queue<Baggage> LostBags { get; set; }
        public GuiService GuiService { get; set; }


        public void Start()
        {
            Thread thread = new Thread(PrintStatus);
            thread.Name = "Status Printer";
            thread.Start();
        }

        public void PrintStatus()
        {
            while (true)
            {
                lock (Bags)
                {
                    lock(LostBags)
                    {
                        GuiService.PrintMessage($"Current bags in queue to sort: {Bags.Count} - Lost bags: {LostBags.Count}");
                    }
                }
                Thread.Sleep(5000);
            }
        }


        public Bagsystem(GuiService guiService) {
            Bags = new Queue<Baggage>();
            GuiService = guiService;
            LostBags = new Queue<Baggage>();
        }
    }
}
