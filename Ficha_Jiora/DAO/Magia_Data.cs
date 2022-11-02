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

        public string RetornaDescricaoMagiaAntiga(string Elemento, int Rank, string alvo, string Categoria)
        {
            try
            {
                Script = "select " + Elemento + " from magias_antigas";
                Script += " where rank = " + Rank;
                Script += " AND alvo = '" + alvo + "'";
                Script += " AND Tipo = '" + Categoria + "'";
                

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                Retorno = select.ExecuteScalar().ToString();

                return Retorno;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Magia_Data.RetornaDescricaoMagiaAntiga: " + ex.Message);
            }
        }
    }
}
