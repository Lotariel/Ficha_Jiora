using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;


namespace Ficha_Jiora.DAO
{
    internal class Magia_Data : Conexao
    {
        private string Script = "";
        private string Retorno = "";

        public MagiaAntiga_Model RetornaDescricaoMagiaAntiga(string Elemento, int Rank, string alvo, string Categoria)
        {
            try
            {
                DataTable TabelaMagiaAntiga = new DataTable();
                MagiaAntiga_Model  magia_a = new MagiaAntiga_Model();

                Script = "select " + Elemento + ",qntd_dado,custo,mult_dado,multiplicador from magias_antigas";
                Script += " where rank = " + Rank;
                Script += " AND alvo = '" + alvo + "'";
                Script += " AND Tipo = '" + Categoria + "'";

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
    }
}
