using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class Gate
    {
        public int Id { get; set; }
        public Queue<Baggage> Bags { get; set; }
        public GuiService GuiService { get; set; }

        public void Start()
        {
            Thread pruner = new Thread(PruneBags);
            pruner.Name = "Gate: " + Id;
            pruner.Start();

            Thread status = new Thread(Status);
            status.Name = "Gate: " + Id;
            status.Start();
        }

        private void Status()
        {
            while (true)
            {
                lock(Bags)
                {
                    GuiService.PrintMessage($"Current bags: {Bags.Count}");
                }
                Thread.Sleep(5000);
            }
        }

        private void PruneBags()
        {
            while (true)
            {
                lock(Bags)
                {
                    while(Bags.Count < 0)
                    {
                        Monitor.Wait(Bags);
                    }
                    DateTime now = DateTime.Now;
                    GuiService.GreenMessage($"Bags flying away: {Bags.Count} - Next flight: {now.AddSeconds(30)}");
                    Bags.Clear();
                    Monitor.Pulse(Bags);
                }
                Thread.Sleep(30000);
            }
        }

        public Gate(int id, GuiService guiService) {
            Id = id;
            Bags = new Queue<Baggage>();
            GuiService= guiService;
        }
    }
}
