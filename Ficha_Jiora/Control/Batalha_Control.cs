using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.Control
{
    internal class Batalha_Control
    {
        private Personagem_Model personagem = new Personagem_Model();
        private Personagem_Data personagem_Data = new Personagem_Data();
        private int resultado = 0;
        public Batalha_Control (string ID)
        {
            try
            {
                personagem = personagem_Data.Carrega_Personagem(ID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int Precisao()
        {
            //CarregaPersonagem(ID);

            resultado = 40 + (personagem.Foco * 2) + personagem.Nivel;

            resultado += personagem.Mod_Precisao;
            
            if (resultado >= 93)
            {
                return 93;
            }
            else
            {
                return resultado;
            }

        }
        public int Esquiva()
        {
            //CarregaPersonagem(ID);

            resultado = personagem.Velocidade + personagem.Nivel + personagem.Mod_Esquiva;
            
            if (resultado >= 70)
            {
                return 70;
            }
            else
            {
                return resultado;
            }
        }
    }
}
