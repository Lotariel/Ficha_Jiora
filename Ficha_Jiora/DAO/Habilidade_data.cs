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
    internal class Habilidade_data : Conexao
    {
        private string Script = "";

        private Habilidade_Model habilidade_Model = new Habilidade_Model();

        public DataTable Carrega_Combo_Habilidade(Personagem_Model personagem, string postura, string Arma)
        {
            try
            {
                DataTable TabelaHabilidade = new DataTable();

                Script = "select h.ID,Concat(H.Nome,' - ',H.Valor_Custo,' ',H.TIpo_Custo) as Nome  ";
                Script += "from Habilidade_Personagem HP inner join Habilidade H ";
                Script += "on H.ID = HP.IDHabilidade ";
                Script += "where HP.IDPersonagem = " + personagem.ID;
                Script += " and HP.postura = '" + postura+ "' ";
                Script += "and Arma_Equipada = '" + Arma + "'";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaHabilidade);
                FechaConexao();

                foreach (DataRow item in TabelaHabilidade.Rows)
                {
                    habilidade_Model = new Habilidade_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = item["ID"].ToString(),
                    };
                }
                return TabelaHabilidade;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Habilidade_data.Carrega_Combo_Habilidade:\n" + ex.Message);
            }
        }

        public DataTable Carrega_Combo_Habilidade_summon(Summon_Model modelo)
        {
            try
            {
                DataTable TabelaHabilidade = new DataTable();

                Script = "select h.ID,Concat(H.Nome,' - ',H.Valor_Custo,' ',H.TIpo_Custo) as Nome  ";
                Script += "from Habilidade_Summon HP inner join Habilidade H ";
                Script += "on H.ID = HP.IDHabilidade ";
                Script += "where HP.IDSummon = " + modelo.ID;
                

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaHabilidade);
                FechaConexao();

                foreach (DataRow item in TabelaHabilidade.Rows)
                {
                    habilidade_Model = new Habilidade_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = item["ID"].ToString(),
                    };
                }
                return TabelaHabilidade;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Habilidade_data.Carrega_Combo_Habilidade_summon:\n" + ex.Message);
            }
        }

        public Habilidade_Model Carrega_Habilidade(string IDHabilidade)
        {
            try
            {
                DataTable TabelaHabilidade = new DataTable();


                Script = "select * from Habilidade where ID = " + IDHabilidade;


                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaHabilidade);

                FechaConexao();

                foreach (DataRow item in TabelaHabilidade.Rows)
                {
                    habilidade_Model = new Habilidade_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        ID = item["ID"].ToString(),
                        TipoCusto = item["Tipo_Custo"].ToString(),
                        ValorCusto = Convert.ToInt32(item["Valor_Custo"]),
                        HIT = Convert.ToInt32(item["HIT"]),
                        Multiplicador = Convert.ToDouble(item["Multiplicador"]),
                        Atributo = item["Atributo"].ToString(),
                        TipoDano = item["Tipo_dano"].ToString(),
                        Alvo = item["Alvo"].ToString(),
                        CDA = Convert.ToInt16(item["CDA"]),
                        Efeito = item["Efeito"].ToString(),
                        CDSEfeito = Convert.ToInt32(item["CDS_Efeito"]),
                        Descricao = item["Descricao"].ToString(),
                        MOD_CDA = Convert.ToInt16(item["CDA"])
                    };
                }
                return habilidade_Model;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Habilidade_data.Carrega_Habilidade:\n" + ex.Message);
            }
        }

    }
}
