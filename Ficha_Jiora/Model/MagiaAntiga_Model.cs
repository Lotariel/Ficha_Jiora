using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class MagiaAntiga_Model
    {
        public string Descricao { get; set; }
        public int Custo { get; set; }
        public int Multiplicador { get; set; }
        public int ValorMin { get; set; }
        public int ValorMax { get; set; }
    }

    internal class Magia_Model
    {

        public string ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ValorCusto { get; set; }
        public double Multiplicador { get; set; }
        public string TipoCusto { get; set; }
        public string Alvo { get; set; }
        public string TipoDano { get; set; }
        public string Atributo { get; set; }
        public int ValorMin { get; set; }
        public int ValorMax { get; set; }
        public int Dado { get; set; }
        public int CDSEfeito { get; set; }
        public string Efeito { get; set; }
    }
}
