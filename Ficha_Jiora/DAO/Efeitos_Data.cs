using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ficha_Jiora.Model;
using System.Data;
using System.Security;

namespace Ficha_Jiora.DAO
{
    internal class Efeitos_Data : Conexao
    {

        private Efeitos_Model efeitos_Model = new Efeitos_Model();
        private string Script = "";

        public Efeitos_Model Carrega_Efeito(string IDPersonagem)
        {
            try
            {
                DataTable TabelaEfeito = new DataTable();
                efeitos_Model = new Efeitos_Model();
                Script = "select * from controle_efeitos where idpersonagem = " + "'" + IDPersonagem + "'";

                SqlDataAdapter select = new SqlDataAdapter(Script, AbreConexao());

                select.Fill(TabelaEfeito);
                FechaConexao();

                foreach (DataRow item in TabelaEfeito.Rows)
                {
                    efeitos_Model = new Efeitos_Model()
                    {
                        IDPersonagem = Convert.ToInt16(item["IDpersonagem"]),
                        Elemento_Encantado = item["Elemento_Encantado"].ToString(),
                        Turnos_Encantamento = Convert.ToInt16(item["Turnos_encantamento"]),
                        Paralyze = Convert.ToInt16(item["paralyze"]),
                        Confuse = Convert.ToInt16(item["confuse"]),
                        Burn = Convert.ToInt16(item["burn"]),
                        Poison = Convert.ToInt16(item["poison"]),
                        Frozen = Convert.ToInt16(item["frozen"]),
                        Silence = Convert.ToInt16(item["silence"]),
                        Blind = Convert.ToInt16(item["blind"]),
                        Charm = Convert.ToInt16(item["charm"])
                    };
                }
                return efeitos_Model;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro em Efeitos_Data.Carrega_Efeito:\n" + ex.Message);
            }
        }

        public void AtivarEfeito(string Coluna, string IDpersonagem)
        {
            try
            {
                Script = "update Personagem set " + Coluna + " = 1 where ID = " + IDpersonagem;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Efeitos_Data.AtivarEfeito:\n" + ex.Message);
            }
        }
        public void DesativarEfeito(string Coluna, string IDpersonagem)
        {
            try
            {
                Script = "update Personagem set " + Coluna + " = 0 where ID = " + IDpersonagem;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Efeitos_Data.DesativarEfeito:\n" + ex.Message);
            }
        }

        public void AdicionaTurnos(string Coluna, int Turnos, string IDpersonagem)
        {
            try
            {
                Script = "update Controle_Efeitos set " + Coluna + " = " + Turnos + " where IDpersonagem = " + IDpersonagem;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Efeitos_Data.AdicionaTurnos:\n" + ex.Message);
            }
        }

        public void ReduzTurnos(string Coluna, int Turnos, string IDpersonagem)
        {
            try
            {
                Script = "update Controle_Efeitos set " + Coluna + " = " + Turnos + " where IDpersonagem = " + IDpersonagem;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Efeitos_Data.ReduzTurnos:\n" + ex.Message);
            }
        }

        public void AdicionaEncantamento(string NomeElemento, int Turnos, string IDpersonagem)
        {
            try
            {
                Script = "update Controle_Efeitos set elemento_encaNtado = '" + NomeElemento + "',";
                Script += "turnos_encantamento =" + Turnos + " where IDpersonagem = " + IDpersonagem;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Efeitos_Data.AdicionaEncantamento:\n" + ex.Message);
            }
        }
    }
}
