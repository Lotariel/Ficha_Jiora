using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Ficha_Jiora.Model;
using System.Net;

namespace Ficha_Jiora.DAO
{
    internal class Log_Data : Conexao
    {

        private string Script = "";

        public void InsertLog(string nome, string action)
        {
            try
            {
                if (nome == "Raktharof La'ana")
                {
                    nome = "Raktharof";
                }
                
                Script = "insert into log_ficha (usuario,acao,data) ";
                Script += "values('" + nome + "','" + action + "','" + DateTime.Now + "')";

                SqlCommand insert = new SqlCommand(Script, AbreConexao());

                insert.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("\nFalha ao gravar o log\n" + ex.Message);
            }
        }

        public DataTable Carrega_Log(string nomepersonagem)
        {
            try
            {
                if (nomepersonagem == "Raktharof La'ana")
                {
                    nomepersonagem = "Raktharof";
                }

                DataTable TabelaLog = new DataTable();
                Log_Model log_model = new Log_Model();                

                Script = "select top 30 usuario as Nome,acao as 'Ação',Data from Log_ficha where usuario ='" + nomepersonagem + "'";
                Script += " order by CONVERT(datetime, data) desc";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaLog);

                FechaConexao();

                foreach (DataRow item in TabelaLog.Rows)
                {
                    log_model = new Log_Model
                    {
                        Nome = item["Nome"].ToString(),
                        Acao = item["Ação"].ToString(),
                        Data = item["Data"].ToString()
                    };
                }

                return TabelaLog;

            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Log_Data.Carrega_Log:\n" + ex.Message);
            }
        }


    }
}
