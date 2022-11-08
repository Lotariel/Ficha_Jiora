using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ficha_Jiora.Control;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.View
{
    public partial class Tela_Do_Mestre : Form
    {
        private Personagem_Control personagem_Control = new Personagem_Control();
        private Personagem_Model personagem_Model = new Personagem_Model();
        
        public Tela_Do_Mestre(string id)
        {
            Carrega_Personagem(id);
        }

        public Tela_Do_Mestre()
        {
            InitializeComponent();
        }

        private void btn_aplicar_atrib_Click(object sender, EventArgs e)
        {
            Somar();
        }
        private string GetID(string nome)
        {
          return personagem_Control.GetID(nome);
        }

       private Personagem_Model Carrega_Personagem(string ID)
        {
            return personagem_Model = personagem_Control.Carrega_Personagem(ID);
        }
        private void Somar()
        {
            string IDPersonagem = GetID(cbb_persona_atrib.Text);
            //Carrega_Personagem(IDPersonagem);
            Batalha_Control batalha_Control = new Batalha_Control(personagem_Model);
            int hp =personagem_Model.HPAtual;
            if (cbb_atributo.Text == "HP")
            {
                batalha_Control.CurarHPAtual(IDPersonagem, Convert.ToInt32(txt_valor_atrib.Text));
            }
            if (cbb_atributo.Text == "MP")
            {
                batalha_Control.CurarMPAtual(IDPersonagem, Convert.ToInt32(txt_valor_atrib.Text));
            }
        }
    }
}
