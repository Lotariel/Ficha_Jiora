using Ficha_Jiora.Control;
using Ficha_Jiora.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        Batalha_Control batalha;
        private string IDPersonagem = "";
        private int d100 = 0, d12 = 0, d10 = 0, d8 = 0, d6 = 0;

        private Equipamento_Control equipamento_control = new Equipamento_Control();





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
                tabControl1.Enabled = true;                
                //txt_nome_personagem.Visible = false;                
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

        private void Carrega_Tela()
        {
            try
            {
                
                d100 = Rolar.D100();
                d12 = Rolar.D12();
                d10 = Rolar.D10();
                d8 = Rolar.D8();
                d6 = Rolar.D6();
                CarregaPersonagem();
                Carrega_Log();
                Carrega_Pericia();
                CarregaAtributos();
                CarregaStatus();
                Carrega_Batalha();

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
                batalha = new Batalha_Control(personagem_Model);

                lbl_defesa.Text = personagem_Model.Defesa.ToString();
                lbl_resistencia.Text = personagem_Model.Resistencia.ToString();
                lbl_precisao.Text = batalha.Precisao() + " %";
                lbl_esquiva.Text = batalha.Esquiva() + " %";
                lbl_critico.Text = personagem_Model.CDS_Critico + " %";
                lbl_valor_critico.Text = "x" + personagem_Model.Valor_Critico.ToString();
                lbl_exp.Text = personagem_Model.EXPAtual + " / " + (personagem_Model.Nivel * 500);
                lbl_tonz.Text = personagem_Model.Tonz.ToString();


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
                            d100 = Rolar.D100();
                            CarregaPersonagem();
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
                lbl_aura.Text = personagem_Model.Aura.ToString();
                lbl_raca.Text = personagem_Model.Raca;
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
                if (Convert.ToInt16(IDPersonagem) < 5)
                {
                    int nivel1 = estigma_Control.GetNivel("1", IDPersonagem);
                    int nivel2 = estigma_Control.GetNivel("2", IDPersonagem);
                    int nivel3 = estigma_Control.GetNivel("3", IDPersonagem);
                    int nivel4 = estigma_Control.GetNivel("4", IDPersonagem);

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

                GPB_status_atributos.Text = "Pontos Disponíveis " + ValorAtributo;

                if (ValorAtributo > 0)
                {
                    ControleBotao(true);
                }
                else
                {
                    ControleBotao(false);
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Força."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Força. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Força."
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Vitalidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Vitalidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Vitalidade."
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Foco."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Foco. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Foco."
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Velocidade."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Velocidade. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Velocidade."
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Magia."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Magia. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Magia."
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
            Carrega_Tela();

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
            tt.SetToolTip(img_valor_critico, "Cálculo do acerto crítico");
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
                        txt_status.Text = personagem_Model.Nome + " realizou um acerto crítico no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto crítico no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 2:
                        txt_status.Text = personagem_Model.Nome + " teve sucesso no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Realizou um acerto no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 3:
                        txt_status.Text = personagem_Model.Nome + " falhou no teste de Aura."
                                        + "\r\n\r\nValor do Teste: " + ValorTeste + "\r\nValor do Dado: " + d100;
                        Insertlog("Falhou no teste de Aura. Valor do Teste: " + ValorTeste + " Valor do Dado: " + d100);
                        break;
                    case 4:
                        txt_status.Text = personagem_Model.Nome + " realizou uma falha crítica no teste de Aura."
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

       

        #endregion

        #region INFORMAÇÕES DA ABA BATALHA

        private void Carrega_Batalha()
        {
            CBB_nome_personagem.Text = "Selecione";
            txt_reduzir.Maximum = 999999;
            txt_defender.Maximum = 999999;
            txt_reduzir.Controls[0].Visible = false;
            txt_defender.Controls[0].Visible = false;
            txt_defender.Text = "";
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

                throw new Exception("Falha ao carregar ComboBox Nome do Personagem: "+ ex.Message);
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            label23.Text = CBB_nome_personagem.SelectedValue.ToString();
        }
        private void CBB_nome_personagem_Click(object sender, EventArgs e)
        {
            Carrega_Combobox_Personagem();
        }

        private void btn_small_potion_Click(object sender, EventArgs e)
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
                        Carrega_Tela();
                        txt_batalha.Text = personagem_Model.Nome + " acaba de consumir uma Poção Pequena. Recuperando +";
                        txt_batalha.Text += (personagem_Model.HPMax * 0.30) + " do seu HP.";
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
        #endregion



    }
}
