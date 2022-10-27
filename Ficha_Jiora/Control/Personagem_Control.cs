using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using Ficha_Jiora.DAO;
using System.Data;
using System.Threading.Tasks.Sources;

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

        public void AumentarAtributo(string coluna, double valor, string id)
        {
            if (coluna == "Potencia")
            {
                double potencia = valor + 1.0;
                personagem_Model = Carrega_Personagem(id);
                valor = (potencia * 0.1) + 2;
                personagem_Data.Update_Personagem(coluna, potencia, id);
                personagem_Data.Update_Personagem("Valor_critico", valor, id);

            }
            else
            {
                valor += 1;
                personagem_Data.Update_Personagem(coluna, valor, id);

            }
            
        }

        public int? GerenciaAtributos(string ID)
        {
            personagem_Model = Carrega_Personagem(ID);
            int? ValorPadraoDeAtributos = 40;
            int? NivelPersonagem = personagem_Model.Nivel;
            int? SomaTotalAtributos = personagem_Data.TotalAtributos(ID);
            int? resultado = 0;

            resultado = (ValorPadraoDeAtributos + NivelPersonagem) - SomaTotalAtributos;

            return resultado;
        }

        public int TesteAtributo(int ValorTeste, int ValorDado)
        {
            /* 1- Acerto Crítico
             * 2- Acerto
             * 3- Falha
             * 4- Falha Crítica
             */
            if (ValorDado <= ValorTeste)
            {
                if (ValorDado <= 10)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                if (ValorDado >= 95)
                {
                    return 4;
                }
                else
                {
                    return 3;
                }
            }
        }
    }
}
