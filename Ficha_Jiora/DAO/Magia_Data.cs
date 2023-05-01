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
    internal class Magia_Data : Conexao
    {
        private string Script = "";

        public MagiaAntiga_Model RetornaDescricaoMagiaAntiga(string Elemento, int Rank, string alvo, string Categoria)
        {
            try
            {
                DataTable TabelaMagiaAntiga = new DataTable();
                MagiaAntiga_Model magia_a = new MagiaAntiga_Model();

                if (Categoria == "Ofensivo")
                {
                    if (alvo == "Todos Aliados" || alvo == "Todos inimigos")
                    {
                        Script = "select " + Elemento + ",qntd_dado,custo,mult_dado,multiplicador from magias_antigas";
                        Script += " where rank = " + Rank;
                        Script += " AND alvo = 'Todos inimigos'";
                        Script += " AND Tipo = '" + Categoria + "'";
                    }
                    else
                    {
                        Script = "select " + Elemento + ",qntd_dado,custo,mult_dado,multiplicador from magias_antigas";
                        Script += " where rank = " + Rank;
                        Script += " AND alvo = 'inimigo'";
                        Script += " AND Tipo = '" + Categoria + "'";
                    }

                }
                else
                {
                    Script = "select " + Elemento + ",qntd_dado,custo,mult_dado,multiplicador from magias_antigas";
                    Script += " where rank = " + Rank;
                    Script += " AND alvo = '" + alvo + "'";
                    Script += " AND Tipo = '" + Categoria + "'";
                }


                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaMagiaAntiga);
                FechaConexao();

                foreach (DataRow item in TabelaMagiaAntiga.Rows)
                {
                    magia_a = new MagiaAntiga_Model()
                    {
                        Descricao = item[Elemento].ToString(),
                        ValorMin = Convert.ToInt32(item["qntd_dado"]),
                        ValorMax = Convert.ToInt32(item["mult_dado"]),
                        Custo = Convert.ToInt32(item["custo"]),
                        Multiplicador = Convert.ToInt32(item["multiplicador"])
                    };
                }
                return magia_a;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em Magia_Data.RetornaDescricaoMagiaAntiga: " + ex.Message);
            }
        }

        public DataTable Carrega_Combo_Magia(Personagem_Model personagem)
        {
            try
            {
                DataTable TabelaMagia = new DataTable();
                Magia_Model magia = new Magia_Model();

                Script = "select m.ID, Concat(NOME,' - ',VALOR_CUSTO,' ',TIPO_CUSTO) as Nome from MAGIA_PERSONAGEM MP inner join MAGIA M  ";
                Script += "on MP.ID_MAGIA = M.ID ";
                Script += "where mp.equipado = 1 and mp.ID_PERSONAGEM =" + personagem.ID;

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaMagia);
                FechaConexao();

                foreach (DataRow item in TabelaMagia.Rows)
                {
                    magia = new Magia_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = item["ID"].ToString(),
                    };
                }
                return TabelaMagia;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Magia_data.Carrega_Combo_Magia:\n" + ex.Message);
            }
        }


        public DataTable Carrega_Combo_Magia_Summon(Summon_Model modelo)
        {
            try
            {
                DataTable TabelaMagia = new DataTable();
                Magia_Model magia = new Magia_Model();

                Script = "select m.ID, Concat(NOME,' - ',VALOR_CUSTO,' ',TIPO_CUSTO) as Nome from MAGIA_Summons MP inner join MAGIA M  ";
                Script += "on MP.IDMAGIA = M.ID ";
                Script += "where mp.equipado = 1 and mp.idsummon =" + modelo.ID;

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaMagia);
                FechaConexao();

                foreach (DataRow item in TabelaMagia.Rows)
                {
                    magia = new Magia_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = item["ID"].ToString(),
                    };
                }
                return TabelaMagia;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Magia_data.Carrega_Combo_Magia_Summon:\n" + ex.Message);
            }
        }
        public Magia_Model Carrega_Magia(string IDMagia)
        {
            try
            {
                DataTable TabelaMagia = new DataTable();
                Magia_Model magia = new Magia_Model();

                Script = "select * from magia where ID = "+ IDMagia;

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaMagia);
                FechaConexao();

                foreach (DataRow item in TabelaMagia.Rows)
                {
                    magia = new Magia_Model()
                    {
                       ID = item["ID"].ToString(),
                       Nome = item["Nome"].ToString(),
                       TipoCusto = item["Tipo_custo"].ToString(),
                       ValorCusto = Convert.ToInt32(item["Valor_custo"]),
                       Alvo = item["Alvo"].ToString(),
                       TipoDano = item["Tipo_dano"].ToString(),
                       Multiplicador = Convert.ToDouble(item["Multiplicador"]),
                       Atributo = item["Atributo"].ToString(),
                       ValorMin = Convert.ToInt32(item["Valor_MIN"]),
                       ValorMax = Convert.ToInt32(item["Valor_Max"]),
                       Dado = Convert.ToInt32(item["Dado"]),
                       Descricao = item["Descricao"].ToString(),
                       CDSEfeito = Convert.ToInt32(item["CDS_Efeito"]),
                       Efeito = item["Efeito"].ToString()
                    };
                }
                return magia;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em Magia_Data.Carrega_Magia: " + ex.Message);
            }
        }

        public void Ativa_Magia(string idmagia, string idpersonagem)
        {
            try
            {
                Script = "update MAGIA_PERSONAGEM set Equipado = 1";
                Script += "where ID_MAGIA = @idmag and ID_PERSONAGEM =@idper";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.Parameters.Add(new SqlParameter("idmag", idmagia));
                update.Parameters.Add(new SqlParameter("idper", idpersonagem));
                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Magia_Data.Ativa_Magia: " + ex.Message);
            }
        }

        public void Desativa_Magia(string idmagia, string idpersonagem)
        {
            try
            {
                Script = "update MAGIA_PERSONAGEM set Equipado = 0";
                Script += "where ID_MAGIA = @idmag and ID_PERSONAGEM =@idper";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.Parameters.Add(new SqlParameter("idmag", idmagia));
                update.Parameters.Add(new SqlParameter("idper", idpersonagem));
                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em Magia_Data.Desativa_Magia: " + ex.Message);
            }
        }
    }
}
