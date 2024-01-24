using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSystem
{
    internal class Counter
    {
        private Queue<Baggage> baggages { get; set; }   


        public void StartCounter()
        {
            
        }

        private void ProduceBags(int terminal)
        {
            while (true)
            {
                lock(baggages)
                {
                    baggages.Enqueue(new Baggage(new Random().Next(0,100000000), terminal));
                }
            }
        }

        public Counter(Queue<Baggage> bags) {
            baggages = bags;
        }
    }
}
