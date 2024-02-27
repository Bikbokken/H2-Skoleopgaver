using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDForklaring
{
    public class Benjamin
    {
        // Alt og alle må vide mit navn
        public string Name { get; set; }

        // Ingen udover mig selv må vide mit CPR nummer
        private string CPRNumber { get; set; }

        // Alle nærmeste (nedarvet) personer og mig selv må vide mit antal af damer - alle udenfor får det ikke af vide.
        protected int WomanCount { get; set; } = 0;

        // Alle i det nærmeste område (Samme assembly) må vide min karakter.
        internal int Grades { get; set; }

        // Alle må vide min arbejdsplads, medmindre man er udenfor mit område (Assembly) og ikke nedarver mig.
        protected internal string Workplace {get;set;}

        // Kun jeg må vide min indkomst og alle mine nærmeste (dem som nedarver mig)
        private protected string Income { get; set; }

        // Dette gælder også metoder



    }
}
