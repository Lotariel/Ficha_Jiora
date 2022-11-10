using Ficha_Jiora.Control;
using Ficha_Jiora.DAO;
using Ficha_Jiora.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;
using ToolTip = System.Windows.Forms.ToolTip;

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
        private Estigma_Control estigma_Control = new Estigma_Control();
        private Evento_Estigma evento_estigma = new Evento_Estigma();
        private Efeitos_Control efeitos_Control = new Efeitos_Control();
        private Habilidade_Control habilidade_Control = new Habilidade_Control();
        Batalha_Control batalha;
        private int d100 = 0, d12 = 0, d10 = 0, d8 = 0, d6 = 0;
        private Equipamento_Control equipamento_control = new Equipamento_Control();


        public Ficha_do_Jogador()
        {
            InitializeComponent();
        }
        public string IDPersonagem { get; set; }
        #region INFORMAÇÕES DA MAIN PAGE

        private void Ficha_do_Jogador_Load(object sender, EventArgs e)
        {
            Carrega_Tela(IDPersonagem);
            Carrega_background();
            tabControl1.Enabled = true;
            ModifyProgressBarColor.SetState(PB_MP, 3);
            ModifyProgressBarColor.SetState(PG_Limit, 2);

        }

        private void Ficha_do_Jogador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btn_atualiza_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a ficha:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_nome_personagem.Text = "";
                tabControl1.Enabled = false;
                txt_nome_personagem.Visible = true;

            }
        }
        private void Carrega_Tela(string ID)
        {
            try
            {

                d100 = Rolar.D100();
                d12 = Rolar.D12();
                d10 = Rolar.D10();
                d8 = Rolar.D8();
                d6 = Rolar.D6();
                CarregaPersonagem(ID);
                Carrega_Log();
                Carrega_Pericia();
                CarregaAtributos();
                CarregaStatus();
                Carrega_Batalha();
                //groupBox1.Paint += PaintBorderlessGroupBox;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Ficha, motivo do erro:\r\n" + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void Carrega_background()
        {
            tabControl1.TabPages[0].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            tabControl1.TabPages[1].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            tabControl1.TabPages[2].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            tabControl1.TabPages[3].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            tabControl1.TabPages[4].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            tabControl1.TabPages[5].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Capturar.PNG");
            this.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Background\\Fundo_atualizado.png");
            if (personagem_Model.ID == "4")
            {
                groupBox5.Text = "Elementos";
            }
        }       
        private void CarregaPersonagem(string ID)
        {
            try
            {
                //IDPersonagem = GetID(ID);
                personagem_Model = personagem_Control.Carrega_Personagem(ID);
                lbl_nome_personagem.Text = personagem_Model.Nome;
                lbl_nivel_personagem.Text = personagem_Model.Nivel.ToString();
                //img_imagem_personagem.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Perfil\\" + personagem_Model.Imagem);
                lbl_classe_peronsagem.Text = personagem_Model.Classe;
                VerificaEfeito(personagem_Model);
                panel2.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Perfil\\" + personagem_Model.Imagem);
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
                if (IDPersonagem == "2")
                {
                    label2.ForeColor = Color.Black;
                    lbl_nome_personagem.ForeColor = Color.Black;
                    lbl_nivel_personagem.ForeColor = Color.Black;
                    label2.BackColor = Color.White;
                    lbl_nome_personagem.BackColor = Color.White;
                    lbl_nivel_personagem.BackColor = Color.White;
                    lbl_classe_peronsagem.ForeColor = Color.Black;
                }
                else
                {
                    label2.ForeColor = Color.White;
                    lbl_nome_personagem.ForeColor = Color.White;
                    lbl_nivel_personagem.ForeColor = Color.White;
                    label2.BackColor = Color.Transparent;
                    lbl_nome_personagem.BackColor = Color.Transparent;
                    lbl_nivel_personagem.BackColor = Color.Transparent;
                    lbl_classe_peronsagem.ForeColor = Color.White;
                }
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
                batalha = new Batalha_Control(personagem_Model);

                lbl_defesa.Text = personagem_Model.Defesa.ToString();
                lbl_resistencia.Text = personagem_Model.Resistencia.ToString();
                lbl_precisao.Text = batalha.Precisao() + " %";
                lbl_esquiva.Text = batalha.Esquiva() + " %";
                lbl_critico.Text = personagem_Model.CDS_Critico + " %";
                lbl_valor_critico.Text = "x" + personagem_Model.Valor_Critico.ToString().Replace(',', '.'); ;
                lbl_exp.Text = personagem_Model.EXPAtual + " / " + (personagem_Model.Nivel * 500);
                lbl_tonz.Text = personagem_Model.Tonz.ToString();
                PG_Limit.Maximum = 100;
                PG_Limit.Value = personagem_Model.Especial;


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
        private void VerificaEstigma(Personagem_Model personagem)
        {
            string textoprotecao = evento_estigma.Alert_Estigma(personagem);
            if (textoprotecao != "")
            {
                var dialog = MessageBox.Show(textoprotecao, "Estigma", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    evento_estigma.Evolui_Estigma(personagem);
                    MessageBox.Show("Sua Estigma está mais poderosa. Você teve sucesso em sua evolução.", "Estigma", MessageBoxButtons.OK);
                    Insertlog("Teve sucesso em evoluir sua Estigma.");
                }
            }

        }
        private void VerificaEfeito(Personagem_Model personagem)
        {
            try
            {
                if (personagem_Model.Poison_Ativo)
                {
                    img_poison_effect.Visible = true;
                }
                else
                {
                    img_poison_effect.Visible = false;
                }
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


                string? NomeTeste = "";
                int valor = 0;

                //condigo antigo do if
                //senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)


                if (e.ColumnIndex == dataGridView1.Columns["Teste"].Index)
                {

                    var Row = dataGridView1.CurrentRow;


                    //Codigo que pega o valor da linha atual selecionada
                    foreach (DataGridViewRow linha in dataGridView1.Rows)
                    {
                        var resultado = linha.Cells["Nome"].Value;
                        NomeTeste = dataGridView1.CurrentRow.Cells["Nome"].Value.ToString();
                        valor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Valor"].Value);

                        if (resultado == NomeTeste)
                        {
                            d100 = Rolar.D100();
                            CarregaPersonagem(personagem_Model.ID);
                            if (d100 <= valor)
                            {
                                if (d100 <= 10)
                                {
                                    txt_pericia.Text = personagem_Model.Nome + " Realizou um acerto crítico no teste de " + NomeTeste
                                         + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Realizou uma acerto crítico no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                    if (NomeTeste == "Fuga" && personagem_Model.ID == "2")
                                    {
                                        estigma_Control.AumentarPontosEstigma(personagem_Model);
                                        VerificaEstigma(personagem_Model);
                                    }
                                }
                                else
                                {
                                    txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de " + NomeTeste
                                        + "\r\n\r\nValor do Teste: " + valor + "\r\nValor do Dado: " + d100;

                                    Insertlog("Teve sucesso no teste de " + NomeTeste + ". Valor do Dado: " + d100 + ". Valor do teste: " + valor);
                                }

                                if (NomeTeste == "Cobertura" && personagem_Model.ID == "3")
                                {
                                    estigma_Control.AumentarPontosEstigma(personagem_Model);
                                    VerificaEstigma(personagem_Model);
                                }

                                if (NomeTeste == "Culinária" || NomeTeste == "Cura" && personagem_Model.ID == "2" || personagem_Model.ID == "4")
                                {
                                    estigma_Control.AumentarPontosEstigma(personagem_Model);
                                    VerificaEstigma(personagem_Model);
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

                throw new Exception(ex.Message);
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
                lbl_aura.Text = personagem_Model.Aura.ToString();
                lbl_raca.Text = personagem_Model.Raca;
                lbl_critico_atributo.Text = personagem_Model.CDS_Critico.ToString();
                lbl_potencia.Text = personagem_Model.Potencia.ToString();

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
                btn_up_cri.Visible = true;
                btn_up_pot.Visible = true;
            }
            else
            {
                btn_up_for.Visible = false;
                btn_up_vit.Visible = false;
                btn_up_foc.Visible = false;
                btn_up_vel.Visible = false;
                btn_up_mag.Visible = false;
                btn_up_aur.Visible = false;
                btn_up_cri.Visible = false;
                btn_up_pot.Visible = false;
            }
        }

        private void btn_up_for_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("forca", personagem_Model.Forca, IDPersonagem);
                Insertlog("Aumentou +1 ponto de força. De " + personagem_Model.Forca + " para " + (personagem_Model.Forca + 1));
                ControleBotao(false);
                Carrega_Tela(personagem_Model.ID);
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
                Carrega_Tela(personagem_Model.ID);
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
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_teste_for_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Forca * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Força."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_teste_vit_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Vitalidade * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Vitalidade."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_teste_foc_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Foco * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Foco."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_teste_vel_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Velocidade * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Velocidade."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_teste_mag_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Magia * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Magia."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //Ver se tem como carregar a tela quando clicar na aba log
            Carrega_Tela(personagem_Model.ID);
        }

        private void btn_up_for_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_for, "Aumenta a Força em +1");
        }

        private void btn_up_vit_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_vit, "Aumenta a Vitalidade em +1");
        }

        private void btn_up_vel_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_vel, "Aumenta a Velocidade em +1");
        }

        private void btn_up_foc_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_foc, "Aumenta o Foco em +1");
        }

        private void btn_up_mag_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_mag, "Aumenta a Magia em +1");
        }

        private void btn_up_aur_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_up_aur, "Aumenta a Aura em +1");
        }

        private void img_precisao_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_precisao, "Chance de acerto(Precisão)");
        }

        private void img_esquiva_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_esquiva, "Chance de Esquiva");
        }

        private void img_critico_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_critico, "Chance de acerto Crítico");
        }

        private void img_valor_critico_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_valor_critico, "Potência do acerto crítico");
        }

        private void img_exp_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_exp, "Pontos de Experiência");
        }

        private void img_tonz_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(img_tonz, "Quantidade de Tonz");
        }

        private void btn_teste__aur_Click(object sender, EventArgs e)
        {
            try
            {
                d100 = Rolar.D100();
                int ValorTeste = (personagem_Model.Aura * 3) + 10;
                int resultado = personagem_Control.TesteAtributo(ValorTeste, d100);

                switch (resultado)
                {
                    case 1:
                        txt_pericia.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_pericia.Text = personagem_Model.Nome + " teve sucesso no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_pericia.Text = personagem_Model.Nome + " falhou no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_pericia.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Aura."
                                       + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou uma falha crítica no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o teste:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Carrega_Tela(personagem_Model.ID);
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
                Carrega_Tela(personagem_Model.ID);
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
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_cri_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("CDS_Critico", personagem_Model.CDS_Critico, IDPersonagem);
                Insertlog("Aumentou +1 ponto de Crítico. De " + personagem_Model.CDS_Critico + " para " + (personagem_Model.CDS_Critico + 1));
                ControleBotao(false);
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_up_pot_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                personagem_Control.AumentarAtributo("Potencia", personagem_Model.Potencia, IDPersonagem);
                Insertlog("Aumentou +1 ponto de Potência. De " + personagem_Model.Potencia + " para " + (personagem_Model.Potencia + 1));
                ControleBotao(false);
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao aumentar atributo:\n " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        #region INFORMAÇÕES DA ABA BATALHA

        private void Carrega_Batalha()
        {

            CBB_nome_personagem.Text = "Selecione";
            CBB_alvo.Text = "Selecione";
            CBB_Elementos.Text = "Selecione";
            txt_reduzir.Maximum = 999999;
            txt_reduzir.Controls[0].Visible = false;
            txt_reduzir.Text = "";
            lbl_valor_lb.Text = personagem_Model.Especial + " %";


            switch (personagem_Model.ID)
            {
                case "1":
                    lbl_limite_break.Text = "OverCharge";
                    break;
                case "2":
                    lbl_limite_break.Text = "Trance";
                    break;
                case "3":
                    lbl_limite_break.Text = "Limit Break";
                    break;
                case "4":
                    lbl_limite_break.Text = "Over Soul";
                    break;
                case "6":
                    lbl_limite_break.Text = "Trance";
                    break;
                default:
                    lbl_limite_break.Text = "Limit Break";
                    break;
            }
            lbl_hp.Text = personagem_Model.HPAtual + " / " + personagem_Model.HPMax;
            lbl_mp.Text = personagem_Model.MPAtual + " / " + personagem_Model.MPMax;


            PB_HP.Maximum = personagem_Model.HPMax;
            PB_HP.Value = personagem_Model.HPAtual;
            PB_MP.Maximum = personagem_Model.MPMax;
            PB_MP.Value = personagem_Model.MPAtual;

            if (personagem_Model.ID == "3")
            {
                btn_postura.Visible = true;

                if (btn_postura.Text == "Protector Mode")
                {
                    btn_postura.Text = "Protector Mode";
                }
                else
                {
                    btn_postura.Text = "Predator Mode";
                }

            }
            else
            {
                btn_postura.Visible = false;

            }
            if (personagem_Model.ID == "4")
            {
                CBB_alvo.Visible = true;
                CBB_categoria.Visible = true;
                CBB_Elementos.Visible = true;
                CBB_nivel.Visible = true;
                btn_magia_antiga.Visible = true;
                Btn_simular.Visible = true;
                label28.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                label21.Visible = true;
            }
            Carrega_Combo_Ataque();
            Carrega_Combo_Habilidade();

        }
        private void Carrega_Combobox_Personagem()
        {

            try
            {
                CBB_nome_personagem.DataSource = batalha.Carrega_Combo_Personagem();
                CBB_nome_personagem.ValueMember = "ID";
                CBB_nome_personagem.DisplayMember = "Nome";
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar ComboBox Nome do Personagem: " + ex.Message);
            }
        }
        private void Carrega_Combo_Elementos()
        {

            try
            {
                CBB_Elementos.DataSource = batalha.Carrega_Combo_Elementos();
                CBB_Elementos.ValueMember = "Nome";
                CBB_Elementos.DisplayMember = "Nome";
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar ComboBox Nome dos Elementos: " + ex.Message);
            }
        }
        private void Carrega_Combo_Ataque()
        {
            try
            {
                cbb_ataque.DataSource = batalha.Carrega_Combo_Ataques(personagem_Model);
                cbb_ataque.DisplayMember = "Nome";
                cbb_ataque.ValueMember = "Nome";
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar ComboBox Nome dos Ataques: " + ex.Message);
            }
        }
        private void Carrega_Combo_Habilidade()
        {
            try
            {
                cbb_habilidade.DataSource = batalha.Carrega_Combo_Habilidade(personagem_Model, btn_postura.Text);
                cbb_habilidade.DisplayMember = "Nome";
                cbb_habilidade.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar ComboBox Nome das Habilidades: " + ex.Message);
            }

        }
        private void Calcula_Habilidade()
        {
            try
            {
                Habilidade_Model habilidade = new Habilidade_Model();
                habilidade = batalha.Carrega_Habilidade(cbb_habilidade.SelectedValue.ToString());
                double dano = Math.Ceiling(habilidade.Multiplicador * batalha.ValordoAtaque());
                string alvo = habilidade.Alvo;
                string descricao = habilidade.Descricao;
                string efeito = habilidade.Efeito;
                string tipodano = habilidade.TipoDano;
                string tipocusto = habilidade.TipoCusto;
                int Hit = habilidade.HIT;
                int custo = habilidade.ValorCusto;
                int CDA = habilidade.CDA;
                int contador = 1;
                d100 = Rolar.D100();
                if (personagem_Model.MPAtual < custo && tipocusto == "MP")
                {
                    MessageBox.Show("Mana insuficiente para usar habilidade.", "Sem Mana", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                    if (d100 <= CDA)
                    {

                        txt_batalha.Text = "Você acertou a habilidade " + habilidade.Nome;
                        txt_batalha.Text += "\r\n\r\nDescreva a ação de " + personagem_Model.Nome + " utilizando essa habilidade.\r\n\r\n";

                        if (tipocusto == "MP")
                        {
                            batalha.ReduzirMPAtual(personagem_Model.ID, custo);
                        }


                        if (habilidade.HIT == 1)
                        {
                            txt_batalha.Text += "Dano: " + dano + " " + tipodano + "\r\n";
                        }
                        else
                        {
                            for (int i = 0; i < habilidade.HIT; i++)
                            {
                                dano = Math.Ceiling(habilidade.Multiplicador * batalha.ValordoAtaque());
                                txt_batalha.Text += contador + "º Dano: " + dano + " " + tipodano + "\r\n";
                                contador++;
                            }
                        }

                        txt_batalha.Text += "Custo: " + custo + " " + tipocusto;
                        txt_batalha.Text += "\r\nAlvo: " + alvo + "\r\nHit: " + Hit + "\r\nCategoria: " + habilidade.Atributo + "\r\nChance de Acerto: " + CDA + " %\r\n";
                        txt_batalha.Text += "CDS Efeito: " + habilidade.CDSEfeito + " %\r\nEfeito: " + efeito + "\r\nDescrição:\r\n";
                        txt_batalha.Text += descricao;
                    }
                    else
                    {
                        txt_batalha.Text = personagem_Model.Nome + " errou a habilidade.\r\n\r\n";
                        txt_batalha.Text += "Valor do Dado: " + d100;
                        txt_batalha.Text += "\r\nChance de Acerto: " + CDA;
                    }

                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void btn_esquiva_Click(object sender, EventArgs e)
        {
            try
            {
                int esquiva = batalha.Esquiva();
                string TextoEsquiva = "";
                d100 = Rolar.D100();
                if (d100 <= esquiva)
                {
                    TextoEsquiva = personagem_Model.Nome + " conseguiu se esquivar com sucesso!";
                    TextoEsquiva += "\r\n\r\nValor do Dado: " + d100;
                    Insertlog("Teve sucesso no teste de Esquiva.");
                    MessageBox.Show(TextoEsquiva, "Esquivou", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TextoEsquiva = personagem_Model.Nome + " falhou ao tentar se esquivar!";
                    TextoEsquiva += "\r\n\r\nValor do Dado: " + d100;
                    Insertlog("Teve falha no teste de Esquiva.");
                    MessageBox.Show(TextoEsquiva, "Não Esquivou", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Falha ao tentar executar o comando Esquivar. Motivo do Erro: " + ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_Atacar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txt_batalha.Text = Atacar();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Falhar ao gerar o ataque motivo:\r\n" + ex.Message, "Falha ao gerar o Ataque", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void CBB_nome_personagem_Click(object sender, EventArgs e)
        {
            Carrega_Combobox_Personagem();
        }
        private void Btn_simular_Click(object sender, EventArgs e)
        {
            txt_batalha.Text = Simulação_Magia_Antiga();
        }
        private void btn_small_potion_Click(object sender, EventArgs e)
        {
            Pocao_Pequena();
        }
        private void Pocao_Pequena()
        {
            try
            {
                if (CBB_nome_personagem.Text == "Selecione")
                {
                    MessageBox.Show("Selecione um alvo para utilizar o item.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CBB_nome_personagem.Focus();
                }
                else
                {
                    string IDAlvo = CBB_nome_personagem.SelectedValue.ToString();
                    if (IDAlvo == personagem_Model.ID)
                    {
                        batalha.Pocao_Pequena(IDAlvo);
                        Carrega_Tela(personagem_Model.ID);
                        txt_batalha.Text = personagem_Model.Nome + " acaba de consumir uma Poção Pequena. Recuperando +";
                        txt_batalha.Text += Convert.ToInt32(Math.Ceiling(personagem_Model.HPMax * 0.30)) + " do seu HP.";
                        Insertlog("Utilizou uma Poção Pequena.");
                    }
                    else
                    {
                        batalha.Pocao_Pequena(IDAlvo);
                        txt_batalha.Text = personagem_Model.Nome + " utiliza uma Poção Pequena em " + CBB_nome_personagem.Text;
                        Insertlog("Utilizou uma Poção Pequena em " + CBB_nome_personagem.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao usar Item: " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_magia_antiga_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txt_batalha.Text = Usar_Magia_Antiga();
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao usar magia antiga.\r\n" + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void AdicionaTurnos()
        {
            CarregaPersonagem(personagem_Model.ID);
            batalha.AdicionaTurno(personagem_Model);
        }
        private void btn_reduzir_hp_Click(object sender, EventArgs e)
        {
            try
            {
                Reduzir_HP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reduzir HP:\r\n" + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Reduzir_HP()
        {
            try
            {
                int valor = Convert.ToInt32(txt_reduzir.Text);
                string TextoAparouFisico = "aparou o ataque e não recebeu nenhum dano.\r\n\r\nValor do Dano Recebido é inferior a Defesa do personagem."; ;
                string TextoAparouMagico = "O dano recebido não conseguiu atravessar a Aura de " + personagem_Model.Nome + ".Você não recebe dano desse ataque.\r\n\r\nValor do Dano Recebido é inferior a Resistencia do personagem.";
                if (cbb_tipo_dano.Text == "")
                {
                    MessageBox.Show("Selecione um tipo de Dano", "Tipo de Dano", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    switch (cbb_tipo_dano.Text)
                    {
                        case "Físico":
                            valor = valor - personagem_Model.Defesa;
                            if (personagem_Model.ID == "3" && btn_postura.Text == "Protector Mode")
                            {
                                txt_batalha.Text = personagem_Model.Nome + " aparou o ataque e não recebeu nenhum dano.";
                                valor = 0;
                            }
                            else
                            {
                                if (valor < 0)
                                {
                                    valor = 0;
                                    txt_batalha.Text = personagem_Model.Nome + TextoAparouFisico;

                                }
                                else
                                {
                                    txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                                }
                            }
                            txt_batalha.Text += Counter_Ataque();
                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;
                        case "Perfurante Físico":
                            valor = valor - (personagem_Model.Defesa / 2);
                            if (personagem_Model.ID == "3" && btn_postura.Text == "Protector Mode")
                            {
                                txt_batalha.Text = personagem_Model.Nome + " aparou o ataque e não recebeu nenhum dano.";
                                valor = 0;
                            }
                            else
                            {
                                if (valor < 0)
                                {
                                    valor = 0;
                                    txt_batalha.Text = personagem_Model.Nome + TextoAparouFisico;
                                }
                                else
                                {
                                    txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                                }
                            }
                            txt_batalha.Text += Counter_Ataque();
                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;
                        case "Dano Real Físico":
                            if (personagem_Model.ID == "3" && btn_postura.Text == "Protector Mode")
                            {
                                txt_batalha.Text = personagem_Model.Nome + " aparou o ataque e não recebeu nenhum dano.";
                                valor = 0;
                            }
                            else
                            {
                                txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                            }
                            txt_batalha.Text += Counter_Ataque();
                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;
                        case "Mágico":
                            valor = valor - personagem_Model.Resistencia;

                            if (valor < 0)
                            {
                                valor = 0;
                                txt_batalha.Text = TextoAparouMagico;
                            }
                            else
                            {
                                txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                            }
                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;
                        case "Perfurante Mágico":
                            valor = valor - (personagem_Model.Resistencia / 2);

                            if (valor < 0)
                            {
                                valor = 0;
                                txt_batalha.Text = TextoAparouMagico;
                            }
                            else
                            {
                                txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                            }
                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;

                        case "Dano Real Mágico":

                            txt_batalha.Text = "Você perdeu " + valor + " de HP.";

                            Insertlog("Perdeu " + valor + " de HP.");
                            batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                            break;
                    }
                    Carrega_Tela(personagem_Model.ID);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private string Counter_Ataque()
        {
            if (personagem_Model.ID == "2")
            {
                return habilidade_Control.MeatBone_Slash(personagem_Model);
            }

            if (personagem_Model.ID == "3" && btn_postura.Text == "Protector Mode")
            {
                return habilidade_Control.StrikeBack(personagem_Model);
            }

            return "";
        }
        private void btn_reduzir_mp_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(txt_reduzir.Text);
                txt_batalha.Text = "Você perdeu " + valor + " de MP.";
                Insertlog("Perdeu " + valor + " de MP.");
                batalha.ReduzirMPAtual(personagem_Model.ID, valor);
                Carrega_Tela(personagem_Model.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reduzir MP:\r\n" + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_postura_Click(object sender, EventArgs e)
        {
            try
            {
                Postura();
                Carrega_Tela(personagem_Model.ID);
            }
            catch (Exception ex)
            {

                MessageBox.Show("", "Falha ao executar Postura", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void Postura()
        {
            try
            {
                Ataque_Model ataque = new Ataque_Model();
                Efeitos_Model efeitos = new Efeitos_Model();
                if (personagem_Model.ID == "3")
                {
                    if (btn_postura.Text == "Predator Mode")
                    {
                        btn_postura.Text = "Protector Mode";
                        txt_batalha.Text = "Você adotou a postura ofensiva para a batalha.";
                        txt_batalha.Text += "\r\n\r\nCounter Melee Attack - Ativo";
                        txt_batalha.Text += "\r\nRedução 100% Dano Físico Recebido - Ativo";
                        txt_batalha.Text += "\r\nAtaque Básico +1 Hit - Ativo";
                        txt_batalha.Text += "\r\nSkill ofensivas - Ativo";
                        txt_batalha.Text += "\r\nSkill Defensivas - Desativado";
                        txt_batalha.Text += "\r\nAção de Defender - Desativado";
                        btn_defender.Enabled = false;
                        batalha.Adiciona_Hit_Ataque("Hávarðr", personagem_Model);
                    }
                    else
                    {
                        btn_postura.Text = "Predator Mode";
                        txt_batalha.Text = "Você adotou a postura defensiva para a batalha.";
                        txt_batalha.Text += "\r\n\r\nCounter Melee Attack - Ativo";
                        txt_batalha.Text += "\r\nRedução 100% Dano Físico Recebido - Desativado";
                        txt_batalha.Text += "\r\nAtaque Básico +1 Hit - Desativado";
                        txt_batalha.Text += "\r\nSkill Ofensivas - Desativado";
                        txt_batalha.Text += "\r\nSkill Defensivas - Ativa";
                        txt_batalha.Text += "\r\nAção de Defender - Ativa";
                        btn_defender.Enabled = true;
                        ataque = batalha.Carrega_Ataque(personagem_Model, "Hávarðr");
                        batalha.Remove_Hit_Ataque("Hávarðr", personagem_Model);

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao executar postura: " + ex.Message);
            }
        }
        private string Atacar()
        {
            try
            {
                if (personagem_Model.ID == "3" && btn_postura.Text == "Predator Mode")
                {
                    batalha.Define_Hit_Ataque("Hávarðr", personagem_Model, 1);
                }
                Ataque_Model ataque = new Ataque_Model();
                Efeitos_Model efeitos = new Efeitos_Model();
                efeitos = batalha.Carrega_Efeito(personagem_Model.ID);
                d100 = Rolar.D100();
                double Dano = CalculaAtaque();
                ataque = batalha.Carrega_Ataque(personagem_Model, cbb_ataque.Text);
                string textoataque = "";

                if (efeitos.Turnos_Encantamento > 0)
                {
                    ataque.TipoDano = " do elemento " + efeitos.Elemento_Encantado;
                }
                if (cbb_ataque.Text == "Combate Corpo-a-Corpo")
                {
                    if (efeitos.Turnos_Encantamento > 0)
                    {
                        ataque.TipoDano = "Físico";
                    }
                    else
                    {
                        ataque.TipoDano = "Físico";
                    }

                }

                if (d100 <= batalha.Precisao())
                {
                    int contador = 1;
                    if (d100 <= personagem_Model.CDS_Critico)
                    {
                        textoataque = "~~~~ ACERTO CRÍTICO ~~~~\r\n\r\n";
                        textoataque += personagem_Model.Nome + " realizou um acerto crítico.\r\n\r\n";

                        if (ataque.HIT == 1)
                        {
                            textoataque += "Dano: " + Convert.ToInt32(Dano * personagem_Model.Valor_Critico) + " " + ataque.TipoDano + "\r\n";
                        }
                        else
                        {
                            for (int i = 0; i < ataque.HIT; i++)
                            {
                                Dano = CalculaAtaque();
                                textoataque += contador + "º Dano: " + Convert.ToInt32(Dano * personagem_Model.Valor_Critico) + " " + ataque.TipoDano + "\r\n";
                                contador++;
                            }
                        }

                        textoataque += "Valor do Dado: " + d100 + "\r\nHit: " + ataque.HIT + "\r\n";
                        textoataque += "Alvo: " + ataque.Alvo + "\r\nCDS Efeito: " + ataque.CDSEfeito + " %\r\n";
                        textoataque += "Efeito: " + ataque.Efeito + "\r\nCategoria: " + ataque.Categoria;
                        Insertlog("Realizou um acerto crítico,valor do dano: " + Convert.ToInt32(Dano * personagem_Model.Valor_Critico) + " tipo " + ataque.TipoDano);
                        return textoataque;
                    }
                    else
                    {
                        textoataque = "~~~~~~ ATAQUE ~~~~~~\r\n\r\n";
                        textoataque += personagem_Model.Nome + " teve sucesso em acertar seu ataque.\r\n\r\n";

                        if (ataque.HIT == 1)
                        {
                            textoataque += "Dano: " + Dano + " " + ataque.TipoDano + "\r\n";
                        }
                        else
                        {

                            for (int i = 0; i < ataque.HIT; i++)
                            {
                                Dano = CalculaAtaque();
                                textoataque += contador + "º Dano: " + Dano + " " + ataque.TipoDano + "\r\n";
                                contador++;
                            }
                        }

                        textoataque += "Valor do Dado: " + d100 + "\r\nHit: " + ataque.HIT + "\r\n";
                        textoataque += "Alvo: " + ataque.Alvo + "\r\nCDS Efeito: " + ataque.CDSEfeito + " %\r\n";
                        textoataque += "Efeito: " + ataque.Efeito + "\r\nCategoria: " + ataque.Categoria;
                        Insertlog("Acertou seu ataque,valor do dano: " + Dano + " tipo " + ataque.TipoDano);
                        return textoataque;
                    }

                }
                else
                {
                    if (d100 >= 95)
                    {
                        textoataque = "~~~~ FALHA CRÍTICA ~~~~\r\n\r\n";


                        switch (Rolar.D3())
                        {
                            case 1:
                                textoataque += personagem_Model.Nome + " ataca a sí mesmo.\r\n\r\nValor do Dano: " + CalculaAtaque() + "\r\nValor do Dado: " + d100;
                                break;
                            case 2:
                                textoataque += personagem_Model.Nome + " ataca o aliado mais próximo.\r\n\r\nValor do Dano: " + CalculaAtaque() + "\r\nValor do Dado: " + d100;
                                break;
                            case 3:
                                textoataque += personagem_Model.Nome + " você não executa ação no próximo turno.\r\n\r\nValor do Dado: " + d100;
                                break;
                        }



                        Insertlog("Realizou uma falha crítica,valor do dado: " + d100);
                        return textoataque;
                    }
                    else
                    {
                        textoataque = "~~~~~~ ERROU ~~~~~~\r\n\r\n";
                        textoataque += personagem_Model.Nome + " errou o ataque.\r\n\r\nValor do Dado: " + d100;
                        Insertlog("Errou seu ataque,valor do dado: " + d100 + " valor da precisão: " + batalha.Precisao());
                        return textoataque;
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private double CalculaAtaque()
        {
            d100 = Rolar.D100();
            Efeitos_Model efeitos = new Efeitos_Model();
            Ataque_Model ataque = new Ataque_Model();
            efeitos = batalha.Carrega_Efeito(personagem_Model.ID);
            ataque = batalha.Carrega_Ataque(personagem_Model, cbb_ataque.Text);
            int DanoAtaque = batalha.ValordoAtaque();
            double Bonus = Math.Ceiling(DanoAtaque * ataque.Multiplicador);
            int BonusAtributo = 0;

            if (ataque.Atributo != "")
            {
                switch (ataque.Atributo)
                {
                    case "FOR":
                        BonusAtributo = personagem_Model.Forca * ataque.MultiAtributo;
                        break;
                    case "MAG":
                        BonusAtributo = personagem_Model.Magia * ataque.MultiAtributo;
                        break;
                    case "FOC":
                        BonusAtributo = personagem_Model.Foco * ataque.MultiAtributo;
                        break;
                    case "VIT":
                        BonusAtributo = personagem_Model.Vitalidade * ataque.MultiAtributo;
                        break;
                    case "VEL":
                        BonusAtributo = personagem_Model.Velocidade * ataque.MultiAtributo;
                        break;
                    case "AUR":
                        BonusAtributo = personagem_Model.Aura * ataque.MultiAtributo;
                        break;
                }
            }
            if (efeitos.Turnos_Encantamento > 0)
            {
                ataque.TipoDano = " do elemento " + efeitos.Elemento_Encantado;
                BonusAtributo += personagem_Model.Magia * 2;
            }
            if (cbb_ataque.Text == "Combate Corpo-a-Corpo")
            {
                if (efeitos.Turnos_Encantamento > 0)
                {
                    BonusAtributo += Rolar.D6();
                    BonusAtributo -= personagem_Model.Magia * 2;
                    ataque.TipoDano = "Físico";
                }
                else
                {
                    BonusAtributo += Rolar.D6();
                    ataque.TipoDano = "Físico";
                }

            }

            Bonus += BonusAtributo;

            return (DanoAtaque + Bonus);
        }
        private void btn_iniciativa_Click(object sender, EventArgs e)
        {
            try
            {
                int Inciativa = Rolar.D10() + personagem_Model.Velocidade;
                AdicionaTurnos();
                txt_batalha.Text = "Valor da iniciativa: " + Inciativa;
                Insertlog("Teve o resultado de " + Inciativa + " no teste de iniciativa.");
                Efeitos_Model efeitos_Model = new Efeitos_Model();
                efeitos_Model = batalha.Carrega_Efeito(personagem_Model.ID);
                if (efeitos_Model.Turnos_Encantamento > 0)
                {
                    txt_batalha.Text += "\r\n\r\nVocê possui " + efeitos_Model.Turnos_Encantamento + " turnos com o encantamento do elemento " + efeitos_Model.Elemento_Encantado;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Falha, motivo do erro:" + ex.Message, "Erro ao executar Iniciativa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn_utiliza_habilidade_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Calcula_Habilidade();
                Carrega_Tela(personagem_Model.ID);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Falha, motivo do erro:" + ex.Message, "Erro ao executar Habilidade", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void CBB_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBB_alvo.ResetText();
            if (CBB_categoria.Text == "Ofensivo")
            {
                CBB_alvo.DataSource = batalha.Carrega_Combo_Alvo_Todos();
                CBB_alvo.ValueMember = "ID";
                CBB_alvo.DisplayMember = "Nome";
            }
            if (CBB_categoria.Text == "Defensivo" || CBB_categoria.Text == "Encantamento")
            {
                CBB_alvo.DataSource = batalha.Carrega_Combo_Alvo_Aliado();
                CBB_alvo.ValueMember = "ID";
                CBB_alvo.DisplayMember = "Nome";
            }
            if (CBB_categoria.Text == "Enfraquecer")
            {
                CBB_alvo.DataSource = batalha.Carrega_Combo_Alvo_Inimigo();
                CBB_alvo.ValueMember = "ID";
                CBB_alvo.DisplayMember = "Nome";
            }

        }

        private void CBB_Elementos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBB_Elementos_MouseClick(object sender, MouseEventArgs e)
        {
            Carrega_Combo_Elementos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Informacoes info = new Informacoes();
            info.IDPersonagem = personagem_Model.ID;
            info.Show();
        }

        private void btn_defender_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(txt_reduzir.Text);
                valor = valor - (personagem_Model.Defesa + personagem_Model.Resistencia);

                if (valor < 0)
                {
                    txt_batalha.Text = "Você bloqueou 100% do dano e não perdeu vida.";
                    Insertlog("Defendeu 100% do dano recebido");
                }
                else
                {
                    txt_batalha.Text = "Você perdeu " + valor + " de HP.";
                    Insertlog("Defendeu o valor de" + valor);
                    batalha.ReduzirHPAtual(personagem_Model.ID, valor);
                }
                Carrega_Tela(personagem_Model.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao Defender:\r\n" + ex.Message, "Falha ao Defender", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btn_limit_Click(object sender, EventArgs e)
        {
            limit();
            Carrega_Tela(personagem_Model.ID);
        }
        private void limit()
        {
            switch (personagem_Model.ID)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    
                    break;
                case "4":
                    break;
                case "6":
                    break;
            }
        }
        private string Simulação_Magia_Antiga()
        {
            try
            {
                MagiaAntiga_Model magia = new MagiaAntiga_Model();
                string elemento = CBB_Elementos.Text.Trim();
                string rank = CBB_nivel.Text;
                int alvo = Convert.ToInt32(CBB_alvo.SelectedValue);
                string categoria = CBB_categoria.Text;
                string Texto = "";
                magia = batalha.RetornaDescricaoMagiaAntiga(elemento, rank, alvo, categoria);

                Texto = "~~~~~Simulação~~~~~\r\n\r\n";
                Texto += magia.Descricao + "\r\n\r\n";
                Texto += "Custo de Mana: " + magia.Custo;
                return Texto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        private string Usar_Magia_Antiga()
        {
            try
            {
                MagiaAntiga_Model magia = new MagiaAntiga_Model();
                string elemento = CBB_Elementos.Text.Trim();
                string rank = CBB_nivel.Text;
                int alvo = Convert.ToInt32(CBB_alvo.SelectedValue);
                string categoria = CBB_categoria.Text;
                string Texto = "";
                magia = batalha.RetornaDescricaoMagiaAntiga(elemento, rank, alvo, categoria);
                int Dano = (magia.Multiplicador * personagem_Model.Magia);

                if (personagem_Model.MPAtual >= magia.Custo)
                {
                    Texto = "~~~~~Magia Antiga~~~~~\r\n\r\n";
                    Texto += magia.Descricao + "\r\n\r\n";
                    Texto += "Custo de Mana: " + magia.Custo + " MP.";
                    batalha.ReduzirMPAtual(personagem_Model.ID, magia.Custo);

                    if ((categoria == "Ofensivo" && elemento == "Lumen") && alvo == 100 && alvo == 101)
                    {
                        Insertlog("Curou o HP do inimigo em +" + Dano);
                        return Texto += "\r\n\r\nValor da Cura: " + Dano + " de HP" + ". (" + CBB_nivel.Text + ")";
                    }

                    if ((categoria == "Ofensivo" && elemento == "Lumen") && alvo < 99 || alvo == 102)
                    {
                        Insertlog("Curou o HP de " + CBB_alvo.Text + " em +" + Dano + ". (" + CBB_nivel.Text + ")");
                        if (alvo < 99)
                        {
                            batalha.CurarHPAtual(alvo.ToString(), Dano);
                        }
                        else
                        {
                            batalha.CurarHPAtual("1".ToString(), Dano);
                            batalha.CurarHPAtual("2".ToString(), Dano);
                            batalha.CurarHPAtual("3".ToString(), Dano);
                            batalha.CurarHPAtual("4".ToString(), Dano);
                            batalha.CurarHPAtual("6".ToString(), Dano);
                        }
                        return Texto += "\r\n\r\nValor da Cura: " + Dano + " de HP.";
                    }


                    if (categoria == "Defensivo")
                    {
                        Insertlog("Utilizou o elemento " + CBB_Elementos.Text + " na forma " + CBB_categoria.Text + " em " + CBB_alvo.Text + ". (" + CBB_nivel.Text + ")");
                        string NomeElemento = ConversorDeElemento(elemento);
                        string NovoNomeElemento = ConversorElementoColunaResistencia(NomeElemento);
                        int Porcentagem = 0;


                        switch (CBB_nivel.Text)
                        {
                            case "Rank 1":
                                Porcentagem = 25;
                                break;
                            case "Rank 2":
                                Porcentagem = 50;
                                break;
                            case "Rank 3":
                                Porcentagem = 75;
                                break;
                            case "Rank 4":
                                Porcentagem = 100;
                                break;
                            case "Rank 5":
                                Porcentagem = 200;
                                break;
                        }

                        if (alvo < 99)
                        {
                            batalha.AumentaElementoMod(alvo.ToString(), NovoNomeElemento, Porcentagem);
                        }
                        if (alvo == 102)
                        {
                            batalha.AumentaElementoMod("1", NovoNomeElemento, Porcentagem);
                            batalha.AumentaElementoMod("2", NovoNomeElemento, Porcentagem);
                            batalha.AumentaElementoMod("3", NovoNomeElemento, Porcentagem);
                            batalha.AumentaElementoMod("4", NovoNomeElemento, Porcentagem);
                            batalha.AumentaElementoMod("6", NovoNomeElemento, Porcentagem);
                        }
                        return Texto += "";
                    }

                    if (categoria == "Encantamento" && alvo < 99 || alvo == 102)
                    {
                        int turnos = 0;
                        Insertlog("Utilizou o elemento " + CBB_Elementos.Text + " na forma " + CBB_categoria.Text + " em " + CBB_alvo.Text + ". (" + CBB_nivel.Text + ")");
                        switch (CBB_nivel.Text)
                        {
                            case "Rank 1":
                                turnos = 1;
                                break;
                            case "Rank 2":
                                turnos = 2;
                                break;
                            case "Rank 3":
                                turnos = 3;
                                break;
                            case "Rank 4":
                                turnos = 4;
                                break;
                            case "Rank 5":
                                turnos = 5;
                                break;
                        }
                        if (alvo < 99)
                        {
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, alvo.ToString());
                        }
                        else
                        {
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, "1");
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, "2");
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, "3");
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, "4");
                            batalha.AdicionaEncantamento(ConversorDeElemento(elemento), turnos, "6");
                        }

                        return Texto += "";
                    }

                    Texto += "\r\n\r\nDano: " + Dano + " do elemento " + ConversorDeElemento(elemento);
                    Insertlog("Utilizou o elemento " + CBB_Elementos.Text + " na forma " + CBB_categoria.Text + " em " + CBB_alvo.Text + ". (" + CBB_nivel.Text + ")");
                    return Texto;
                }
                else
                {
                    MessageBox.Show("Mana insuficiente para conjurar Magia.", "Falta de Mana", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string ConversorDeElemento(string elemento)
        {
            switch (elemento.Trim())
            {
                case "Pyro":
                    return "Fogo.";
                case "Cryo":
                    return "Gelo.";
                case "Venti":
                    return "Vento.";
                case "Geo":
                    return "Terra.";
                case "Electro":
                    return "Trovão.";
                case "Hydro":
                    return "Água.";
                case "Lumen":
                    return "Luz.";
                case "Mortem":
                    return "Sombras.";
                default:
                    return "";

            }
        }
        private string ConversorElementoColunaResistencia(string elemento)
        {
            switch (elemento.Trim())
            {
                case "Fogo.":
                    return "Mod_res_fire";
                case "Gelo.":
                    return "Mod_res_ice";
                case "Vento.":
                    return "Mod_res_wind";
                case "Terra.":
                    return "Mod_res_earth";
                case "Trovão.":
                    return "Mod_res_thunder";
                case "Água.":
                    return "Mod_res_water";
                case "Luz.":
                    return "Mod_res_light";
                case "Sombras.":
                    return "Mod_res_shadow";
                default:
                    return "";
            }
        }
        #endregion
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }

}
