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
    internal class Personagem_Data : Conexao
    {
        private Personagem_Model personagem_Model = new Personagem_Model();
        private string Script = "";

        public Personagem_Model Carrega_Personagem(string IDPersonagem)
        {
            try
            {
                DataTable TabelaPersonagem = new DataTable();
                personagem_Model = new Personagem_Model();
                Script = "select * from personagem where idpersonagem = " + "'" + IDPersonagem + "'";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaPersonagem);
                FechaConexao();

                foreach (DataRow item in TabelaPersonagem.Rows)
                {
                    personagem_Model = new Personagem_Model()
                    {
                        Nome = item["Nome"].ToString() + " " + item["Sobrenome"].ToString(),
                        Nivel = Convert.ToInt32(item["Nivel"]),
                        Imagem = item["imagem"].ToString(),
                        Classe = GetClasse(item["classeid"].ToString())
                    };
                }
                return personagem_Model;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Personagem_Data.Carrega_Personagem:\n" + ex.Message);
            }
        }

        public string GetID(string nome)
        {
            try
            {
                Script = "select idpersonagem from personagem where nome = '" + nome + "'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                FechaConexao();

                return select.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Personagem_Data.GetID:\n" + ex.Message);
            }
        }

        private string GetClasse(string IDClasse)
        {
            try
            {
                Script = "select nome from classe where idclasse = '" + IDClasse + "'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                FechaConexao();

                return select.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Personagem_Data.GetClasse:\n" + ex.Message);
            }
        }
    }
}
