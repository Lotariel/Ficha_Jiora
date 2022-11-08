namespace Ficha_Jiora.View
{
    partial class Tela_Do_Mestre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbb_atributo = new System.Windows.Forms.ComboBox();
            this.cbb_persona_atrib = new System.Windows.Forms.ComboBox();
            this.txt_valor_atrib = new System.Windows.Forms.TextBox();
            this.btn_aplicar_atrib = new System.Windows.Forms.Button();
            this.btn_reduzir = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_atributo
            // 
            this.cbb_atributo.FormattingEnabled = true;
            this.cbb_atributo.Items.AddRange(new object[] {
            "HP",
            "MP",
            "EXP",
            "Tonz"});
            this.cbb_atributo.Location = new System.Drawing.Point(7, 56);
            this.cbb_atributo.Name = "cbb_atributo";
            this.cbb_atributo.Size = new System.Drawing.Size(121, 23);
            this.cbb_atributo.TabIndex = 0;
            // 
            // cbb_persona_atrib
            // 
            this.cbb_persona_atrib.FormattingEnabled = true;
            this.cbb_persona_atrib.Items.AddRange(new object[] {
            "Lotariel",
            "Ryoujimbo",
            "Raktharof",
            "Zereni",
            "Kazumi"});
            this.cbb_persona_atrib.Location = new System.Drawing.Point(155, 56);
            this.cbb_persona_atrib.Name = "cbb_persona_atrib";
            this.cbb_persona_atrib.Size = new System.Drawing.Size(121, 23);
            this.cbb_persona_atrib.TabIndex = 1;
            // 
            // txt_valor_atrib
            // 
            this.txt_valor_atrib.Location = new System.Drawing.Point(303, 56);
            this.txt_valor_atrib.Name = "txt_valor_atrib";
            this.txt_valor_atrib.Size = new System.Drawing.Size(55, 23);
            this.txt_valor_atrib.TabIndex = 2;
            // 
            // btn_aplicar_atrib
            // 
            this.btn_aplicar_atrib.Location = new System.Drawing.Point(381, 37);
            this.btn_aplicar_atrib.Name = "btn_aplicar_atrib";
            this.btn_aplicar_atrib.Size = new System.Drawing.Size(75, 23);
            this.btn_aplicar_atrib.TabIndex = 3;
            this.btn_aplicar_atrib.Text = "Aplicar";
            this.btn_aplicar_atrib.UseVisualStyleBackColor = true;
            this.btn_aplicar_atrib.Click += new System.EventHandler(this.btn_aplicar_atrib_Click);
            // 
            // btn_reduzir
            // 
            this.btn_reduzir.Location = new System.Drawing.Point(381, 66);
            this.btn_reduzir.Name = "btn_reduzir";
            this.btn_reduzir.Size = new System.Drawing.Size(75, 23);
            this.btn_reduzir.TabIndex = 8;
            this.btn_reduzir.Text = "Reduzir";
            this.btn_reduzir.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(303, 291);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 23);
            this.textBox2.TabIndex = 7;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(155, 291);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 6;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(7, 291);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Efeitos";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(381, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Aplicar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(381, 304);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Curar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Atributo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Personagem";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Valor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Personagem";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Turno";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-3, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 591);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbb_persona_atrib);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbb_atributo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_valor_atrib);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btn_aplicar_atrib);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.btn_reduzir);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.comboBox4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 563);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bestiário";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(598, 563);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Loja";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Tela_Do_Mestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 591);
            this.Controls.Add(this.tabControl1);
            this.Name = "Tela_Do_Mestre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela_Do_Mestre";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbb_atributo;
        private ComboBox cbb_persona_atrib;
        private TextBox txt_valor_atrib;
        private Button btn_aplicar_atrib;
        private Button btn_reduzir;
        private TextBox textBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label2;
        private Button button3;
        private Button button4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}