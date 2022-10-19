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
                Script = "select * from personagem where id = " + "'" + IDPersonagem + "'";

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
                        Classe = GetClasse(item["job_id"].ToString()),
                        PontosPericia = Convert.ToInt32(item["Pontos_Pericia"]),
                        Olhos = item["Olhos"].ToString(),
                        Cabelo = item["Cabelo"].ToString(),
                        Altura = item["Altura"].ToString() + " m",
                        Peso = item["Peso"].ToString(),
                        Nascimento = item["Nascimento"].ToString(),
                        EXPAtual = Convert.ToInt32(item["EXP_ATUAL"]),
                        Ativo = Convert.ToBoolean(item["Ativo"]),
                        Sexo = item["Sexo"].ToString(),
                        Idade = item["idade"].ToString(),
                        Iniciativa = Convert.ToInt32(item["iniciativa"]),
                        Turnos = Convert.ToInt32(item["Turnos"]),
                        TextoMestre = item["Texto_Mestre"].ToString(),
                        Anotacoes = item["anotacoes"].ToString(),
                        Forca = Convert.ToInt32(item["forca"]) + Convert.ToInt32(item["mod_forca"]),
                        Vitalidade = Convert.ToInt32(item["vitalidade"]) + Convert.ToInt32(item["mod_vitalidade"]),
                        Foco = Convert.ToInt32(item["foco"]) + Convert.ToInt32(item["mod_foco"]),
                        Velocidade = Convert.ToInt32(item["velocidade"]) + Convert.ToInt32(item["mod_velocidade"]),
                        Magia = Convert.ToInt32(item["magia"]) + Convert.ToInt32(item["mod_magia"]),
                        Aura = Convert.ToInt32(item["aura"]) + Convert.ToInt32(item["mod_aura"]),
                        ModForca = Convert.ToInt32(item["mod_forca"]),
                        ModVitalidade = Convert.ToInt32(item["mod_vitalidade"]),
                        ModFoco = Convert.ToInt32(item["Mod_foco"]),
                        ModMagia = Convert.ToInt32(item["Mod_magia"]),
                        ModAura = Convert.ToInt32(item["Mod_aura"]),
                        Defesa = Convert.ToInt32(item["Defesa"]) + Convert.ToInt32(item["mod_Defesa"]),
                        Resistencia = Convert.ToInt32(item["Resistencia"]) + Convert.ToInt32(item["mod_Resistencia"]),
                        ModResistenca = Convert.ToInt32(item["Mod_resistencia"]),
                        ModDefesa = Convert.ToInt32(item["mod_defesa"]),
                        CDS_Critico = Convert.ToInt32(item["cds_critico"]) + Convert.ToInt32(item["mod_cds_critico"]),
                        Mod_CDSCritico = Convert.ToInt32(item["mod_cds_critico"]),
                        Valor_Critico = Convert.ToInt32(item["valor_critico"]) + Convert.ToInt32(item["mod_valor_critico"]),
                        Mod_ValorCritico = Convert.ToInt32(item["mod_valor_critico"]),
                        Especial = Convert.ToInt32(item["Especial"]),
                        HPAtual = Convert.ToInt32(item["Hpatual"]),
                        HPMax = Convert.ToInt32(item["HPMax"]),
                        MPAtual = Convert.ToInt32(item["MPatual"]),
                        MPMax = Convert.ToInt32(item["MPMAx"]),
                        Res_Water = Convert.ToInt32(item["res_water"]) + Convert.ToInt32(item["Mod_res_water"]),
                        Res_Fire = Convert.ToInt32(item["res_fire"]) + Convert.ToInt32(item["mod_res_fire"]),
                        Res_Ice = Convert.ToInt32(item["res_ice"]) + Convert.ToInt32(item["mod_res_ice"]),
                        Res_Thunder = Convert.ToInt32(item["res_thunder"]) + Convert.ToInt32(item["mod_res_thunder"]),
                        Res_Wind = Convert.ToInt32(item["res_wind"]) + Convert.ToInt32(item["mod_res_wind"]),
                        Res_Earth = Convert.ToInt32(item["res_earth"]) + Convert.ToInt32(item["mod_res_earth"]),
                        Res_Light = Convert.ToInt32(item["res_light"]) + Convert.ToInt32(item["mod_res_light"]),
                        Res_Shadow = Convert.ToInt32(item["res_shadow"]) + Convert.ToInt32(item["mod_res_shadow"]),
                        Mod_Res_Fire = Convert.ToInt32(item["mod_res_fire"]),
                        Mod_Res_Water = Convert.ToInt32(item["mod_res_water"]),
                        Mod_Res_Thunder = Convert.ToInt32(item["mod_res_thunder"]),
                        Mod_Res_Ice = Convert.ToInt32(item["mod_res_ice"]),
                        Mod_Res_Wind = Convert.ToInt32(item["mod_res_wind"]),
                        Mod_Res_Earth = Convert.ToInt32(item["mod_res_earth"]),
                        Mod_Res_Light = Convert.ToInt32(item["mod_res_light"]),
                        Mod_Res_Shadow = Convert.ToInt32(item["mod_res_shadow"]),
                        Res_Poison = Convert.ToInt32(item["res_posion"]),
                        Res_Burn = Convert.ToInt32(item["res_burn"]),
                        Res_Paralyze = Convert.ToInt32(item["res_paralyze"]),
                        Res_Confuse = Convert.ToInt32(item["res_confuse"]),
                        Res_Fronze = Convert.ToInt32(item["res_frozen"]),
                        Res_Silence = Convert.ToInt32(item["res_silence"]),
                        Res_Blind = Convert.ToInt32(item["res_blind"]),
                        Res_Charm = Convert.ToInt32(item["res_charm"]),
                        Poison_Ativo = Convert.ToBoolean(item["Poison_ativo"]),
                        Burn_Ativo = Convert.ToBoolean(item["Burn_ativo"]),
                        Frozen_Ativo = Convert.ToBoolean(item["Frozen_ativo"]),
                        Paralyze_Ativo = Convert.ToBoolean(item["Paralyze_ativo"]),
                        Confuse_Ativo = Convert.ToBoolean(item["Confuse_ativo"]),
                        Silence_Ativo = Convert.ToBoolean(item["silence_ativo"]),
                        Blind_Ativo = Convert.ToBoolean(item["Blind_ativo"]),
                        Charm_Ativo = Convert.ToBoolean(item["Charm_ativo"]),
                        Mod_Esquiva = Convert.ToInt32(item["mod_esquiva"]),
                        Mod_Precisao = Convert.ToInt32(item["mod_precisao"])
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
                Script = "select id from personagem where nome = '" + nome + "'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                FechaConexao();

                var resultado = select.ExecuteScalar();

                if (resultado != null)
                {
                    return resultado.ToString();
                }
                else
                {
                    throw new Exception("\nPersonagem '" + nome + "' não encontrado.");
                }

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
                Script = "select nome from job where id = '" + IDClasse + "'";

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                FechaConexao();

                return select.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Personagem_Data.GetClasse:\n" + ex.Message);
            }
        }

        public void Update_Personagem(string Coluna, int Valor, string ID)
        {
            try
            {
                Script = "UPDATE personagem set " + Coluna + " = '" + Valor + "' where ID = " + ID;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Personagem_Data.Update_Personagem:\n" + ex.Message);
            }
        }

        public int TotalAtributos(string ID)
        {
            try
            {
                Script = "select SUM(Forca + Vitalidade + Foco + Velocidade + Magia + aura) as total ";
                Script += "from Personagem ";
                Script += "where ID = " + ID;

                SqlCommand select = new SqlCommand(Script, AbreConexao());

                int valor = Convert.ToInt32(select.ExecuteScalar());

                FechaConexao();

                return valor;
            }
            catch (Exception ex)
            {

                throw new Exception("\nErro em Personagem_Data.TotalAtributos:\n" + ex.Message);
            }
        }
    }
}
