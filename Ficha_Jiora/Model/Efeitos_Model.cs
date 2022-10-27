using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Efeitos_Model
    {
        public int IDPersonagem { get; set; }
        public string Elemento_Encantado { get; set; }

        public int Turnos_Encantamento { get; set; }

        public int Poison { get; set; }
        public int Burn { get; set; }
        public int Paralyze { get; set; }
        public int Frozen{ get; set; }
        public int Confuse { get; set; }
        public int Silence { get; set; }
        public int Blind { get; set; }
        public int Charm { get; set; }

    }
}
