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
        private Efeitos_Control efeitos_Control = new Efeitos_Control();
        private Batalha_Data batalha_Data = new Batalha_Data();

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

        public DataTable Carrega_Combo_Alvo()
        {
            return batalha_Data.Carrega_Combo_Alvo();
        }

        public DataTable Carrega_Combo_Elementos()
        {
            return batalha_Data.Carrega_Combo_Elementos();
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
    }
}
