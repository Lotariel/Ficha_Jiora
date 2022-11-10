using Ficha_Jiora.Control;
using Ficha_Jiora.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ficha_Jiora.View
{
    public partial class Informacoes : Form
    {
        private Personagem_Model personagem_Model = new Personagem_Model();
        private Personagem_Control personagem_Control = new Personagem_Control();
        private Estigma_Control estigma_Control = new Estigma_Control();
        public Informacoes()
        {
            InitializeComponent();
            
        }
        public string IDPersonagem { get; set; }
        private void Informacoes_Load(object sender, EventArgs e)
        {
            Carrega_Personagem();
            Carrega_tela();
        }
        private void Carrega_tela()
        {
            
            lbl_res_fire.Text = personagem_Model.Res_Fire + " %";
            lbl_res_water.Text = personagem_Model.Res_Water + " %";
            lbl_res_ice.Text = personagem_Model.Res_Ice + " %";
            lbl_res_wind.Text = personagem_Model.Res_Wind + " %";
            lbl_res_earth.Text = personagem_Model.Res_Earth + " %";
            lbl_res_thunder.Text = personagem_Model.Res_Thunder + " %";
            lbl_res_light.Text = personagem_Model.Res_Light + " %";
            lbl_res_shadow.Text = personagem_Model.Res_Shadow + " %";
            lbl_res_burn.Text = personagem_Model.Res_Burn + " %";
            lbl_res_frozen.Text = personagem_Model.Res_Fronze + " %";
            lbl_res_silence.Text = personagem_Model.Res_Silence + " %";
            lbl_res_confuse.Text = personagem_Model.Res_Confuse + " %";
            lbl_res_paralyze.Text = personagem_Model.Res_Paralyze + " %";
            lbl_res_poison.Text = personagem_Model.Res_Poison + " %";
            lbl_res_blind.Text = personagem_Model.Res_Blind + " %";
            lbl_res_charm.Text = personagem_Model.Res_Charm + " %";            
            img_stigma.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Estigma\\" + personagem_Model.EstigmaImagem);
            if (Convert.ToInt16(personagem_Model.ID) < 5)
            {
                int nivel1 = estigma_Control.GetNivel("1", personagem_Model.ID);
                int nivel2 = estigma_Control.GetNivel("2", personagem_Model.ID);
                int nivel3 = estigma_Control.GetNivel("3", personagem_Model.ID);
                int nivel4 = estigma_Control.GetNivel("4", personagem_Model.ID);

                lbl_estigma_nome01.Text = estigma_Control.GetNome(nivel1, "1", IDPersonagem) + ":";
                lbl_estigma_desc01.Text = estigma_Control.GetDescricao(nivel1, "1", IDPersonagem);
                lbl_estigma_nome02.Text = estigma_Control.GetNome(nivel2, "2", IDPersonagem) + ":";
                lbl_estigma_desc02.Text = estigma_Control.GetDescricao(nivel2, "2", IDPersonagem);
                lbl_estigma_nome03.Text = estigma_Control.GetNome(nivel3, "3", IDPersonagem) + ":";
                lbl_estigma_desc03.Text = estigma_Control.GetDescricao(nivel3, "3", IDPersonagem);
                lbl_estigma_nome04.Text = estigma_Control.GetNome(nivel4, "4", IDPersonagem) + ":";
                lbl_estigma_desc04.Text = estigma_Control.GetDescricao(nivel4, "4", IDPersonagem);
            }
            else
            {
                lbl_estigma_nome01.Text = "";
                lbl_estigma_desc01.Text = "";
                lbl_estigma_nome02.Text = "";
                lbl_estigma_desc02.Text = "";
                lbl_estigma_nome03.Text = "";
                lbl_estigma_desc03.Text = "";
                lbl_estigma_nome04.Text = "";
                lbl_estigma_desc04.Text = "";
            }

            if (personagem_Model.NomeEstigma != "")
            {
                lbl_estigma_nome01.Visible = true;
                lbl_estigma_nome02.Visible = true;
                lbl_estigma_nome03.Visible = true;
                lbl_estigma_nome04.Visible = true;
                lbl_estigma_desc01.Visible = true;
                lbl_estigma_desc02.Visible = true;
                lbl_estigma_desc03.Visible = true;
                lbl_estigma_desc04.Visible = true;
            }
            else
            {
                lbl_estigma_nome01.Visible = false;
                lbl_estigma_nome02.Visible = false;
                lbl_estigma_nome03.Visible = false;
                lbl_estigma_nome04.Visible = false;
                lbl_estigma_desc01.Visible = false;
                lbl_estigma_desc02.Visible = false;
                lbl_estigma_desc03.Visible = false;
                lbl_estigma_desc04.Visible = false;
            }

        }
        private void Carrega_Personagem()
        {
            personagem_Model = personagem_Control.Carrega_Personagem(IDPersonagem);
        }

        private void img_fire_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_fire, "Resistência a Fogo");
        }

        private void img_ice_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_ice, "Resistência a Gelo");
        }

        private void img_wind_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_wind, "Resistência a Vento");
        }

        private void img_earth_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_earth, "Resistência a Terra");
        }

        private void img_thunder_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_thunder, "Resistência a Trovão");
        }

        private void img_water_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_water, "Resistência a Água");
        }

        private void img_light_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_light, "Resistência a Luz");
        }

        private void img_shadow_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_shadow, "Resistência a Escuridão");
        }

        private void img_burn_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_burn, "Resistência a Burn");
        }

        private void img_frozen_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_frozen, "Resistência a Frozen");
        }

        private void img_silence_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_silence, "Resistência a Silence");
        }

        private void img_confuse_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_confuse, "Resistência a Confuse");
        }

        private void img_paralyze_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_paralyze, "Resistência a Paralyze");
        }

        private void img_posion_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_posion, "Resistência a Poison");
        }

        private void img_blind_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_blind, "Resistência a Blind");
        }

        private void img_charm_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_charm, "Resistência a Charm");
        }

        private void img_stigma_MouseHover(object sender, EventArgs e)
        {
            string nomeestigma = personagem_Model.NomeEstigma;
            if (nomeestigma != "")
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(img_stigma, "Estigma da " + nomeestigma);

            }
        }

        
    }
}
