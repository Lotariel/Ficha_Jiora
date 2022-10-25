using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using Ficha_Jiora.DAO;

namespace Ficha_Jiora.Control
{
    internal class Evento_Estigma
    {
        private Estigma_Data estigma_data = new Estigma_Data();
        public string Alert_Estigma(Personagem_Model personagem)
        {
            switch (Convert.ToInt16(personagem.ID))
            {
                case 1:
                    return Alerta_Coragem(personagem);

                case 2:
                    return Alerta_Amizade(personagem);

                case 3:
                    return Alerta_Protecao(personagem);

                case 4:
                    return Alerta_Esperanca(personagem);

                default:
                    return "";

            }
        }
        private string Alerta_Protecao(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 5:
                        return estigma_data.GetTextoEvolucao("2", "2", personagem.ID);
                    default:
                        return "";
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Alerta_Protecao: " + ex.Message);
            }
        }
        private string Alerta_Esperanca(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 3:
                        return estigma_data.GetTextoEvolucao("2", "2", personagem.ID);
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Alerta_Esperanca: " + ex.Message);
            }
        }
        private string Alerta_Coragem(Personagem_Model personagem)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Alerta_Coragem " + ex.Message);
            }
        }
        private string Alerta_Amizade(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 2:
                        return estigma_data.GetTextoEvolucao("2", "2", personagem.ID);
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Alerta_Amizade: " + ex.Message);
            }
        }

        public void Evolui_Estigma(Personagem_Model personagem)
        {
            switch (Convert.ToInt16(personagem.ID))
            {
                case 1:
                    Evolui_Coragem(personagem);
                    break;
                case 2:
                    Evolui_Amizade(personagem);
                    break;
                case 3:
                    Evolui_Protecao(personagem);
                    break;
                case 4:
                    Evolui_Esperanca(personagem);
                    break;
            }
        }

        private void Evolui_Protecao(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 5:
                        estigma_data.EvoluirPassiva(personagem, 2);
                        break;

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Evolui_Protecao: " + ex.Message);
            }
        }
        private void Evolui_Esperanca(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 3:
                        estigma_data.EvoluirPassiva(personagem, 2);
                        break;

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Evolui_Esperanca: " + ex.Message);
            }
        }
        private void Evolui_Coragem(Personagem_Model personagem)
        {

        }
        private void Evolui_Amizade(Personagem_Model personagem)
        {
            try
            {
                switch (personagem.PontosEstigma)
                {
                    case 2:
                        estigma_data.EvoluirPassiva(personagem, 2);
                        break;

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Evento_Estigma.Evolui_Amizade: " + ex.Message);
            }
        }

    }
}
