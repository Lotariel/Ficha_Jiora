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
using static System.Windows.Forms.LinkLabel;

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

        private void btn_atualiza_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Carrega_Tela();                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a ficha:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_nome_personagem.Text = "";
            }
        }

        private void Carrega_Tela()
        {
            try
            {
                CarregaPersonagem();
                Carrega_Log();
                Carrega_Pericia();
                CarregaAtributos();
                CarregaStatus();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

        private void CarregaAtributos()
        {
            try
            {

                lbl_defesa.Text = personagem_Model.Defesa.ToString();
                lbl_resistencia.Text = personagem_Model.Resistencia.ToString();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void img_defesa_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_defesa, "Defesa Física");
        }
        private void img_resistencia_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_resistencia, "Resistência Mágica");
        }

        #endregion

        #region INFORMAÇÕES DA ABA PERICIA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {//Codigo para garantir que a ação seja executada quando clicar no botão da gridview
                var senderGrid = (DataGridView)sender;


                string? NomeTeste = "";
                int valor = 0;

                //condigo antigo do if
                //senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                if (e.ColumnIndex == dataGridView1.Columns["Teste"].Index)
                {
                    int Total = 0;
                    var Row = dataGridView1.CurrentRow;


                    //Codigo que pega o valor da linha atual selecionada
                    foreach (DataGridViewRow linha in dataGridView1.Rows)
                    {
                        var resultado = linha.Cells["Nome"].Value;
                        NomeTeste = dataGridView1.CurrentRow.Cells["Nome"].Value.ToString();
                        valor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Valor"].Value);

                        if (resultado == NomeTeste)
                        {
                            int d100 = Rolar.D100();
                            if (d100 <= valor)
                            {
                                if (d100 <= 10)
                                {
                                    txt_pericia.Text = personagem_Model.Nome + " Realizou um acerto crítico no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Realizou uma acerto crítico no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                }
                                else
                                {
                                    txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Teve sucesso no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                }

                            }
                            else
                            {
                                if (d100 >= 95)
                                {
                                    txt_pericia.Text = "Falha Crítica! no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Realizou uma falha crítica no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                }
                                else
                                {
                                    txt_pericia.Text = "Você falhou no teste de " + NomeTeste + ".\r\nMais sorte na próxima vez!"
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Realizou uma falha no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                }

                            }
                        }

                    }
                }

                if (e.ColumnIndex == dataGridView1.Columns["salvar"].Index)
                {

                    valor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Valor"].Value);
                    NomeTeste = dataGridView1.CurrentRow.Cells["Nome"].Value.ToString();
                    string IDPericia = dataGridView1.CurrentRow.Cells["id_pericia"].Value.ToString();
                    int ValorAntigo = pericia_Control.ValorAtual(NomeTeste, IDPersonagem);

                    MessageBox.Show("Perícia " + NomeTeste + " atualizada com sucesso.\r\n\r\n" + ValorAntigo + " ➜ " + valor, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    pericia_Control.AtualizarValorPericia(valor, IDPersonagem, IDPericia);
                    Insertlog("Alterou o valor da Perícia: " + NomeTeste + " de " + ValorAntigo + " para " + valor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void Carrega_Pericia()
        {
            try
            {
                int? PontosPericia = pericia_Control.CalculaPontosPericia(IDPersonagem);

                bs_personagem.DataSource = pericia_Control.Carrega_Pericia(IDPersonagem);
                dataGridView1.DataSource = bs_personagem;

                lbl_pontos_pericia.Text = PontosPericia.ToString();

                if (PontosPericia != 0)
                {
                    btn_salvar_pericia.Visible = true;
                }
                else
                {
                    dataGridView1.Columns["salvar"].Visible = false;
                    dataGridView1.ReadOnly = true;
                    btn_salvar_pericia.Visible = false;
                    btn_salvar_pericia.Text = "Editar";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void btn_salvar_pericia_Click(object sender, EventArgs e)
        {
            try
            {


                if (btn_salvar_pericia.Text == "Confirmar")
                {
                    dataGridView1.Columns["salvar"].Visible = false;
                    btn_salvar_pericia.Text = "Editar";
                    dataGridView1.ReadOnly = true;
                }
                else
                {
                    dataGridView1.Columns["salvar"].Visible = true;
                    btn_salvar_pericia.Text = "Confirmar";
                    dataGridView1.ReadOnly = false;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region INFORMAÇÕES DA ABA DE LOG
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
        private void Carrega_Log()
        {
            try
            {
                BS_Log.DataSource = log_ficha.Carrega_Log(personagem_Model.Nome);
                dtg_log.DataSource = BS_Log;
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar a tabela de Log\n" + ex.Message);
            }
        }

        #endregion

        #region INFORMAÇÕES DA ABA STATUS

        private void CarregaStatus()
        {
            try
            {
                int? ValorAtributo = personagem_Control.GerenciaAtributos(IDPersonagem);
                lbl_altura.Text = personagem_Model.Altura;
                lbl_cabelo.Text = personagem_Model.Cabelo;
                lbl_olhos.Text = personagem_Model.Olhos;
                lbl_peso.Text = personagem_Model.Peso;
                lbl_nascimento.Text = personagem_Model.Nascimento;
                lbl_forca.Text = personagem_Model.Forca.ToString();
                lbl_vitalidade.Text = personagem_Model.Vitalidade.ToString();
                lbl_foco.Text = personagem_Model.Foco.ToString();
                lbl_velocidade.Text = personagem_Model.Velocidade.ToString();
                lbl_magia.Text = personagem_Model.Magia.ToString();
                lbl_aura.Text = personagem_Model.Aura.ToString(); ;

                GPB_status_atributos.Text = "Pontos Disponíveis " + ValorAtributo;
                if (ValorAtributo > 0)
                {
                    ControleBotao(true);
                }
                else
                {
                    ControleBotao(false);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void ControleBotao(bool LigaDesliga)
        {            
            if (LigaDesliga)
            {
                btn_up_for.Visible = true;
                btn_up_vit.Visible = true;
                btn_up_foc.Visible = true;
                btn_up_vel.Visible = true;
                btn_up_mag.Visible = true;
                btn_up_aur.Visible = true;
            }
            else
            {
                btn_up_for.Visible = false;
                btn_up_vit.Visible = false;
                btn_up_foc.Visible = false;
                btn_up_vel.Visible = false;
                btn_up_mag.Visible = false;
                btn_up_aur.Visible = false;
            }
        }
        #endregion

        private void btn_up_for_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("forca", personagem_Model.Forca, IDPersonagem);
                Insertlog("Aumentou +1 ponto de força. De " + personagem_Model.Forca + " para " + (personagem_Model.Forca + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_vit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("vitalidade", personagem_Model.Vitalidade, IDPersonagem);
                Insertlog("Aumentou +1 ponto de vitalidade. De " + personagem_Model.Vitalidade + " para " + (personagem_Model.Vitalidade + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_foc_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("foco", personagem_Model.Foco, IDPersonagem);
                Insertlog("Aumentou +1 ponto de foco. De " + personagem_Model.Foco + " para " + (personagem_Model.Foco + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_vel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("Velocidade", personagem_Model.Velocidade, IDPersonagem);
                Insertlog("Aumentou +1 ponto de velocidade. De " + personagem_Model.Velocidade + " para " + (personagem_Model.Velocidade + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_mag_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("Magia", personagem_Model.Magia, IDPersonagem);
                Insertlog("Aumentou +1 ponto de magia. De " + personagem_Model.Magia + " para " + (personagem_Model.Magia + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_aur_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("Aura", personagem_Model.Aura, IDPersonagem);
                Insertlog("Aumentou +1 ponto de aura. De " + personagem_Model.Aura + " para " + (personagem_Model.Aura + 1));
                ControleBotao(false);
                Carrega_Tela();
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
