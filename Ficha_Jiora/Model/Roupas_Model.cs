using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Roupas_Model
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Poison { get; set; }
        public int Burn { get; set; }
        public int Paralyze { get; set; }
        public int Frozen { get; set; }
        public int Confuse { get; set; }
        public int Silence { get; set; }
        public int Blind { get; set; }
        public int Charm { get; set; }
        public double preco { get; set; }
    }
}
