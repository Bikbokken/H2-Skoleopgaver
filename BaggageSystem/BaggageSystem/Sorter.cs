using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class Sorter
    {
        public Queue<Baggage> Bags { get;set; }
        public List<Gate> Gates { get;set; }   
        public Queue<Baggage> LostBags { get; set; }
        
        private GuiService GuiService { get; set; }
        
        
        public void Start()
        {
            Thread thread = new Thread(RunSorter);
            thread.Name = "Bag Sorter";
            thread.Start();
        }


        private void RunSorter()
        {
            while(true)
            {
                lock(Bags)
                {
                    while (Bags.Count < 1)
                    {
                        Monitor.Wait(Bags);
                    }

                    Baggage bag = Bags.Dequeue();
                    Gate gate = Gates.Find((gate) => gate.Id == bag.TerminalID);
                    bag.SortedTime = DateTime.Now;
                    if(gate != null)
                    {
                        gate.Bags.Enqueue(bag);
                        bag.ArrivedAtGate = DateTime.Now;
                        GuiService.YellowMessage($"Bag: {bag.Id} - Sorted to Gate: {bag.TerminalID}");
                    } else
                    {
                        LostBags.Enqueue(bag);
                        GuiService.ErrorMessage($"Gate: {bag.TerminalID} not found! Disposing to Lost Bags");
                    }
                  
                }
                Thread.Sleep(1);
            }
        }

        public Sorter(GuiService guiService, Queue<Baggage> bags, List<Gate> gates, Queue<Baggage> lostBags) {
            GuiService = guiService; 
            Bags = bags;
            Gates = gates;
            LostBags = lostBags;
        }
    }
}
