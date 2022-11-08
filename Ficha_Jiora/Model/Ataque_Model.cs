using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Ataque_Model
    {
        public int IDPersonagem { get; set; }
        public string Nome { get; set; }
        public double Multiplicador { get; set; }
        public string TipoDano { get; set; }
        public string Categoria { get; set; }
        public int CDSEfeito { get; set; }
        public string Efeito { get; set; }
        public int HIT { get; set; }
        public string Alvo { get; set; }
        public int Ativo { get; set; }
        public string Atributo { get; set; }
        public int MultiAtributo { get; set; }
    }
}
