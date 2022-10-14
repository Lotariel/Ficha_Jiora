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
                Script = "select 'Realizar teste' as teste, Nome , [Chance de Sucesso(%)] as Valor, ";
                Script += "descricao as'Descrição','Salvar' as Salvar, id_pericia ";
                Script += "from periciapersonagem inner join pericia ";
                Script += "on periciapersonagem.id_pericia = pericia.id ";
                Script += "where id_personagem = " + IDPersonagem + " order by nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaPericia);
                FechaConexao();

                foreach (DataRow item in TabelaPericia.Rows)
                {
                    pericia_Model = new Pericia_Model()
                    {
                        Nome = item["Nome"].ToString(),
                        Valor = Convert.ToInt32(item["Valor"]),
                        Descricao = item["Descrição"].ToString()
                    };
                }
                return TabelaPericia;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Pericia_Data.Carrega_Pericia:\n" + ex.Message);
            }
        }

        public int TotalPontosPericia(string IDPersonagem)
        {
            try
            {
                Script = "select SUM([Chance de Sucesso(%)]) from PericiaPersonagem ";
                Script += "where ID_Personagem =" + IDPersonagem;

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                int resultado = Convert.ToInt32(select.ExecuteScalar());

                FechaConexao();

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Pericia_Data.TotalPontosPericia:\n" + ex.Message);
            }
        }

        public int ValorAtual(string NomePericia, string IDPersonagem)
        {
            try
            {
                Script = "select [Chance de Sucesso(%)]  from periciapersonagem ";
                Script += "inner join pericia on periciapersonagem.id_pericia = pericia.id ";
                Script += "where id_personagem =  " + IDPersonagem;
                Script += " AND nome = '" + NomePericia + "'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                int resultado = Convert.ToInt32(select.ExecuteScalar());

                FechaConexao();

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Pericia_Data.TotalPontosPericia:\n" + ex.Message);
            }
        }

        public void AtualizarValorPericia(int NovoValor,string IDPersonagem, string idpericia)
        {
            try
            {
                Script = "Update PericiaPersonagem set [Chance de Sucesso(%)] ="+ NovoValor;
                Script += " where id_personagem = " + IDPersonagem;
                Script += " and ID_Pericia = " + idpericia;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Pericia_Data.AtualizarValorPericia:\n" + ex.Message);
            }
        }
    }
}
