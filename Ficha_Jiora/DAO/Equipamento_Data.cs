using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using System.Data.SqlClient;
using System.Data;

namespace Ficha_Jiora.DAO
{
    internal class Equipamento_Data: Conexao
    {
        Equipamento_Model equipamento_Model;
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

        public Equipamento_Model Carrega_Arma_Equipada(string IDArma)
        {
            try
            {
                DataTable TabelaArma = new DataTable();
                equipamento_Model = new Equipamento_Model();
                Script = "select * from equipamento where id = " + "'" + IDArma + "'";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaArma);
                FechaConexao();

                foreach (DataRow item in TabelaArma.Rows)
                {
                    equipamento_Model = new Equipamento_Model()
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        NOME = item["Nome"].ToString(),
                        RANK = Convert.ToInt32(item["Rank"]),
                        ATRIBUTO = item["Atributo"].ToString(),
                        MULTIPLICADOR = Convert.ToInt32(item["Multiplicador"]),
                        QUANT_DADOS = Convert.ToInt32(item["quant_dados"]),
                        DADO = Convert.ToInt32(item["dado"]) * Convert.ToInt32(item["quant_dados"]),
                        EFEITO_1 = item["efeito_1"].ToString(),
                        EFEITO_2 = item["efeito_2"].ToString(),
                        EFEITO_3 = item["efeito_2"].ToString(),
                        IMAGEM = item["imagem"].ToString(),
                        DESCRICAO = item["descricao"].ToString(),

                    };
                }
                return equipamento_Model;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Equipamento_Data.Carrega_Arma_Equipada:\n" + ex.Message);
            }
        }
    }
    
}
