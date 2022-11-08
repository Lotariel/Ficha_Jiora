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
    internal class Elemento_Data : Conexao
    {
        private string Script = "";
        public void ResetaElementoMod_all()
        {
            try
            {
                Script = "update Personagem ";
                Script += "set Mod_res_fire =0,Mod_res_ice = 0,Mod_res_wind = 0,";
                Script += "Mod_res_earth = 0,Mod_res_thunder =0,Mod_res_water = 0,";
                Script += "Mod_res_light =0,Mod_res_shadow = 0";

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Elemento_Data.ResetaElementoMod_all: " + ex.Message);
            }
        }

        public void ResetaElementoMod(string ID)
        {
            try
            {
                Script = "update Personagem ";
                Script += "set Mod_res_fire =0,Mod_res_ice = 0,Mod_res_wind = 0,";
                Script += "Mod_res_earth = 0,Mod_res_thunder =0,Mod_res_water = 0,";
                Script += "Mod_res_light =0,Mod_res_shadow = 0 ";
                Script += "where ID =" + ID;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro em Elemento_Data.ResetaElementoMod: " + ex.Message);
            }
        }

        public void AumentaElementoMod(string ID, string Coluna, int valor)
        {
            try
            {
                ResetaElementoMod(ID);

                Script = "update Personagem ";
                Script += "set " + Coluna + " = " + valor;
                Script += " where ID =" + ID;

                SqlCommand update = new SqlCommand(Script, AbreConexao());

                update.ExecuteNonQuery();

                FechaConexao();
            }
            catch (Exception ex)
            {
               throw new Exception("Erro em Elemento_Data.AumentaElementoMod: " + ex.Message);
            }
        }
    }
}
