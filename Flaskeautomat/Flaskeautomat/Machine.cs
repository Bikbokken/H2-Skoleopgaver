using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class Machine
    {
        public Queue<Container> unSortedContainers { get; set; }
        public Queue<Can> sortedCans { get; set; }
        public Queue<Bottle> sortedBottle { get; set; }

        public Machine()
        {
            unSortedContainers = new Queue<Container>();
            sortedCans = new Queue<Can>();
            sortedBottle = new Queue<Bottle>();
        }
    }
}
