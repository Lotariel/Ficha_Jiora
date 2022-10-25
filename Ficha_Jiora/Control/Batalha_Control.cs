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
    internal class Batalha_Control
    {
        private Personagem_Model personagem = new Personagem_Model();
        private Personagem_Data personagem_Data = new Personagem_Data();

        private int HPAtual = 0, HPMax = 0, MPAtual = 0, MPMax = 0;

        private int resultado = 0;
        public Batalha_Control(Personagem_Model personagem_Model)
        {
            try
            {
                personagem = personagem_Model;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public DataTable Carrega_Combo_Personagem()
        {
            return personagem_Data.Carrega_Combo_Personagem();
        }

        public void Pocao_Pequena(string IDAlvo)
        {
            try
            {
                Personagem_Model alvo = new Personagem_Model();
                int ValorCura = 0;

                if (IDAlvo != personagem.ID)
                {
                    alvo = personagem_Data.Carrega_Personagem(IDAlvo);
                    HPMax = alvo.HPMax;
                    HPAtual = alvo.HPAtual;
                    MPAtual = alvo.MPAtual;
                    MPMax = alvo.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.30));

                    ValorCura += HPAtual;

                    if (ValorCura > HPMax)
                    {
                        HPAtual = HPMax;
                    }
                    else
                    {
                        HPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("HPatual", HPAtual, personagem.ID);
                }
                else
                {
                    HPMax = personagem.HPMax;
                    HPAtual = personagem.HPAtual;
                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.30));

                    ValorCura += HPAtual;

                    if (ValorCura > HPMax)
                    {
                        HPAtual = HPMax;
                    }
                    else
                    {
                        HPAtual = ValorCura;                        
                    }
                    personagem_Data.Update_Personagem("HPatual", HPAtual, IDAlvo);
                }
                
                

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public int Precisao()
        {
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
