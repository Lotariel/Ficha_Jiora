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
    public partial class Summon_view : Form
    {
        private Summon_Model summon_Model = new Summon_Model();
        private Summon_Control summon_Control = new Summon_Control();
        private Personagem_Model personagem_Model = new Personagem_Model();
        private Personagem_Control personagem_Control = new Personagem_Control();
        private Random random = new Random();
        Batalha_Control batalha;
        public string IDPersonagem { get; set; }
        public string IDSummon { get; set; }
        public Summon_view()
        {
            InitializeComponent();
        }


        private void CarregaTela(int AtivarTexto)
        {
            try
            {
                personagem_Model = personagem_Control.Carrega_Personagem(IDPersonagem);
                summon_Model = summon_Control.CarregaSummon(IDSummon, IDPersonagem);
                lbl_nome.Text = summon_Model.Nome;
                img_perfil.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Perfil\\" + summon_Model.Imagem);
                lbl_hpmax.Text = "/ " + (summon_Model.MaxHP * personagem_Model.HPMax);
                lbl_hpatual.Text = summon_Model.HPAtual.ToString();
                if (AtivarTexto == 1)
                {
                    MessageBox.Show(summon_Model.TextoInvocacao, "Invocação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                batalha = new Batalha_Control(personagem_Model);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhar ao carregar tela de Summon " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void iniciativa_Click(object sender, EventArgs e)
        {
            txt_texto.Text = "Valor da iniciativa: " + random.Next(1, 21);
        }

        private void btn_liberar_Click(object sender, EventArgs e)
        {
            LiberarSummon();
        }
        private void LiberarSummon()
        {
            MessageBox.Show(summon_Model.Nome + " retorna para dentro de seu invocador.", "Alert");
            this.Close();
        }

        private void Summon_view_Load(object sender, EventArgs e)
        {
            CarregaTela(1);
            txt_hp.Controls[0].Visible = false;
            txt_hp.Maximum = 999999;
            CarregaComboMagia();
            CarregaComboHabilidades();

        }

        private void btn_atacar_Click(object sender, EventArgs e)
        {
            Batalha_Control batalha = new Batalha_Control(personagem_Model);
            int dado = summon_Model.Dado;
            int quantidade = summon_Model.QuantidadeDado;
            string atributo = summon_Model.AtributoAtaque;
            int valorBase = summon_Model.ValorBaseAtaque;
            int forPersonagem = personagem_Model.Forca + personagem_Model.ModForca;
            int focPersonagem = personagem_Model.Foco + personagem_Model.ModFoco;
            int magPersonagem = personagem_Model.Magia + personagem_Model.ModMagia;
            int d100 = random.Next(1, 101);
            switch (atributo)
            {
                case "FOR":
                    summon_Model.AtaqueFinal = (valorBase * forPersonagem) + random.Next(quantidade, (quantidade * dado));
                    break;

                case "MAG":
                    summon_Model.AtaqueFinal = (valorBase * magPersonagem) + random.Next(quantidade, (quantidade * dado));
                    break;

                case "FOC":
                    summon_Model.AtaqueFinal = (valorBase * focPersonagem) + random.Next(quantidade, (quantidade * dado));
                    break;
                default:
                    break;
            }
            if (d100 <= batalha.Precisao())
            {
                txt_texto.Text = "~~~~ Ataque Básico ~~~~\r\n\r\n";
                txt_texto.Text += summon_Model.Nome + " ataca físicamente seu alvo.\r\n";
                txt_texto.Text += "Causando " + summon_Model.AtaqueFinal + " de Dano Físico.";
            }
            else
            {
                txt_texto.Text = "~~~~ Ataque Básico ~~~~\r\n\r\n";
                txt_texto.Text += summon_Model.Nome + " errou o ataque. O Alvo se esquivou de seu ataque!";
            }

        }

        private void btn_reduzhp_Click(object sender, EventArgs e)
        {
            if (txt_hp.Text == "")
            {
                MessageBox.Show("Informe o valor do Dano Recebido.", "Alert");
            }
            else
            {
                int valorDanoRecebido = Convert.ToInt32(txt_hp.Text);
                summon_Control.ReduzHp(summon_Model, valorDanoRecebido);
                txt_texto.Text = "~~~~ Dano Recebido ~~~~\r\n\r\n";
                txt_texto.Text += summon_Model.Nome + " perdeu " + txt_hp.Text + " de HP.";
                CarregaTela(0);
                txt_hp.Text = "0";

                if (summon_Model.HPAtual == 0)
                {
                    LiberarSummon();
                }
            }

        }

        private void btn_aguardar_Click(object sender, EventArgs e)
        {
            txt_texto.Text = "~~~~ Aguardando ~~~~\r\n\r\n";
            txt_texto.Text += summon_Model.Nome + " fica aguardando a próxima ordem do evocador";
        }

        private void btn_magia_Click(object sender, EventArgs e)
        {
            try
            {
                Magia_Model magia = new Magia_Model();
                Random random = new Random();
                magia = batalha.Carrega_Magia(cbb_magia.SelectedValue.ToString());

                int Dano = Convert.ToInt32((magia.Multiplicador * personagem_Model.Magia) + random.Next(magia.ValorMin, magia.ValorMax + 1));
                if (personagem_Model.MPAtual >= magia.ValorCusto)
                {
                    txt_texto.Text = "~~~~ " + magia.Nome + "~~~~\r\n\r\n";
                    txt_texto.Text += magia.Descricao;
                    txt_texto.Text += "\r\n\r\nDano: " + Dano + " " + magia.TipoDano;
                    txt_texto.Text += "\r\nCusto: " + magia.ValorCusto + " " + magia.TipoCusto;
                    txt_texto.Text += "\r\nAlvo: " + magia.Alvo + "\r\nCDS Efeito: " + magia.CDSEfeito;
                    txt_texto.Text += " %\r\nEfeito: " + magia.Efeito;
                    batalha.ReduzirMPAtual(personagem_Model.ID, magia.ValorCusto);

                }
                else
                {
                    MessageBox.Show("Mana insuficiente.", "Sem Mana", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                CarregaTela(0);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void CarregaComboMagia()
        {
            Batalha_Control batalha = new Batalha_Control(personagem_Model);

            cbb_magia.DataSource = batalha.Carrega_Combo_Magia_Summon(summon_Model);
            cbb_magia.DisplayMember = "Nome";
            cbb_magia.ValueMember = "ID";
        }
        private void CarregaComboHabilidades()
        {
            try
            {
                cbb_habilidade.DataSource = batalha.Carrega_Combo_Habilidade_summon(summon_Model);
                cbb_habilidade.DisplayMember = "Nome";
                cbb_habilidade.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao carregar ComboBox Nome das Habilidades: " + ex.Message);
            }

        }

        private void btn_habilidade_Click(object sender, EventArgs e)
        {
            Habilidade_Model habilidade = new Habilidade_Model();
            object habilidadeSelecionada = cbb_habilidade.SelectedValue;


            if (habilidadeSelecionada == null)
            {
                txt_texto.Text = "Nenhuma Habilidade Foi Selecionada.";
            }
            else
            {
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
                int d100 = random.Next(1, 101);
                if (personagem_Model.MPAtual < custo && tipocusto == "MP")
                {
                    MessageBox.Show("Mana insuficiente para usar habilidade.", "Sem Mana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregaTela(0);
                }
                else
                {
                    if (d100 <= CDA)
                    {

                        txt_texto.Text = "Você acertou a habilidade " + habilidade.Nome;


                        if (tipocusto == "MP")
                        {
                            batalha.ReduzirMPAtual(personagem_Model.ID, custo);
                        }


                        if (habilidade.HIT <= 1)
                        {
                            txt_texto.Text += "Dano: " + dano + " " + tipodano + "\r\n";
                        }
                        else
                        {
                            for (int i = 0; i < habilidade.HIT; i++)
                            {
                                dano = Math.Ceiling(habilidade.Multiplicador * batalha.ValordoAtaque());
                                txt_texto.Text += contador + "º Dano: " + dano + " " + tipodano + "\r\n";
                                contador++;
                            }
                        }

                        txt_texto.Text += "Custo: " + custo + " " + tipocusto;
                        txt_texto.Text += "\r\nAlvo: " + alvo + "\r\nHit: " + Hit + "\r\nCategoria: " + habilidade.Atributo + "\r\nChance de Acerto: " + CDA + " %\r\n";
                        txt_texto.Text += "CDS Efeito: " + habilidade.CDSEfeito + " %\r\nEfeito: " + efeito + "\r\nDescrição:\r\n";
                        txt_texto.Text += descricao;

                        CarregaTela(0);

                    }
                    else
                    {
                        txt_texto.Text = summon_Model.Nome + " errou a habilidade.\r\n\r\n";
                        txt_texto.Text += "Valor do Dado: " + d100;
                        txt_texto.Text += "\r\nChance de Acerto: " + CDA;

                    }
                }
            }

        }


    }
}

