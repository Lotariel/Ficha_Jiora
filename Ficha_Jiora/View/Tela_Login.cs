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

namespace Ficha_Jiora.View
{
    public partial class Tela_Login : Form
    {
        private Personagem_Control  personagem_Control = new Personagem_Control();
        public Tela_Login()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\mapa.png");
        }

        private void btn_logar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(personagem_Control.GetID(txt_nome_personagem.Text)))
                {
                    throw new Exception();
                }
                else
                {                    
                    Cursor.Current = Cursors.WaitCursor;
                    this.Hide();
                    Ficha_do_Jogador ficha = new Ficha_do_Jogador();
                    ficha.IDPersonagem = personagem_Control.GetID(txt_nome_personagem.Text);
                    MessageBox.Show("Bem Vindo a Jiora!\r\n" + txt_nome_personagem.Text, "Crônicas de Jiora");
                    ficha.Show();
                    Cursor.Current = Cursors.Default;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personagem "+ txt_nome_personagem.Text+ " não encontrado.","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txt_nome_personagem.Text = "";
            }
            

        }
        public void Fechar_Tela()
        {
            this.Close();
        }
    }
}
