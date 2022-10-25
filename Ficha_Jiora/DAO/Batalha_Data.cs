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
    internal class Batalha_Data : Conexao

    {
        private string Script = "";
        private Batalha_Modelo batalha_modelo = new Batalha_Modelo();
        public DataTable Carrega_Combo_Alvo()
        {
            try
            {
                DataTable TabelaAlvo = new DataTable();

                Script = "select Nome from Alvo ";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaAlvo);
                FechaConexao();

                foreach (DataRow item in TabelaAlvo.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        Nome = item["Nome"].ToString()
                        
                    };
                }
                return TabelaAlvo;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Alvo:\n" + ex.Message);
            }
        }

        public DataTable Carrega_Combo_Elementos()
        {
            try
            {
                DataTable TabelaElementos = new DataTable();

                Script = "select * from ELEMENTOS where ATIVO = 1 ";
                Script += "order by Nome";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaElementos);
                FechaConexao();

                foreach (DataRow item in TabelaElementos.Rows)
                {
                    batalha_modelo = new Batalha_Modelo()
                    {
                        NomeElementos = item["Nome"].ToString()

                    };
                }
                return TabelaElementos;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Batalha_Data.Carrega_Combo_Elementos:\n" + ex.Message);
            }
        }
    }
}
