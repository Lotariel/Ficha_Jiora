using Ficha_Jiora.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.Control
{
    internal class Summon_Control
    {
        private Summon_Data summon_Data = new Summon_Data();
        private Summon_Model summon_Model = new Summon_Model();
        private Personagem_Data personagem_Data = new Personagem_Data();
        private Personagem_Model personagem_Model = new Personagem_Model();
        private Random random = new Random();
        public Summon_Model CarregaSummon(string summonId, string personagemId)
        {
            summon_Model = summon_Data.CarregaSummon(summonId, personagemId);
            return summon_Model;
        }

        public int? GetIdSummons(string nome, string mestreid)
        {
            return summon_Data.GetIdSummons(nome, mestreid);
        }

        public void ReduzHp(Summon_Model Vsummon_Model, int? valor)
        {

            int? resultado =  Vsummon_Model.HPAtual - valor;

            if ( resultado <= 0)
            {
                summon_Data.ReduzHp(Vsummon_Model,0);
            }
            else
            {
                summon_Data.ReduzHp(Vsummon_Model, resultado);
            }
        }
    }
}
