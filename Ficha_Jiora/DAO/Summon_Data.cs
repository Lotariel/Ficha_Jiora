using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;

namespace Ficha_Jiora.DAO
{
    internal class Summon_Data : Conexao
    {
        private Summon_Model summon_Model = new Summon_Model();

        private string Script = "";


        public Summon_Model CarregaSummon(string summonId, string personagemId)
        {
            try
            {
                using (SqlConnection conn = AbreConexao())
                {
                    Script = "select * from summons where id = @summonId and mestreid = @personagemId";
                                        
                    SqlCommand cmd = new SqlCommand(Script, conn);

                    cmd.Parameters.AddWithValue("@summonId", summonId);
                    cmd.Parameters.AddWithValue("@personagemId", personagemId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count == 0)
                    {
                        return null;
                    }

                    Summon_Model summon = new Summon_Model();
                    DataRow row = table.Rows[0];
                    summon.ID = row.Field<int>("ID");
                    summon.MestreID = row.Field<int>("mestreid");
                    summon.Imagem = row.Field<string>("imagem");
                    summon.Nome = row.Field<string>("Nome");
                    summon.AtributoAtaque = row.Field<string>("AtaqueAtributo");
                    summon.ValorBaseAtaque = row.Field<int>("AtaqueValorBAse");
                    summon.Dado = row.Field<int>("dado");
                    summon.HPAtual = row.Field<int>("HPAtual");
                    summon.QuantidadeDado = row.Field<int>("QuantidadeDado");
                    summon.MaxHP = row.Field<decimal>("HpMax");
                    summon.TextoInvocacao = row.Field<string>("textoinvocacao");

                    return summon;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Summon_Data.Carrega_Summon:\n" + ex.Message);
            }
        }

        public int? GetIdSummons(string nome,string mestreid)
        {
            try
            {
                Script = "select id from Summons where Nome = @nome and MestreID =@mestreid";

                using (SqlConnection conn = AbreConexao())
                {
                    SqlCommand select = new SqlCommand(Script, conn);

                    select.Parameters.AddWithValue("nome",nome);
                    select.Parameters.AddWithValue("mestreid", mestreid);

                    object result = select.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Summon_Data.GetIdSummons:\n" + ex.Message);
            }
        }

        public void ReduzHp(Summon_Model summon_Model, int? valor)
        {
            try
            {
                Script = "update Summons set HPAtual = @valor where ID = @id";

                using (SqlConnection conn = AbreConexao())
                {
                    SqlCommand update = new SqlCommand(Script,conn);
                    update.Parameters.AddWithValue("@id",summon_Model.ID);
                    update.Parameters.AddWithValue("@valor", valor);

                    update.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Summon_Data.ReduzHp:\n" + ex.Message);
            }
        }
    }
}
