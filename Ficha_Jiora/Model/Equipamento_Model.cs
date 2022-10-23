using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Equipamento_Model
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public int RANK { get; set; }
        public string ATRIBUTO { get; set; }
        public int MULTIPLICADOR { get; set; }
        public int QUANT_DADOS { get; set; }
        public int DADO { get; set; }
        public string EFEITO_1 { get; set; }
        public string EFEITO_2 { get; set; }
        public string EFEITO_3 { get; set; }
        public string IMAGEM { get; set; }
        public string DESCRICAO { get; set; }
    }
}
