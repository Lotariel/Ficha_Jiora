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
    internal class Efeitos_Control
    {
        private Efeitos_Data efeitos_Data = new Efeitos_Data();
        private Efeitos_Model efeitos_Model = new Efeitos_Model();
        public Efeitos_Model Carrega_Efeito(string IDPersonagem)
        {
            return efeitos_Data.Carrega_Efeito(IDPersonagem);
        }

        public void AtivaPoison(string IDpersonagem,int turnos)
        {
            efeitos_Data.AtivarEfeito("Poison_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Poison", turnos, IDpersonagem);
        }

        public void VerificaEfeitos(Personagem_Model personagem)
        {
            efeitos_Model = Carrega_Efeito(personagem.ID);
            int valor = 0;
            if (efeitos_Model.Poison > 0)
            {
                valor = efeitos_Model.Poison - 1;
                efeitos_Data.ReduzTurnos("Poison", valor, personagem.ID);
            }
            else
            {
                efeitos_Data.DesativarEfeito("Poison_Ativo", personagem.ID);
            }
        }
    }
}
