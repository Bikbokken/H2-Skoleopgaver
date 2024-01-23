using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class MachineProducer
    {
        public Queue<Container> unSortedContainers { get; set; }
        private GuiService _guiService { get; set; }


        private int _wait = 1000;

        static int producedCans = 0;

        public void Start()
        {
            Thread produceUnsortedCans = new Thread(ProduceContainers);
            produceUnsortedCans.Name = "Produce Unsorted Cans";
            produceUnsortedCans.Start();
        }


        private void ProduceContainers()
        {
            Random random = new Random();

            while (true)
            {
                Container newContainer;
                producedCans++;
                if (random.Next(2) == 0)
                {
                    newContainer = new Can(name: "Coca Cola", id:producedCans);
                    _guiService.PrintNewCan(newContainer);
                }
                else
                {
                    newContainer = new Bottle(name: "Carlsberg", id:producedCans);
                    _guiService.PrintNewCan(newContainer);
                }

                lock (unSortedContainers)
                {
                    unSortedContainers.Enqueue(newContainer);
                }

                Thread.Sleep(_wait);
            }
        }

        public MachineProducer(Queue<Container> unSortedcontainers, GuiService guiService)
        {
            unSortedContainers = unSortedcontainers;
            _guiService = guiService;
        }
    }
}
