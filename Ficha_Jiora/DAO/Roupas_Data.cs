using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;
using System.Drawing.Printing;

namespace Ficha_Jiora.DAO
{
    internal class Roupas_Data : Conexao
    {
        private Roupas_Model roupas_Model = new Roupas_Model();
        private string script = "";

        private string Roupa_Equipada(string ID_PERSONAGEM)
        {
            try
            {
                using (SqlConnection conn = AbreConexao())
                {
                    script = "select idroupa from roupa_personagem where equipado = 1 and idpersonagem = @id";

                    SqlCommand select = new SqlCommand(script, conn);

                    select.Parameters.AddWithValue("@id", ID_PERSONAGEM);

                    string retorno = select.ExecuteScalar()?.ToString();

                    return retorno ?? "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em Equipamento_Data.Arma_Equipada " + ex.Message);
            }
        }

        
    }
}
