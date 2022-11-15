using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;
using System.Xml.Linq;

namespace Ficha_Jiora.DAO
{
    internal class Batalha_Data : Conexao

    {
        private string Script = "";
        private Batalha_Modelo batalha_modelo = new Batalha_Modelo();
        private Ataque_Model ataque_Model = new Ataque_Model();
        public DataTable Carrega_Combo_Alvo_Todos()
        {
            try
            {
                DataTable TabelaAlvo = new DataTable();

                Script = "select Nome,ID from Alvo ";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAlvo);
                FechaConexao();

                foreach (DataRow item in TabelaAlvo.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = Convert.ToInt32(item["ID"])

                    };
                }
                return TabelaAlvo;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Alvo_Todos:\n" + ex.Message);
            }
        }

        public DataTable Carrega_Combo_Alvo_Aliado()
        {
            try
            {
                DataTable TabelaAlvo = new DataTable();

                Script = "select Nome,ID from Alvo where id < 99 or id = 102";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAlvo);
                FechaConexao();

                foreach (DataRow item in TabelaAlvo.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = Convert.ToInt32(item["ID"])

                    };
                }
                return TabelaAlvo;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Alvo_Aliado:\n" + ex.Message);
            }
        }
        public DataTable Carrega_Combo_Alvo_Inimigo()
        {
            try
            {
                DataTable TabelaAlvo = new DataTable();

                Script = "select Nome,ID from Alvo where id > 99 and id < 102";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAlvo);
                FechaConexao();

                foreach (DataRow item in TabelaAlvo.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = Convert.ToInt32(item["ID"])

                    };
                }
                return TabelaAlvo;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Alvo_Inimigo:\n" + ex.Message);
            }
        }
        public DataTable Carrega_Combo_Elementos()
        {
            try
            {
                DataTable TabelaElementos = new DataTable();

                Script = "select * from ELEMENTOS where ATIVO = 1 ";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaElementos);
                FechaConexao();

                foreach (DataRow item in TabelaElementos.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        NomeElementos = item["Nome"].ToString()

                    };
                }
                return TabelaElementos;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Elementos:\n" + ex.Message);
            }
        }
        public DataTable Carrega_Combo_Ataques(Personagem_Model personagem)
        {
            try
            {
                DataTable TabelaAtaque = new DataTable();

                Script = "select nome from ataques ";
                Script += "where ativo = 1 and idpersonagem = " + personagem.ID + "order by Nome desc";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAtaque);
                FechaConexao();

                foreach (DataRow item in TabelaAtaque.Rows)
                {
                    ataque_Model = new Ataque_Model()
                    {
                        Nome = item["Nome"].ToString()
                    };
                }
                return TabelaAtaque;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Ataques:\n" + ex.Message);
            }
        }
        public Ataque_Model Carrega_Ataque(Personagem_Model personagem, string nome)
        {
            try
            {
                DataTable TabelaAtaque = new DataTable();
                Ataque_Model ataque = new Ataque_Model();

                Script = "select * from ataques where ativo = 1 and idpersonagem = " + personagem.ID;
                Script += " and nome = '" + nome + "'";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAtaque);

                FechaConexao();

                foreach (DataRow item in TabelaAtaque.Rows)
                {
                    ataque = new Ataque_Model()
                    {
                        IDPersonagem = Convert.ToInt32(item["IDpersonagem"]),
                        Nome = item["Nome"].ToString(),
                        Multiplicador = Convert.ToDouble(item["Multiplicador"]),
                        TipoDano = item["Tipo_Dano"].ToString(),
                        Categoria = item["Categoria"].ToString(),
                        CDSEfeito = Convert.ToInt32(item["CDS_Efeito"]),
                        Efeito = item["Efeito"].ToString(),
                        HIT = Convert.ToInt32(item["HIT"]),
                        Alvo = item["Alvo"].ToString(),
                        Ativo = Convert.ToInt32(item["Ativo"]),
                        Atributo = item["Atributo"].ToString(),
                        MultiAtributo = Convert.ToInt32(item["Multi_Atributo"])
                    };
                }
                return ataque;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Ataque:\n" + ex.Message);
            }
        }

        public void Adiciona_Hit_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            try
            {
                Script = "update Ataques set HIT+=1 ";
                Script += "where Nome = '" + NomeAtaque + "' and IDPersonagem = '" + personagem.ID + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Adiciona_HIT_Ataque:\n" + ex.Message);
            }
        }

        public void Remove_Hit_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            try
            {
                Script = "update Ataques set HIT-=1 ";
                Script += "where Nome = '" + NomeAtaque + "' and IDPersonagem = '" + personagem.ID + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Remove_Hit_Ataque:\n" + ex.Message);
            }
        }

        public void Define_Hit_Ataque(string NomeAtaque, Personagem_Model personagem,int Valor)
        {
            try
            {
                Script = "update Ataques set HIT= "+Valor;
                Script += "where Nome = '" + NomeAtaque + "' and IDPersonagem = '" + personagem.ID + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Adiciona_HIT_Ataque:\n" + ex.Message);
            }
        }

        public void Ativa_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            try
            {
                Script = "update Ataques set Ativo = 1";
                Script += "where Nome = '" + NomeAtaque + "' and IDPersonagem = '" + personagem.ID + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Ativa_Ataque:\n" + ex.Message);
            }
        }

        public void Desativa_Ataque(string NomeAtaque, Personagem_Model personagem)
        {
            try
            {
                Script = "update Ataques set Ativo = 0";
                Script += "where Nome = '" + NomeAtaque + "' and IDPersonagem = '" + personagem.ID + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Batalha_Data.Desativa_Ataque:\n" + ex.Message);
            }
        }
    }
}
