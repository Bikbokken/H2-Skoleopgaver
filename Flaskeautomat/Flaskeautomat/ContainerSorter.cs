using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class ContainerSorter
    {
        public Queue<Container> unSortedContainers { get; set; }
        public Queue<Can> sortedCans { get; set; }
        public Queue<Bottle> sortedBottle { get; set; }

        private GuiService _guiService { get; set; }


        public void Start()
        {
            Thread thread = new Thread(Sorter);
            thread.Name = "Sorter";
            thread.Start();
        }

        private void Sorter()
        {
            while(true)
            {
                lock(unSortedContainers)
                {
                    while (unSortedContainers.Count > 0)
                    {
                        Container container = unSortedContainers.Dequeue();

                        if (container.GetType() == typeof(Can))
                        {
                            lock (sortedCans)
                            {
                                _guiService.PrintSortedCan(container);
                                sortedCans.Enqueue((Can)container);
                            }
                        }
                        else if (container.GetType() == typeof(Bottle))
                        {
                            lock (sortedBottle)
                            {
                                _guiService.PrintSortedCan(container);
                                sortedBottle.Enqueue((Bottle)container);
                            }
                        }
                    }
                }
            }

        }

        public ContainerSorter(Queue<Container> containers, Queue<Can> cans, Queue<Bottle> bottles, GuiService guiService) {
            unSortedContainers = containers;
            sortedCans = cans;
            sortedBottle = bottles;
            _guiService = guiService;
        }
    }
}
