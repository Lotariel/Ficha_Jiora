using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha_Jiora.Model;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Ficha_Jiora.DAO
{
    internal class Equipamento_Data: Conexao
    {
        Equipamento_Model equipamento_Model = new Equipamento_Model();
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

        public DataTable Carrega_Combo_Arma(string idpersonagem)
        {
            try
            {
                DataTable TabelaArma = new DataTable();

                Script = "select E.ID,E.NOME from EQUIPAMENTO E inner join equip_personagem EP  ";
                Script += "on E.ID = EP.ID_EQUIPAMENTO WHERE EQUIPADO =0 and EP.ID_PERSONAGEM = "+ idpersonagem;               

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaArma);
                FechaConexao();

                foreach (DataRow item in TabelaArma.Rows)
                {
                    equipamento_Model = new Equipamento_Model()
                    {
                        NOME = item["Nome"].ToString(),
                        ID = Convert.ToInt16(item["ID"])
                    };
                }
                return TabelaArma;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Equipamento_Data.Carrega_Combo_Arma:\n" + ex.Message);
            }
        }

        public bool Valida_Troca_de_Arma(string idpersonagem)
        {
            try
            {
                Script = "select count(1) from EQUIP_PERSONAGEM ";
                Script += "where EQUIPADO = 0 and ID_PERSONAGEM = " + idpersonagem;

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                if (Convert.ToInt32(select.ExecuteScalar()) > 0)
                {                    
                    FechaConexao();
                    return true;
                }
                else
                {
                    FechaConexao();
                    return false;
                }       
                
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Equipamento_Data.Valida_Troca_de_Arma:\n" + ex.Message);
            }
        }


        public void Troca_Arma_Equipada(string IDArmaEquipada,int idarmaNova, string NomeAtaqueAtivo, string NomeAtaqueNovo)
        {
            try
            {
                
                Script = "UPDATE EQUIP_PERSONAGEM SET EQUIPADO = 0 WHERE ID_EQUIPAMENTO = " + IDArmaEquipada;

                SqlCommand desequipar = new SqlCommand(Script,AbreConexao());
                desequipar.ExecuteNonQuery();

                Script = "UPDATE EQUIP_PERSONAGEM SET EQUIPADO = 1 WHERE ID_EQUIPAMENTO = " + idarmaNova;

                SqlCommand equipar = new SqlCommand(Script, AbreConexao());
                equipar.ExecuteNonQuery();

                FechaConexao();

                Troca_Ataque(NomeAtaqueAtivo,NomeAtaqueNovo);

            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Equipamento_Data.Troca_Arma_Equipada:\n" + ex.Message);
            }
        }

        private void Troca_Ataque(string NomeAtaqueAtivo,string NomeAtaqueNovo)
        {
            try
            {

                Script = "update Ataques set Ativo = 0 where Nome = '" + NomeAtaqueAtivo + "'";

                SqlCommand desequipar2 = new SqlCommand(Script, AbreConexao());
                desequipar2.ExecuteNonQuery();

                Script = "update Ataques set Ativo = 1 where Nome = '" + NomeAtaqueNovo + "'";

                SqlCommand equipar2 = new SqlCommand(Script, AbreConexao());
                equipar2.ExecuteNonQuery();

                FechaConexao();

            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Equipamento_Data.Troca_Ataque:\n" + ex.Message);
            }
        }


    }
    
}
