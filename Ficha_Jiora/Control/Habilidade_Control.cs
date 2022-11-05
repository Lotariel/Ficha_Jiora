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
    internal class Habilidade_Control
    {
        private Rolar_Dados dados = new Rolar_Dados();
        public string MeatBone_Slash(Personagem_Model personagem)
        {
            try
            {
                double HP = personagem.HPMax * 0.25;
                string texto = "";

                if (personagem.HPAtual <= HP)
                {
                    texto = "\r\n\r\n   Contra-Ataque   \r\n\r\n ";
                    if (dados.D100() <= 50)
                    {

                        texto += personagem.Nome + " teve sucesso em contra atacar.";
                        texto += "\r\n\r\nDano Causado: " + personagem.HPMax + " Físico e ignora a armadura do alvo.";
                        return texto;

                    }
                    else
                    {
                        texto += personagem.Nome + " falhou ao tentar o Contra Ataque.";
                        return texto;
                    }
                }
                else
                {
                    return texto;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string StrikeBack(Personagem_Model personagem)
        {
            try
            {
                string texto = "";

                texto = "\r\n\r\n   Contra-Ataque   \r\n\r\n ";
                if (dados.D100() <= 30)
                {

                    texto += personagem.Nome + " teve sucesso em contra atacar.";
                    texto += "\r\n\r\nRealize uma ação de ataque.";
                    return texto;

                }
                else
                {
                    texto += personagem.Nome + " falhou ao tentar o Contra Ataque.";
                    return texto;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
