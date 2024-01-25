using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagsystem
{
    internal class BaggageManager
    {
        private Bagsystem Bagsystem { get; set; }
        private List<Counter> Counters { get; set; }
        private GuiService GuiService { get; set; }
        private List<Gate> Gates { get; set; }  
        private Sorter BagSorter { get; set; }

        public void Start()
        {
            BagSorter.Start();
            Bagsystem.Start();
        }
        
        public void StartCounter(int id)
        {
            if(Counters.FindAll((counter) => counter.Id == id).Any())
            {
                GuiService.ErrorMessage($"Counter: {id} already present. Cannot create.");
                return;
            }

            Counter counter = new(id, Bagsystem.Bags, GuiService);
            counter.Start();
            Counters.Add(counter);
        }

        public void StartGate(int id)
        {
            if(Gates.FindAll((gate) => gate.Id == id).Any())
            {
                GuiService.ErrorMessage($"Gate: {id} already present. Cannot create.");
                return;
            }

            Gate gate = new(id, GuiService);
            gate.Start();
            Gates.Add(gate);
        }

        public BaggageManager() {
            GuiService = new GuiService();
            Bagsystem = new Bagsystem(GuiService);
            Counters = new List<Counter>();
            Gates = new List<Gate>();
            BagSorter = new Sorter(GuiService, Bagsystem.Bags, Gates, Bagsystem.LostBags);
        }
    }
}
