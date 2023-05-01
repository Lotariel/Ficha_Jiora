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

        public string Roupa_Equipada(string ID_PERSONAGEM)
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
                throw new Exception("Erro em Roupas_Data.Roupa_Equipada " + ex.Message);
            }
        }

        public Roupas_Model Carrega_Roupa_Equipada(string IdRoupa)
        {
            try
            {
                DataTable Tabela = new DataTable();

                script = "select * from Roupas where ID =@id";

                using (SqlConnection conn = AbreConexao())
                {
                    SqlCommand cmd = new SqlCommand(script, conn);

                    cmd.Parameters.AddWithValue("id", IdRoupa);

                    SqlDataAdapter select = new SqlDataAdapter(cmd);

                    select.Fill(Tabela);
                    FechaConexao();

                    foreach (DataRow item in Tabela.Rows)
                    {
                        roupas_Model = new Roupas_Model
                        {
                            ID = Convert.ToInt32(item["ID"]),
                            Nome = item["Nome"].ToString(),
                            Imagem = item["imagem"].ToString(),
                            Descricao = item["descricao"].ToString(),
                            Defesa = Convert.ToInt32(item["Defesa"]) + Convert.ToInt32(item["Defesa_Mod"]),
                            Resistencia = Convert.ToInt32(item["Resistencia"]) + Convert.ToInt32(item["Resistencia_Mod"]),
                            SlotCore = Convert.ToInt32(item["SlotCore"])
                        };
                    }
                    return roupas_Model;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Roupas_Data.Carrega_Roupa_Equipada:\n" + ex.Message);
            }
        }


        public DataTable Carrega_Combo_Roupa(string idpersonagem)
        {
            try
            {
                DataTable Tabela = new DataTable();

                script = "select ID,CONCAT(r.Nome,'') as info from Roupas R inner join Roupa_Personagem RP ";
                script += "on R.ID = RP.IDRoupa where RP.Equipado = 0 and RP.IDPersonagem = @iD";

                using (SqlConnection conn = AbreConexao())
                {
                    SqlCommand cmd = new SqlCommand(script, conn);
                    cmd.Parameters.AddWithValue("iD", idpersonagem);

                    SqlDataAdapter select = new SqlDataAdapter(cmd);

                    select.Fill(Tabela);
                    FechaConexao();

                    foreach (DataRow item in Tabela.Rows)
                    {
                        roupas_Model = new Roupas_Model()
                        {
                            Info = item["info"].ToString(),
                            ID = Convert.ToInt16(item["ID"])
                        };
                    }
                    return Tabela;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Roupa_Data.Carrega_Combo_Roupa:\n" + ex.Message);
            }
        }

        public void TrocarRoupa(string iDAtual, string iDNovo)
        {
            try
            {
                using (SqlConnection conn = AbreConexao())
                {
                    script = "update Roupa_Personagem set Equipado = 0 where IDRoupa = @idatual";

                    SqlCommand update01 = new SqlCommand(script, conn);
                    update01.Parameters.AddWithValue("idatual", iDAtual);

                    update01.ExecuteNonQuery();

                    script = "update Roupa_Personagem set Equipado = 1 where IDRoupa = @idnovo";

                    SqlCommand update02 = new SqlCommand(script, conn);
                    update02.Parameters.AddWithValue("idnovo", iDNovo);

                    update02.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Roupa_Data.TrocarRoupa:\n" + ex.Message);
            }
        }

        public void DefesaUP(double Valor, string ID)
        {
            try
            {
                using (SqlConnection conn = AbreConexao())
                {
                    script = "UPDATE Roupas set defesa = @valor where ID = @id";

                    SqlCommand update = new SqlCommand(script, conn);

                    update.Parameters.Add(new SqlParameter("@valor", Valor));
                    update.Parameters.Add(new SqlParameter("@id", ID));

                    update.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Roupa_Data.DefesaUP:\n" + ex.Message);
            }
        }

        public void ResistenciaUP(int Valor, string ID)
        {
            try
            {
                using (SqlConnection conn = AbreConexao())
                {
                    script = "UPDATE Roupas set resistencia = @valor where ID = @id";

                    SqlCommand update = new SqlCommand(script, conn);

                    update.Parameters.Add(new SqlParameter("@valor", Valor));
                    update.Parameters.Add(new SqlParameter("@id", ID));

                    update.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em ResistenciaUP.DefesaUP:\n" + ex.Message);
            }
        }

    }
}
