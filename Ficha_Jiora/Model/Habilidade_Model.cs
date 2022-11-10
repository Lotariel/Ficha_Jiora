using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Habilidade_Model
    {
        public string ID { get; set; }

        public string Nome { get; set; }
        public string TipoCusto { get; set; }
        public int ValorCusto { get; set; }
        public int HIT { get; set; }
        public double Multiplicador { get; set; }
        public string Atributo { get; set; }
        public string TipoDano { get; set; }
        public string Alvo { get; set; }
        public int CDA { get; set; }
        public string Efeito { get; set; }
        public int CDSEfeito { get; set; }
        public string Descricao { get; set; }
        public int MOD_CDA { get; set; }
    }
}
