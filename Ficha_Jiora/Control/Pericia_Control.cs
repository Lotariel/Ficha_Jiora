using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;


namespace Ficha_Jiora.Control
{
    internal class Pericia_Control
    {
        private Pericia_Data pericia_Data = new Pericia_Data();
        private Personagem_Control personagem_Control = new Personagem_Control();
        private Personagem_Model personagem_Model = new Personagem_Model();

        public DataTable Carrega_Pericia(string IDPersonagem)
        {
            return pericia_Data.Carrega_Pericia(IDPersonagem);
        }

        public int? CalculaPontosPericia(string IDPersonagem)
        {

            personagem_Model = personagem_Control.Carrega_Personagem(IDPersonagem);
            int? PontosPericiaPersonagem = personagem_Model.PontosPericia;
            int PontosPericiaDistribuido = pericia_Data.TotalPontosPericia(IDPersonagem);

            return PontosPericiaPersonagem - PontosPericiaDistribuido;
        }

        public int ValorAtual(string NomePericia, string IDPersonagem)
        {
            return pericia_Data.ValorAtual(NomePericia, IDPersonagem);
        }

        public void AtualizarValorPericia(int NovoValor, string IDPersonagem, string idpericia)
        {
            pericia_Data.AtualizarValorPericia(NovoValor, IDPersonagem, idpericia);
        }
    }
}
