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
    internal class Item_Data : Conexao
    {
        private string script = "";
        private Item_Model model;
        public DataTable Carrega_Item(string IDPersonagem)
        {
            try
            {
                DataTable Tabela = new DataTable();


                script = "select a.quantidade,B.Nome,B.Descricao from item_personagem A,Items B ";
                script += "where a.iditem = b.ID and a.idpersonagem = @id and a.quantidade > 0";

                

                using (SqlConnection conn = AbreConexao())
                {

                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.AddWithValue("id", IDPersonagem);
                    SqlDataAdapter select = new SqlDataAdapter(cmd);

                    select.Fill(Tabela);

                    foreach (DataRow item in Tabela.Rows)
                    {
                        model = new Item_Model
                        {
                            Nome = item["Nome"].ToString(),
                            Quantidade = Convert.ToInt32(item["Quantidade"]),
                            Descricao = item["descricao"].ToString()
                        };
                    }
                }

                return Tabela;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Item_Data.Carrega_Item:\n" + ex.Message);
            }
        }
    }
}
