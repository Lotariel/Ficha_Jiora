using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.DAO
{
    internal class Pericia_Data : Conexao
    {
        private Pericia_Model pericia_Model = new Pericia_Model();
        private string Script = "";

        public DataTable Carrega_Pericia(string IDPersonagem)
        {
            try
            {
                DataTable TabelaPericia = new DataTable();
                pericia_Model = new Pericia_Model();
                Script = "select Nome,PontosAtual,'Realizar Teste' as name from PERICIAPERSONAGEM ";
                Script += "where idpersonagem = '" + IDPersonagem + "' and Nome != ''";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaPericia);
                FechaConexao();

                foreach (DataRow item in TabelaPericia.Rows)
                {
                    pericia_Model = new Pericia_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        Valor =Convert.ToInt32(item["PontosAtual"])
                    };
                }
                return TabelaPericia;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Pericia_Data.Carrega_Pericia:\n" + ex.Message);
            }
        }
    }
}
