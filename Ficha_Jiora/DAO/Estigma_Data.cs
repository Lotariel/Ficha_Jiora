using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Drawing;

namespace Ficha_Jiora.DAO
{
    internal class Estigma_Data : Conexao
    {
        private string Script = "";
        private string resultado = "";
        public string GetDescricao(string nivel, string grupo, string idpersonagem)
        {
            try
            {
                Script = "Select descricao from estigma ";
                Script += "where nivel ='" + nivel + "' ";
                Script += "and idpersonagem = '" + idpersonagem + "' ";
                Script += "and grupo ='" + grupo + "' ";
                Script += "and ativo = 'Ativo'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                resultado = select.ExecuteScalar().ToString();

                FechaConexao();

                return resultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Estigma_Data.GetDescricao " + ex.Message);
            }
        }
        public string GetNome(string nivel, string grupo, string idpersonagem)
        {
            try
            {
                Script = "Select nome from estigma ";
                Script += "where nivel ='" + nivel + "' ";
                Script += "and idpersonagem = '" + idpersonagem + "' ";
                Script += "and grupo ='" + grupo + "' ";
                Script += "and ativo = 'Ativo'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                resultado = select.ExecuteScalar().ToString();

                FechaConexao();

                return resultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Estigma_Data.GetNome " + ex.Message);
            }
        }
        public string GetTextoEvolucao(string nivel, string grupo, string idpersonagem)
        {
            try
            {
                Script = "Select descricao from Estigma_Texto ";
                Script += "where grupo ='" + grupo + "' ";
                Script += "and idpersonagem = '" + idpersonagem + "' ";
                Script += "and nivel = '" + nivel + "'";


                SqlCommand select = new SqlCommand(Script, AbreConexao());

                resultado = select.ExecuteScalar().ToString();

                FechaConexao();

                return resultado;


            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Estigma_Data.GetEvolucao " + ex.Message);
            }
        }
        public int GetNivel(string grupo, string idpersonagem)
        {
            try
            {
                Script = "Select nivel from Estigma ";
                Script += "where grupo ='" + grupo + "' ";
                Script += "and idpersonagem = '" + idpersonagem + "' ";
                Script += "and ativo = 'Ativo'";


                SqlCommand select = new SqlCommand(Script, AbreConexao());

                resultado = select.ExecuteScalar().ToString();

                FechaConexao();

                return Convert.ToInt32(resultado);


            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Estigma_Data.GetEvolucao " + ex.Message);
            }
        }
        public void AumentarPontosEstigma(int valor, string id)
        {
            try
            {
                Script = "Update personagem set pontos_estigma = " + valor + " where ID = " + id;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro em Estigma_Data.AumentarPontosEstigma: " + ex.Message);
            }
        }
        public void EvoluirPassiva(Personagem_Model personagem, int grupo)
        {
            try
            {
                int NivelAtual = GetNivel(grupo.ToString(), personagem.ID);
                int NovoNivel = NivelAtual + 1;

                Script = "Update estigma set ativo = 'Desativado' where IDpersonagem = " + personagem.ID;
                Script += " and grupo ='" + grupo + "'  and nivel = '" + NivelAtual + "'";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                Script = "Update estigma set ativo = 'Ativo' where IDpersonagem = " + personagem.ID;
                Script += " and grupo ='" + grupo + "'  and nivel = '" + NovoNivel + "'";

                update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Estigma_Data.AlterarPassiva: " + ex.Message);
            }
        }
    }
}
