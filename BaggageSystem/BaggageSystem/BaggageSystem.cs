using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSystem
{
    internal class BaggageSystem
    {
        public Queue<Baggage> baggages { get; set; }


        public BaggageSystem() {
            baggages = new Queue<Baggage>(); 
        }
    }
}
