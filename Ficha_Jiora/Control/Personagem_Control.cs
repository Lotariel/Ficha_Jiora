using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using Ficha_Jiora.DAO;
using System.Data;
using System.Threading.Tasks.Sources;
using System.Xml.Schema;

namespace Ficha_Jiora.Control
{
    internal class Personagem_Control
    {
        private Personagem_Data personagem_Data = new Personagem_Data();
        private Personagem_Model personagem_Model = new Personagem_Model();
        Random random = new Random();

        public Personagem_Model Carrega_Personagem(string idpersonagem)
        {
            return personagem_Model = personagem_Data.Carrega_Personagem(idpersonagem);
        }

        public string GetID(string nome)
        {
            return personagem_Data.GetID(nome);
        }
        public void AumentarAtributo(string coluna, double valor, Personagem_Model personagem)
        {
            if (coluna == "Potencia")
            {
                double potencia = valor + 1.0;
                personagem_Model = Carrega_Personagem(personagem.ID);
                valor = (potencia * 0.1) + 2;
                personagem_Data.Update_Personagem(coluna, potencia, personagem.ID);
                personagem_Data.Update_Personagem("Valor_critico", valor, personagem.ID);
            }
            else
            {
                valor += 1;
                personagem_Data.Update_Personagem(coluna, valor, personagem.ID);
            }
            Aumenta_HP_Max(personagem);
            Aumenta_MP_Max(personagem);
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
        public void ReduzHPAtual(string ID, int valor)
        {
            int result = personagem_Model.HPAtual - valor;
            if (result < 0)
            {
                personagem_Data.Update_Personagem("HPAtual", 0, ID);
            }
            else
            {
                personagem_Data.Update_Personagem("HPAtual", valor, ID);
            }

        }
        public void ReduzMPAtual(string ID, int valor)
        {
            int result = personagem_Model.MPAtual - valor;

            if (result < 0)
            {
                personagem_Data.Update_Personagem("MPAtual", 0, ID);
            }
            else
            {
                personagem_Data.Update_Personagem("MPAtual", result, ID);
            }

        }
        public void AlteraPrecMod(double valor, string ID)
        {
            personagem_Data.Update_Personagem("Mod_precisao", valor, ID);
        }
        public void AlteraCriticoMod(double valor, string ID)
        {
            personagem_Data.Update_Personagem("Mod_cds_Critico", valor, ID);
        }
        public void AlteraForcaMod(double valor, string ID)
        {
            personagem_Data.Update_Personagem("Mod_Forca", valor, ID);
        }
        private void Aumenta_HP_Max(Personagem_Model personagem)
        {
            int BonusHPMax = random.Next(1,personagem_Data.GetDado_vida(personagem.Classe)+1);
            int valor = BonusHPMax + personagem.HPMax;

            personagem_Data.Update_Personagem("Hpmax", valor, personagem.ID);

        }
        private void Aumenta_MP_Max(Personagem_Model personagem)
        {
            int BonusMPMax = random.Next(1, personagem_Data.GetDado_mana(personagem.Classe) + 1);
            int valor = BonusMPMax + personagem.MPMax;

            personagem_Data.Update_Personagem("Mpmax", valor, personagem.ID);

        }
        public void GerenciaTonz(int DepositarOuSacar, int valor, Personagem_Model personagem)
        {//Depositar = 1 Sacar <> 1
            int tonzAtual = personagem.Tonz, saldo =0;

            if (DepositarOuSacar ==1)
            {
                saldo = tonzAtual + valor;
                personagem_Data.Update_Personagem("tonz", saldo, personagem.ID);
            }
            else
            {
                saldo = tonzAtual - valor;
                if (saldo < 0)
                {
                    personagem_Data.Update_Personagem("tonz", 0, personagem.ID);
                }
                else
                {
                    personagem_Data.Update_Personagem("tonz", saldo, personagem.ID);
                }                
            }
        }

        public void AmaduraUP(Personagem_Model personagem)
        {
            int valor = personagem.Defesa + 1;

            if (valor >= 124)
            {
                personagem_Data.Update_Personagem("Defesa", 124, personagem.ID);
            }
            else
            {
                personagem_Data.Update_Personagem("Defesa", valor, personagem.ID);
            }
            
        }

        public void ResistenciaUP(Personagem_Model personagem)
        {
            int valor = personagem.Resistencia + 1;
            
            
            if (valor >= 120)
            {
                personagem_Data.Update_Personagem("Resistencia", 120, personagem.ID);
            }
            else
            {
                personagem_Data.Update_Personagem("Resistencia", valor, personagem.ID);
            }
        }


    }
}
