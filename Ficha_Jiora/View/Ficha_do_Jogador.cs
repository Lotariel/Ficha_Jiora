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
        private Pericia_Control pericia_Control = new Pericia_Control();
        private Pericia_Model pericia_Model = new Pericia_Model();
        private Rolar_Dados Rolar = new Rolar_Dados();
        private Log_Ficha log_ficha = new Log_Ficha();
        private string IDPersonagem = "";
        

        public Ficha_do_Jogador()
        {
            InitializeComponent();
        }

        #region INFORMAÇÕES DA MAIN PAGE
        private void Insertlog(string action)
        {
            try
            {
                log_ficha.Insert_Log(personagem_Model.Nome, action);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        private void btn_atualiza_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CarregaPersonagem();
                //Insertlog("Atualizou a Ficha.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Falha ao carregar personagem:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_nome_personagem.Text = "";
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
                bs_personagem.DataSource = pericia_Control.Carrega_Pericia(IDPersonagem);
                dataGridView1.DataSource = bs_personagem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region INFORMAÇÕES DA ABA PERICIA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {//Codigo para garantir que a ação seja executada quando clicar no botão da gridview
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    int Total = 0;
                    var Row = dataGridView1.CurrentRow;


                    //Codigo que pega o valor da linha atual selecionada
                    foreach (DataGridViewRow linha in dataGridView1.Rows)
                    {
                        var resultado = linha.Cells["Nome"].Value;
                        int valor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Chance de Sucesso(%)"].Value);
                        string NomeTeste = dataGridView1.CurrentRow.Cells["Nome"].Value.ToString();

                        if (resultado == NomeTeste)
                        {
                            int d100 = Rolar.D100();
                            if (d100 <= valor)
                            {
                                if (d100 <= 10)
                                {
                                    MessageBox.Show(personagem_Model.Nome + " REALIZOU UM ACERTO CRÍTICO NO TESTE DE " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100, "Acerto Crítico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(personagem_Model.Nome + " teve sucesso no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100, "Acertou", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else
                            {
                                if (d100 >= 95)
                                {
                                    MessageBox.Show("Falha Crítica! no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100, "Falha Crítica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("Você falhou.\r\nMais sorte na próxima vez!"
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Insertlog("Realizou uma falha no teste de " + NomeTeste + "\n\r Valor do Dado:" + d100 + "\r\nValor do teste:" + valor);
                                }

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

#endregion
    }
}
