using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class Counter
    {
        private Queue<Baggage> Bags { get; set; }
        public int Id { get; set; }
        private GuiService GuiService { get;set; }


        public void Start()
        {
            Thread produceBagThread = new Thread(() => ProduceBags());
            produceBagThread.Name = "Produce Bag - Gate Id: " + Id;
            produceBagThread.Start();
        }

        private void ProduceBags()
        {
            while (true)
            {
                lock(Bags)
                {
                    for(int i = 0; i < new Random().Next(1,4); i++)
                    {
                        int id = new Random().Next(0, 100000000);
                        Bags.Enqueue(new Baggage(id, Id));
                        GuiService.BlueMessage($"Created new baggage: {id} - Gate: {Id}");
                        Monitor.Pulse(Bags);
                    }
                   
                }
                Thread.Sleep(500);
            }
        }

        public Counter(int _id, Queue<Baggage> bags, GuiService guiService) {
            GuiService = guiService;
            Bags = bags;
            Id = _id;
        }
    }
}
