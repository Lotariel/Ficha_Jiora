using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using Ficha_Jiora.DAO;
using System.Data;

namespace Ficha_Jiora.Control
{
    internal class Personagem_Control
    {
        private Personagem_Data personagem_Data = new Personagem_Data();
        private Personagem_Model personagem_Model = new Personagem_Model();


        public Personagem_Model Carrega_Personagem(string idpersonagem)
        {
            return personagem_Model = personagem_Data.Carrega_Personagem(idpersonagem);           
        }

        public string GetID(string nome)
        {
            return personagem_Data.GetID(nome);
        }

        public DataTable Carrega_Personagem_2(string IDPersonagem)
        {
            return personagem_Data.Carrega_Personagem_2(IDPersonagem);
        }

        public void AlterarCabelo(string idpersonagem, string valor)
        {
            personagem_Data.AlterarCabelo(idpersonagem, valor);
        }
    }
}
