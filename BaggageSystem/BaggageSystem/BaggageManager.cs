using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSystem
{
    internal class BaggageManager
    {
        private BaggageSystem BaggageSystem { get; set; }
        public void Start()
        {
            Console.WriteLine("test");
        }
        public BaggageManager() {
            BaggageSystem = new BaggageSystem();
        }
    }
}
