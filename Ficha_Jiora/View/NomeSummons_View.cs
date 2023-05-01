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
    public partial class NomeSummons_View : Form
    {
        public string IDPersonagem { get; set; }
        public string IDSummon { get; set; }
        private Summon_Control summon_Control = new Summon_Control();
        private Summon_Model summon_Model = new Summon_Model();

        public NomeSummons_View()
        {
            InitializeComponent();
        }

        private void btn_invocar_Click(object sender, EventArgs e)
        {
            Summon_view summon_View = new Summon_view();
            summon_View.IDPersonagem = IDPersonagem;
            summon_View.IDSummon = summon_Control.GetIdSummons(txt_nome.Text, IDPersonagem).ToString();

            if (summon_View.IDSummon == "")
            {
                MessageBox.Show("Summon Não encontrado!","Não existe",MessageBoxButtons.OK);
            }
            else
            {
                summon_Model = summon_Control.CarregaSummon(summon_View.IDSummon, IDPersonagem);

                if (summon_Model.HPAtual == 0)
                {
                    MessageBox.Show(summon_Model.Nome + " não pode ser chamado, pois está com 0 de HP.", "Fora de Combate", MessageBoxButtons.OK);
                }
                else
                {
                    summon_View.Show();
                }
                
            }
                      
            this.Close();
        }

        private void NomeSummons_View_Load(object sender, EventArgs e)
        {

        }
    }
}
