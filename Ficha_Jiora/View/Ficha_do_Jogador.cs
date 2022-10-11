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
    public partial class Ficha_do_Jogador : Form
    {
        private Personagem_Control personagem_Control = new Personagem_Control();
        private Personagem_Model personagem_Model = new Personagem_Model();
        private string IDPersonagem = "";
        
        public Ficha_do_Jogador()
        {
            InitializeComponent();
        }

        private void btn_atualiza_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;                
                CarregaPersonagem();                               
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar personagem:\n " + ex.Message,"Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
        }


        private string GetID(string nome)
        {
            try
            {
                return personagem_Control.GetID(nome);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void CarregaPersonagem()
        {
            try
            {
                IDPersonagem = GetID(txt_nome_personagem.Text);
                personagem_Model = personagem_Control.Carrega_Personagem(IDPersonagem);
                lbl_nome_personagem.Text = personagem_Model.Nome;
                lbl_nivel_personagem.Text = personagem_Model.Nivel.ToString();
                img_imagem_personagem.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Perfil\\" + personagem_Model.Imagem);
                lbl_classe_peronsagem.Text = personagem_Model.Classe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);         
            }
        }
       
    }
}
