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
        private string DadosConexao = @"Data Source=25.52.32.89\localdb,1433;Password=lotariel;User ID=sa;Initial Catalog=jiora_2023;Min Pool Size=5;Max Pool Size=10000; Connect Timeout=5;";
        //private string DadosConexao = @"Data Source=Lotariel_Machine\localdb,1433;Password=lotariel;User ID=sa;Initial Catalog=jiora_2023;Min Pool Size=5;Max Pool Size=10000; Connect Timeout=5;";
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

        
    }
}
