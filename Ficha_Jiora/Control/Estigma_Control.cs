using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.Control
{
    internal class Estigma_Control
    {
        private Estigma_Data estigma_Data = new Estigma_Data();
        public string GetNome(int nivel, string grupo, string idpersonagem)
        {
            return estigma_Data.GetNome(nivel.ToString(),grupo,idpersonagem);
        }

        public string GetDescricao(int nivel, string grupo, string idpersonagem)
        {
            return estigma_Data.GetDescricao(nivel.ToString(),grupo,idpersonagem);
        }

        public string GetEvolucao(string nivel, string idpersonagem)
        {
            return "";//estigma_Data.GetEvolucao(nivel, idpersonagem);
        }

        public void AumentarPontosEstigma(Personagem_Model personagem)
        {
            int valor = personagem.PontosEstigma + 1;
            estigma_Data.AumentarPontosEstigma(valor,personagem.ID);
        }
              


        public int GetNivel(string grupo, string idpersonagem)
        {
            return estigma_Data.GetNivel(grupo, idpersonagem);
        }
    }
}
