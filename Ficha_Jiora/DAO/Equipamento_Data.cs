using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using System.Data.SqlClient;

namespace Ficha_Jiora.DAO
{
    internal class Equipamento_Data: Conexao
    {
        private string Script = "";
        private string Retorno = "";

        public string Arma_Equipada (string ID_PERSONAGEM)
        {
            try
            {
                Script = "SELECT ID_EQUIPAMENTO FROM EQUIP_PERSONAGEM";
                Script += " WHERE ID_PERSONAGEM =" + ID_PERSONAGEM;
                Script += " AND EQUIPADO = 1";

                SqlCommand select = new SqlCommand(Script,AbreConexao());

                Retorno = select.ExecuteScalar().ToString();

                return Retorno;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Equipamento_Data.Arma_Equipada " + ex.Message);
            }
        }
    }
    
}
