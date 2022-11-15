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
        private Random random = new Random();
        private Personagem_Model personagem = new Personagem_Model();
        private Personagem_Data personagem_Data = new Personagem_Data();
        private Efeitos_Control efeitos_Control = new Efeitos_Control();
        private Batalha_Data batalha_Data = new Batalha_Data();
        private Equipamento_Control equipamento_Control = new Equipamento_Control();
        private Magia_Control magia_Control = new Magia_Control();
        private Elemento_Control elemento_Control = new Elemento_Control();
        private Habilidade_data habilidade_Data = new Habilidade_data();
        

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
                    personagem_Data.Update_Personagem("HPatual", HPAtual, IDAlvo);
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
                    personagem_Data.Update_Personagem("HPatual", HPAtual, personagem.ID);
                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Pocao_Media(string IDAlvo)
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

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.50));

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
                else
                {
                    HPMax = personagem.HPMax;
                    HPAtual = personagem.HPAtual;
                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.50));

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



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Pocao_Grande(string IDAlvo)
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

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.70));

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
                else
                {
                    HPMax = personagem.HPMax;
                    HPAtual = personagem.HPAtual;
                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(HPMax * 0.70));

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



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Elixir_Pequeno(string IDAlvo)
        {
            try
            {
                Personagem_Model alvo = new Personagem_Model();
                int ValorCura = 0;

                if (IDAlvo != personagem.ID)
                {
                    alvo = personagem_Data.Carrega_Personagem(IDAlvo);
                    MPAtual = alvo.MPAtual;
                    MPMax = alvo.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.20));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, IDAlvo);
                }
                else
                {

                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.20));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, personagem.ID);
                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Elixir_Media(string IDAlvo)
        {
            try
            {
                Personagem_Model alvo = new Personagem_Model();
                int ValorCura = 0;

                if (IDAlvo != personagem.ID)
                {
                    alvo = personagem_Data.Carrega_Personagem(IDAlvo);
                    MPAtual = alvo.MPAtual;
                    MPMax = alvo.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.40));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, IDAlvo);
                }
                else
                {

                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.40));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, personagem.ID);
                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Elixir_Grande(string IDAlvo)
        {
            try
            {
                Personagem_Model alvo = new Personagem_Model();
                int ValorCura = 0;

                if (IDAlvo != personagem.ID)
                {
                    alvo = personagem_Data.Carrega_Personagem(IDAlvo);
                    MPAtual = alvo.MPAtual;
                    MPMax = alvo.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.60));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, IDAlvo);
                }
                else
                {

                    MPAtual = personagem.MPAtual;
                    MPMax = personagem.MPMax;

                    ValorCura = Convert.ToInt32(Math.Ceiling(MPMax * 0.60));

                    ValorCura += MPAtual;

                    if (ValorCura > MPMax)
                    {
                        MPAtual = MPMax;
                    }
                    else
                    {
                        MPAtual = ValorCura;
                    }
                    personagem_Data.Update_Personagem("MPatual", MPAtual, personagem.ID);
                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int ValordoAtaque()
        {
            try
            {
                Equipamento_Model arma = new Equipamento_Model();                
                string IDArmaEquipada = equipamento_Control.Arma_Equipada(personagem.ID);                
                int DanoFinal = 0;
                arma = equipamento_Control.Carrega_Arma_Equipada(IDArmaEquipada);

                switch (arma.ATRIBUTO)
                {
                    case "FOR":
                        DanoFinal = (personagem.Forca * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                    case "MAG":
                        DanoFinal = (personagem.Magia * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                    case "FOC":
                        DanoFinal = (personagem.Foco * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                    case "VIT":
                        DanoFinal = (personagem.Vitalidade * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                    case "VEL":
                        DanoFinal = (personagem.Velocidade * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                    case "AUR":
                        DanoFinal = (personagem.Aura * arma.MULTIPLICADOR) + random.Next(arma.QUANT_DADOS, arma.DADO + 1);
                        break;
                }
                return DanoFinal;




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Ataque_Model Carrega_Ataque(Personagem_Model personagem, string nome)
        {
            return batalha_Data.Carrega_Ataque(personagem, nome);
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

        public MagiaAntiga_Model RetornaDescricaoMagiaAntiga(string Elemento, string Rank, int alvo, string Categoria)
        {
            string NovoAlvo = "";
            switch (alvo)
            {

                case 4 :
                    NovoAlvo = "PRÓPRIO";
                    break;
                case < 99:
                    NovoAlvo = "Aliado";
                    break;
                case 100:
                    NovoAlvo = "Inimigo";
                    break;
                case 101:
                    NovoAlvo = "Todos inimigos";
                    break;
                case 102:
                    NovoAlvo = "Todos Aliados";
                    break;

            }

            switch (Rank)
            {
                case "Rank 1":
                    return magia_Control.RetornaDescricaoMagiaAntiga(Elemento, 1,NovoAlvo , Categoria);
                    
                case "Rank 2":
                    return magia_Control.RetornaDescricaoMagiaAntiga(Elemento, 2, NovoAlvo, Categoria);
                    
                case "Rank 3":
                   return magia_Control.RetornaDescricaoMagiaAntiga(Elemento, 3, NovoAlvo, Categoria);
                    
                case "Rank 4":
                    return magia_Control.RetornaDescricaoMagiaAntiga(Elemento, 4, NovoAlvo, Categoria);
                    
                case "Rank 5":
                   return  magia_Control.RetornaDescricaoMagiaAntiga(Elemento, 5, NovoAlvo, Categoria);
                default:
                    MagiaAntiga_Model magia = new MagiaAntiga_Model();
                    return magia;
            }
        }
        public DataTable Carrega_Combo_Alvo_Todos()
        {
            return batalha_Data.Carrega_Combo_Alvo_Todos();
        }

        public DataTable Carrega_Combo_Alvo_Aliado()
        {
            return batalha_Data.Carrega_Combo_Alvo_Aliado();
        }

        public DataTable Carrega_Combo_Alvo_Inimigo()
        {
            return batalha_Data.Carrega_Combo_Alvo_Inimigo();
        }

        public DataTable Carrega_Combo_Elementos()
        {
            return batalha_Data.Carrega_Combo_Elementos();
        }

        public DataTable Carrega_Combo_Ataques(Personagem_Model personagem)
        {
            return batalha_Data.Carrega_Combo_Ataques(personagem);
        }

        public DataTable Carrega_Combo_Habilidade(Personagem_Model personagem,string Postura, string Arma)
        {
            return habilidade_Data.Carrega_Combo_Habilidade(personagem, Postura,Arma);
        }

        public Habilidade_Model Carrega_Habilidade(string IDHabilidade)
        {
            return habilidade_Data.Carrega_Habilidade(IDHabilidade);
        }
        public void AdicionaTurno(Personagem_Model personagem)
        {
            int Valor = personagem.Turnos + 1;

            personagem_Data.Update_Personagem("Turnos", Valor, personagem.ID);
            efeitos_Control.VerificaEfeitos(personagem);

        }

        public void ZeraTurno(Personagem_Model personagem)
        {
            personagem_Data.Update_Personagem("Turnos", 0, personagem.ID);
        }

        public void CurarHPAtual(string id, int valor)
        {
            try
            {
                Personagem_Model personagemCurado = new Personagem_Model();
                personagemCurado = personagem_Data.Carrega_Personagem(id);
                int NewValor = personagemCurado.HPAtual + valor;

                if (NewValor >= personagemCurado.HPMax)
                {
                    valor = personagemCurado.HPMax;
                }
                else
                {
                    valor = NewValor;
                }

                personagem_Data.Update_Personagem("HPAtual", valor, id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Curar HP Atual: "+ ex.Message);
            }
        }

        public void ReduzirHPAtual(string id, int valor)
        {
            try
            {
                int NewValor = personagem.HPAtual - valor;

                if (NewValor <= 0)
                {
                    valor = 0;
                }
                else
                {
                    valor = NewValor;
                }

                personagem_Data.Update_Personagem("HPAtual", valor, id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Reduzir HP Atual: " + ex.Message);
            }
        }
        public void CurarMPAtual(string id, int valor)
        {
            try
            {
                Personagem_Model personagemCurado = new Personagem_Model();
                personagemCurado = personagem_Data.Carrega_Personagem(id);
                int NewValor = personagemCurado.MPAtual + valor;

                if (NewValor >= personagemCurado.MPMax)
                {
                    valor = personagemCurado.MPMax;
                }
                else
                {
                    valor = NewValor;
                }

                personagem_Data.Update_Personagem("MPAtual", valor, id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Curar MP Atual: " + ex.Message);
            }
        }

        public void ReduzirMPAtual(string id, int valor)
        {
            try
            {
                int NewValor = personagem.MPAtual - valor;

                if (NewValor <=0)
                {
                    valor = 0;
                }
                else
                {
                    valor = NewValor;
                }

                personagem_Data.Update_Personagem("MPAtual", valor, id);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Reduzir MP Atual: " + ex.Message);
            }
        }

        public void AumentaElementoMod(string ID, string Coluna, int valor)
        {
            elemento_Control.AumentaElementoMod(ID, Coluna, valor);
        }

        public void AdicionaEncantamento(string NomeElemento, int Turnos, string IDpersonagem)
        {
            efeitos_Control.AdicionaEncantamento(NomeElemento, Turnos, IDpersonagem);
        }

        public Efeitos_Model Carrega_Efeito(string IDPersonagem)
        {
            return efeitos_Control.Carrega_Efeito(IDPersonagem);
        }

        public void Adiciona_Hit_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            batalha_Data.Adiciona_Hit_Ataque(NomeAtaque, personagem);
        }
        public void Remove_Hit_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            batalha_Data.Remove_Hit_Ataque(NomeAtaque, personagem);
        }

        public void Define_Hit_Ataque(string NomeAtaque, Personagem_Model personagem, int Valor)
        {
            batalha_Data.Define_Hit_Ataque(NomeAtaque, personagem, Valor);
        }

        public DataTable Carrega_Combo_Magia(Personagem_Model personagem)
        {
            return magia_Control.Carrega_Combo_Magia(personagem);
        }

        public Magia_Model Carrega_Magia(string IDMagia)
        {
            return magia_Control.Carrega_Magia(IDMagia);
        }

        public void Ativa_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            batalha_Data.Ativa_Ataque(NomeAtaque, personagem);        
        }

        public void Desativa_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            batalha_Data.Desativa_Ataque(NomeAtaque, personagem);
        }

    }
}
