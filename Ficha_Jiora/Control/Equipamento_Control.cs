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
    internal class Equipamento_Control
    {
        private Equipamento_Data equipamento_data = new Equipamento_Data();
        public string Arma_Equipada(string ID_PERSONAGEM)
        {
            return equipamento_data.Arma_Equipada(ID_PERSONAGEM);
        }

        public Equipamento_Model Carrega_Arma_Equipada(string IDArma)
        {
            return equipamento_data.Carrega_Arma_Equipada(IDArma);
        }

        public DataTable Carrega_Combo_Arma(string idpersonagem)
        {
            return equipamento_data.Carrega_Combo_Arma(idpersonagem);
        }

        public void Troca_Arma_Equipada(string IDArmaEquipada, int idarmaNova, string NomeAtaqueAtivo, string NomeAtaqueNovo)
        {
            equipamento_data.Troca_Arma_Equipada(IDArmaEquipada,idarmaNova, NomeAtaqueAtivo, NomeAtaqueNovo);
        }

        public bool Valida_Troca_de_Arma(string idpersonagem)
        {
            return equipamento_data.Valida_Troca_de_Arma(idpersonagem);
        }
    }
}
