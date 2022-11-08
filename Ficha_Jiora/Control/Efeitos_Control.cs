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
        private Personagem_Control personagem_Control = new Personagem_Control();

        private Random random = new Random();
        public Efeitos_Model Carrega_Efeito(string IDPersonagem)
        {
            return efeitos_Data.Carrega_Efeito(IDPersonagem);
        }

        public void AtivaPoison(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Poison_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Poison", turnos, IDpersonagem);
        }
        public void AtivaBurn(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Burn_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Burn", turnos, IDpersonagem);
        }
        public void AtivaFrozen(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Frozen_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Frozen", turnos, IDpersonagem);
        }
        public void AtivaSilence(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Silence_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Silence", turnos, IDpersonagem);
        }
        public void AtivaConfuse(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Confuse_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Confuse", turnos, IDpersonagem);
        }
        public void AtivaParalyze(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Paralyze_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Paralyze", turnos, IDpersonagem);
        }
        public void AtivaCharm(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Charm_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Charm", turnos, IDpersonagem);
        }
        public void AtivaBlind(string IDpersonagem, int turnos)
        {
            efeitos_Data.AtivarEfeito("Blind_ativo", IDpersonagem);
            efeitos_Data.AdicionaTurnos("Blind", turnos, IDpersonagem);
        }
        public void DesativarEfeito(string Coluna, string IDpersonagem)
        {
            efeitos_Data.DesativarEfeito(Coluna, IDpersonagem);
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

            if (efeitos_Model.Turnos_Encantamento > 0)
            {
                valor = efeitos_Model.Turnos_Encantamento - 1;
                efeitos_Data.ReduzTurnos("Turnos_Encantamento", valor, personagem.ID);
            }
        }
        public void VerificaEfeito(Personagem_Model personagem, out int poison, out string silence, out int burn, out string frozen, out bool paralyze, out string confuse, out string charm)
        {

            poison = 0;
            silence = "";
            burn = 0;
            frozen = "";
            paralyze = false;
            confuse = "";
            charm = "";

            if (personagem.Poison_Ativo)
            {
                poison = Poison(personagem);
                DesativarEfeito("Burn_ativo", personagem.ID);
            }
            if (personagem.Silence_Ativo)
            {
                silence = Silence();
            }
            if (personagem.Burn_Ativo)
            {
                burn = Burn(personagem);
                DesativarEfeito("Frozen_ativo", personagem.ID);
                DesativarEfeito("Poison_ativo", personagem.ID);
            }
            if (personagem.Frozen_Ativo)
            {
                frozen = Frozen();
                DesativarEfeito("Paralyze_ativo", personagem.ID);
            }
            if (personagem.Paralyze_Ativo)
            {
                paralyze = Paralyze();
            }
            if (personagem.Confuse_Ativo)
            {
                confuse = Confuse();
            }
            if (personagem.Charm_Ativo)
            {
                charm = Charm();
            }
            if (personagem.Blind_Ativo)
            {
                Blind(personagem);
            }
        }
        private int Burn(Personagem_Model personagem)
        {
            try
            {
                double Valor = Math.Ceiling(personagem.HPAtual * 0.10);

                personagem_Control.ReduzHPAtual(personagem.ID, Convert.ToInt32(Valor));
                return Convert.ToInt32(Valor);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em: Efeitos_Control.Burn:" + ex.Message);
            }

        }
        private int Poison(Personagem_Model personagem)
        {
            try
            {
                double Valor = Math.Ceiling(personagem.HPMax * 0.10);

                personagem_Control.ReduzHPAtual(personagem.ID, Convert.ToInt32(Valor));
                return Convert.ToInt32(Valor);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em: Efeitos_Control.Burn:" + ex.Message);
            }

        }
        private string Frozen()
        {
            return "Você está congelado, envolvido\r\npor uma camada de gelo grossa o suficiente para\r\nevitar que execute Ações";
        }
        private string Confuse()
        {

            switch (random.Next(1, 9))
            {
                case 1:
                    return "Use sua habilidade mais fraca no aliado mais próximo.";

                case 2:
                    return "Use sua magia mais fraca no aliado mais próximo.";

                case 3:
                    return "Use uma Poção Grande no aliado mais próximo.";

                case 4:
                    return "Faça um ataque normal em você mesmo.";

                case 5:
                    return "Use sua habilidade mais fraca no aliado mais próximo.";

                case 6:
                    return "Ataque um oponente aleatório.";

                case 7:
                    return "Use uma Elixir Grande no aliado mais próximo.";

                case 8:
                    return "Use sua magia ou habilidade mais poderosa em um oponente aleatório.";

                default:
                    return "";

            }
        }
        private bool Paralyze()
        {
            if (random.Next(1, 101) <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Blind(Personagem_Model personagem)
        {
            Batalha_Control batalha = new Batalha_Control(personagem);

            double Valor = batalha.Precisao();
            Valor = Math.Floor(Valor * 0.50);

            personagem_Control.AlteraPrecMod(-Valor, personagem.ID);
            personagem_Control.AlteraCriticoMod(-personagem.CDS_Critico, personagem.ID);
            //precisa reduzir a CDA da habilidade também 
        }
        private string Charm()
        {
            return "Você está sendo controlado por um oponente, obedeça qualquer comando dele.";
        }
        private string Silence()
        {
            return "Seu controle de mana foi selado, agora você não pode utilizar sua mana.";
        }

        public void AdicionaEncantamento(string NomeElemento, int Turnos, string IDpersonagem)
        {
            efeitos_Data.AdicionaEncantamento(NomeElemento, Turnos, IDpersonagem);
        }


    }
}
