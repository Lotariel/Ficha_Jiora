using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Summon_Model
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ValorBaseAtaque { get; set; }
        public int Dado { get; set; }
        public string AtributoAtaque { get; set; }
        public int QuantidadeDado { get; set; }
        public string Imagem { get; set; }
        public int MestreID { get; set; }
        public int HPAtual { get; set; }
        public decimal MaxHP { get; set; }
        public int AtaqueFinal { get; set; }
        public string TextoInvocacao { get; set; }
    }
}
