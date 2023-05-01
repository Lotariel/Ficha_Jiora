namespace Ficha_Jiora.View
{
    partial class Summon_view
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
            this.img_perfil = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_texto = new System.Windows.Forms.TextBox();
            this.btn_atacar = new System.Windows.Forms.Button();
            this.cbb_habilidade = new System.Windows.Forms.ComboBox();
            this.iniciativa = new System.Windows.Forms.Button();
            this.btn_aguardar = new System.Windows.Forms.Button();
            this.btn_liberar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_magia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_reduzhp = new System.Windows.Forms.Button();
            this.lbl_hpatual = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.lbl_hpmax = new System.Windows.Forms.Label();
            this.txt_hp = new System.Windows.Forms.NumericUpDown();
            this.btn_magia = new System.Windows.Forms.Button();
            this.btn_habilidade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hp)).BeginInit();
            this.SuspendLayout();
            // 
            // img_perfil
            // 
            this.img_perfil.Location = new System.Drawing.Point(12, 12);
            this.img_perfil.Name = "img_perfil";
            this.img_perfil.Size = new System.Drawing.Size(122, 136);
            this.img_perfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_perfil.TabIndex = 0;
            this.img_perfil.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(153, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "HP:";
            // 
            // txt_texto
            // 
            this.txt_texto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_texto.Location = new System.Drawing.Point(43, 253);
            this.txt_texto.Multiline = true;
            this.txt_texto.Name = "txt_texto";
            this.txt_texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_texto.Size = new System.Drawing.Size(245, 115);
            this.txt_texto.TabIndex = 2;
            // 
            // btn_atacar
            // 
            this.btn_atacar.Location = new System.Drawing.Point(234, 94);
            this.btn_atacar.Name = "btn_atacar";
            this.btn_atacar.Size = new System.Drawing.Size(75, 23);
            this.btn_atacar.TabIndex = 3;
            this.btn_atacar.Text = "Atacar";
            this.btn_atacar.UseVisualStyleBackColor = true;
            this.btn_atacar.Click += new System.EventHandler(this.btn_atacar_Click);
            // 
            // cbb_habilidade
            // 
            this.cbb_habilidade.FormattingEnabled = true;
            this.cbb_habilidade.Location = new System.Drawing.Point(27, 183);
            this.cbb_habilidade.Name = "cbb_habilidade";
            this.cbb_habilidade.Size = new System.Drawing.Size(126, 23);
            this.cbb_habilidade.TabIndex = 4;
            // 
            // iniciativa
            // 
            this.iniciativa.Location = new System.Drawing.Point(153, 94);
            this.iniciativa.Name = "iniciativa";
            this.iniciativa.Size = new System.Drawing.Size(75, 23);
            this.iniciativa.TabIndex = 5;
            this.iniciativa.Text = "Iniciativa";
            this.iniciativa.UseVisualStyleBackColor = true;
            this.iniciativa.Click += new System.EventHandler(this.iniciativa_Click);
            // 
            // btn_aguardar
            // 
            this.btn_aguardar.Location = new System.Drawing.Point(153, 123);
            this.btn_aguardar.Name = "btn_aguardar";
            this.btn_aguardar.Size = new System.Drawing.Size(75, 23);
            this.btn_aguardar.TabIndex = 6;
            this.btn_aguardar.Text = "Aguardar";
            this.btn_aguardar.UseVisualStyleBackColor = true;
            this.btn_aguardar.Click += new System.EventHandler(this.btn_aguardar_Click);
            // 
            // btn_liberar
            // 
            this.btn_liberar.Location = new System.Drawing.Point(234, 123);
            this.btn_liberar.Name = "btn_liberar";
            this.btn_liberar.Size = new System.Drawing.Size(75, 23);
            this.btn_liberar.TabIndex = 7;
            this.btn_liberar.Text = "Liberar";
            this.btn_liberar.UseVisualStyleBackColor = true;
            this.btn_liberar.Click += new System.EventHandler(this.btn_liberar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Habilidades";
            // 
            // cbb_magia
            // 
            this.cbb_magia.FormattingEnabled = true;
            this.cbb_magia.Location = new System.Drawing.Point(180, 183);
            this.cbb_magia.Name = "cbb_magia";
            this.cbb_magia.Size = new System.Drawing.Size(126, 23);
            this.cbb_magia.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Magia";
            // 
            // btn_reduzhp
            // 
            this.btn_reduzhp.Location = new System.Drawing.Point(234, 59);
            this.btn_reduzhp.Name = "btn_reduzhp";
            this.btn_reduzhp.Size = new System.Drawing.Size(75, 23);
            this.btn_reduzhp.TabIndex = 12;
            this.btn_reduzhp.Text = "Reduzir HP";
            this.btn_reduzhp.UseVisualStyleBackColor = true;
            this.btn_reduzhp.Click += new System.EventHandler(this.btn_reduzhp_Click);
            // 
            // lbl_hpatual
            // 
            this.lbl_hpatual.AutoSize = true;
            this.lbl_hpatual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_hpatual.Location = new System.Drawing.Point(189, 35);
            this.lbl_hpatual.Name = "lbl_hpatual";
            this.lbl_hpatual.Size = new System.Drawing.Size(37, 21);
            this.lbl_hpatual.TabIndex = 13;
            this.lbl_hpatual.Text = "999";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_nome.Location = new System.Drawing.Point(153, 12);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(56, 21);
            this.lbl_nome.TabIndex = 14;
            this.lbl_nome.Text = "NOME";
            // 
            // lbl_hpmax
            // 
            this.lbl_hpmax.AutoSize = true;
            this.lbl_hpmax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_hpmax.Location = new System.Drawing.Point(221, 35);
            this.lbl_hpmax.Name = "lbl_hpmax";
            this.lbl_hpmax.Size = new System.Drawing.Size(56, 21);
            this.lbl_hpmax.TabIndex = 15;
            this.lbl_hpmax.Text = "/ 9999";
            // 
            // txt_hp
            // 
            this.txt_hp.Location = new System.Drawing.Point(153, 59);
            this.txt_hp.Name = "txt_hp";
            this.txt_hp.Size = new System.Drawing.Size(75, 23);
            this.txt_hp.TabIndex = 16;
            // 
            // btn_magia
            // 
            this.btn_magia.Location = new System.Drawing.Point(202, 212);
            this.btn_magia.Name = "btn_magia";
            this.btn_magia.Size = new System.Drawing.Size(75, 23);
            this.btn_magia.TabIndex = 17;
            this.btn_magia.Text = "Usar";
            this.btn_magia.UseVisualStyleBackColor = true;
            this.btn_magia.Click += new System.EventHandler(this.btn_magia_Click);
            // 
            // btn_habilidade
            // 
            this.btn_habilidade.Location = new System.Drawing.Point(54, 212);
            this.btn_habilidade.Name = "btn_habilidade";
            this.btn_habilidade.Size = new System.Drawing.Size(75, 23);
            this.btn_habilidade.TabIndex = 18;
            this.btn_habilidade.Text = "Usar";
            this.btn_habilidade.UseVisualStyleBackColor = true;
            this.btn_habilidade.Click += new System.EventHandler(this.btn_habilidade_Click);
            // 
            // Summon_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 380);
            this.Controls.Add(this.btn_habilidade);
            this.Controls.Add(this.btn_magia);
            this.Controls.Add(this.txt_hp);
            this.Controls.Add(this.lbl_hpatual);
            this.Controls.Add(this.lbl_hpmax);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.btn_reduzhp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_magia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_liberar);
            this.Controls.Add(this.btn_aguardar);
            this.Controls.Add(this.iniciativa);
            this.Controls.Add(this.cbb_habilidade);
            this.Controls.Add(this.btn_atacar);
            this.Controls.Add(this.txt_texto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.img_perfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Summon_view";
            this.Load += new System.EventHandler(this.Summon_view_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox img_perfil;
        private Label label1;
        private TextBox txt_texto;
        private Button btn_atacar;
        private ComboBox cbb_habilidade;
        private Button iniciativa;
        private Button btn_aguardar;
        private Button btn_liberar;
        private Label label2;
        private ComboBox cbb_magia;
        private Label label3;
        private Button btn_reduzhp;
        private Label lbl_hpatual;
        private Label lbl_nome;
        private Label lbl_hpmax;
        private NumericUpDown txt_hp;
        private Button btn_magia;
        private Button btn_habilidade;
    }
}