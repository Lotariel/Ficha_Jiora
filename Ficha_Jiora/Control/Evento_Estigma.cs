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
        public string Protecao(Personagem_Model personagem)
        {
			try
			{
				if (personagem.ID == "3")
				{
                    if (personagem.PontosEstigma >= 5)
                    {
                        return estigma_data.GetEvolucao("2.1", "3");
					}
					else
					{
						return "";
					}
				}
				else
				{
					return "";
				}
				
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
