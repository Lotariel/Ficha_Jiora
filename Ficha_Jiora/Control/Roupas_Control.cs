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
    internal class Roupas_Control
    {
        private Roupas_Data roupas_Data = new Roupas_Data();
        private Roupas_Model roupas_Model = new Roupas_Model();
        public string Roupa_Equipada(string ID_PERSONAGEM)
        {
            return roupas_Data.Roupa_Equipada(ID_PERSONAGEM);
        }

        public Roupas_Model Carrega_Roupa_Equipada(string IdRoupa)
        {
            return roupas_Data.Carrega_Roupa_Equipada(IdRoupa);
        }

        public DataTable Carrega_Combo_Roupa(string idpersonagem)
        {
            return roupas_Data.Carrega_Combo_Roupa(idpersonagem);
        }
        public void TrocarRoupa(string iDAtual, string iDNovo)
        {
            roupas_Data.TrocarRoupa(iDAtual, iDNovo);
        }

        public void DefesaUP(Roupas_Model roupas)
        {
            int valor = roupas.Defesa + 1;
            string iD = roupas.ID.ToString();

            if (valor >= 124)
            {
                roupas_Data.DefesaUP(124, iD);           
            }
            else
            {                
                roupas_Data.DefesaUP(valor, iD);
            }            
        }

        public void ResistenciaUP(Roupas_Model roupas)
        {
            int valor = roupas.Resistencia + 1;
            string iD = roupas.ID.ToString();

            if (valor >= 120)
            {
                roupas_Data.ResistenciaUP(120, iD);
            }
            else
            {
                roupas_Data.ResistenciaUP(valor, iD);
            }
        }
    }
}
