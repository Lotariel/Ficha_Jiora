using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ficha_Jiora.Control;
using Ficha_Jiora.Model;

namespace Ficha_Jiora.View
{
    public partial class DataDrain_View : Form
    {
        public DataDrain_View()
        {
            InitializeComponent();
        }

        public string idpersonagem { get; set; }
        private void btn_carregar_Click(object sender, EventArgs e)
        {
            Personagem_Control personagem = new Personagem_Control();
            Personagem_Model personagem_Model = new Personagem_Model();
            personagem_Model = personagem.Carrega_Personagem(idpersonagem);
            Batalha_Control batalha = new Batalha_Control(personagem_Model);
            batalha.CurarMPAtual(idpersonagem, Convert.ToInt32(txt_valor.Text));
            this.Close();
        }
    }
}
