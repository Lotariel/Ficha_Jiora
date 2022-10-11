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

        #region INFORMAÇÕES DA MAIN PAGE
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
                bs_personagem.DataSource = personagem_Control.Carrega_Personagem_2(IDPersonagem);
                dataGridView1.DataSource = bs_personagem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);         
            }
        }
        #endregion
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Codigo para garantir que a ação seja executada quando clicar no botão da gridview
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int Total = 0;
                var Row = dataGridView1.CurrentRow;

                
                //Codigo que pega o valor da linha atual selecionada
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    var resultado = linha.Cells["Cabelo"].Value;

                    if (resultado == null)
                    {
                        lbl_nivel_personagem.Text = "Valor Nulo";                        
                    }
                    else
                    {
                        string cabelo = dataGridView1.CurrentRow.Cells["Cabelo"].Value.ToString();
                        string id = dataGridView1.CurrentRow.Cells["idpersonagem"].Value.ToString();
                        personagem_Control.AlterarCabelo(id, cabelo);
                    }
                                        
                }
            }
        }
    }
}
