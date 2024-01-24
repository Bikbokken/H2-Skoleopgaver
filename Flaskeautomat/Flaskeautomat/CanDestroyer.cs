using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class CanDestroyer
    {
        public Queue<Can> sortedCans { get; set; }
        public Queue<Bottle> sortedBottles { get; set; }

        private GuiService _guiService { get; set; }


        public void Start()
        {
            Thread bottleDestroyer = new Thread(DestoryBottles);
            bottleDestroyer.Name = "Bottle Destroyer";
            bottleDestroyer.Start();

            Thread canDestroyer = new Thread(DestoryCans);
            canDestroyer.Name = "Can Destroyer";
            canDestroyer.Start();

        }


        private void DestoryBottles()
        {
            while(true)
            {
                lock (sortedBottles)
                {
                    while (sortedBottles.Count < 10)
                    {
                        Monitor.Wait(sortedBottles);
                    }
                    Container container = sortedBottles.Dequeue();
                    _guiService.RemoveCan(container);

                    Monitor.Pulse(sortedBottles);
                }

            }
        }

        private void DestoryCans()
        {
            while (true)
            {
                lock (sortedCans)
                {
                    while (sortedCans.Count < 10)
                    {
                        Monitor.Wait(sortedCans);
                    }

                    Container container = sortedCans.Dequeue();
                    _guiService.RemoveCan(container);
                    Monitor.Pulse(sortedCans);
                }

            }
        }



        public CanDestroyer(Queue<Bottle> bottles, Queue<Can> cans, GuiService guiService)
        {
            sortedBottles = bottles;
            sortedCans = cans;
            _guiService = guiService;
        }
    }
}
