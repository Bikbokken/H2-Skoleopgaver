using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomat
{
    internal class MachineController
    {
        private MachineProducer _machineProducer;
        private Machine _machine;
        private ContainerSorter _containerSorter;
        private CanDestroyer _canDestroyer;
        private GuiService _guiService;

        public void Start()
        {

            _machineProducer.Start();
            _containerSorter.Start();
            _canDestroyer.Start();

        }

        public MachineController()
        {
            _machine = new Machine();
            _guiService = new GuiService();
            _machineProducer = new MachineProducer(_machine.unSortedContainers, _guiService);
            _containerSorter = new ContainerSorter(_machine.unSortedContainers, _machine.sortedCans, _machine.sortedBottle, _guiService);
            _canDestroyer = new CanDestroyer(_machine.sortedBottle, _machine.sortedCans, _guiService);

        }
    }
}
