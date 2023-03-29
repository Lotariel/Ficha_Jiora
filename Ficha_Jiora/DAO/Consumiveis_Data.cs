using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;

namespace Ficha_Jiora.DAO
{
    internal class Consumiveis_Data : Conexao
    {
        private Consumiveis_Model consumiveis_Model;
        private string Script = "";

        public Consumiveis_Model Carrega_Consumivel(string IDConsumivel, string idpersonagem)
        {
            try
            {
                DataTable TabelaConsumivel = new DataTable();
                consumiveis_Model = new Consumiveis_Model();
                Script = "select * from consumiveis_personagem a,consumiveis b ";
                Script += "where a.idcosumiveis = b.ID and a.idpersonagem = " + idpersonagem + " and b.ID = " + IDConsumivel;

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaConsumivel);
                FechaConexao();

                foreach (DataRow item in TabelaConsumivel.Rows)
                {
                    consumiveis_Model = new Consumiveis_Model()
                    {
                        ID = Convert.ToInt16(item["ID"]),
                        Nome = item["Nome"].ToString(),
                        Descricao = item["Descricao"].ToString(),
                        preco = Convert.ToDouble(item["Preco"]),
                        Quantidade = Convert.ToInt16(item["Quantidade"]),

                    };
                }
                return consumiveis_Model;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Consumiveis_Data.Carrega_Consumivel:\n" + ex.Message);
            }
        }

        public void Aumenta_Quantidade_Consumivel(string idconsumivel, string idpersonagem)
        {
            try
            {
                Script = "update consumiveis_personagem set quantidade = quantidade + 1 ";
                Script += "where idcosumiveis =@idcon  and idpersonagem = @idper";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.Parameters.Add(new SqlParameter("idcon", idconsumivel));
                update.Parameters.Add(new SqlParameter("idper", idpersonagem));
                update.ExecuteNonQuery();

                FechaConexao();

            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Consumiveis_Data.Aumenta_Quantidade_Consumivel:\n" + ex.Message);
            }
        }

        public void Reduz_Quantidade_Consumivel(string idconsumivel, string idpersonagem)
        {
            try
            {
                Script = "update consumiveis_personagem set quantidade = quantidade - 1 ";
                Script += "where idcosumiveis =@idcon  and idpersonagem = @idper";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.Parameters.Add(new SqlParameter("idcon", idconsumivel));
                update.Parameters.Add(new SqlParameter("idper", idpersonagem));
                update.ExecuteNonQuery();

                FechaConexao();

            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Consumiveis_Data.Reduz_Quantidade_Consumivel:\n" + ex.Message);
            }
        }

        public DataTable Carrega_Combo_Consumiveis(string idpersonagem)
        {
            try
            {
                DataTable tabelaitem = new DataTable();

                Script = "select Concat(nome, ',' , quantidade,'x') as list,id from consumiveis_personagem a,consumiveis b ";
                Script += "where a.idcosumiveis = b.ID and a.quantidade > 0 and a.idpersonagem = " + idpersonagem;

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(tabelaitem);
                FechaConexao();

                foreach (DataRow item in tabelaitem.Rows)
                {
                    consumiveis_Model = new Consumiveis_Model()
                    {
                        Nome = item["list"].ToString(),
                        ID = Convert.ToInt32(item["id"])
                    };
                }
                return tabelaitem;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Consumiveis_Data.Carrega_Combo_Consumiveis:\n" + ex.Message);
            }
        }
    }
}
