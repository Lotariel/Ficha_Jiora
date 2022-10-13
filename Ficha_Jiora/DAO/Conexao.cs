using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;

namespace Ficha_Jiora.DAO
{
    internal class Conexao
    {
        private string DadosConexao = @"Data Source=25.52.32.100\localdb,1433;Password=lotariel;User ID=sa;Initial Catalog=jiora_2023;";
        public SqlConnection AbreConexao()
        {
			try
			{
                SqlConnection con = new SqlConnection(DadosConexao);
                con.Open();
                return con;
            }
			catch (Exception ex)
			{

				throw new Exception("\nConexao.AbreConexao \n"+ex.Message);
			}
        }

        public SqlConnection FechaConexao()
        {
            try
            {
                SqlConnection con = new SqlConnection(DadosConexao);
                con.Close();
                return con;
            }
            catch (Exception ex)
            {

                throw new Exception("\nConexao.FechaConexao \n" + ex.Message);
            }
        }

        public void InsertLog(string nome,string action)
        {
            try
            {
                string Script = "";
                Script = "insert into log_ficha (usuario,acao,data) ";
                Script += "values('" + nome + "','" + action + "','" + DateTime.Now + "')";

                SqlCommand insert = new SqlCommand(Script, AbreConexao());

                insert.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("\nFalha ao gravar o log\n"+ ex.Message);
            }
        }
    }
}
