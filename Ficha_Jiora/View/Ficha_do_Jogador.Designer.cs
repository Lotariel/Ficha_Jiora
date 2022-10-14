namespace Ficha_Jiora.View
{
    partial class Ficha_do_Jogador
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.img_imagem_personagem = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Status = new System.Windows.Forms.TabPage();
            this.batalha = new System.Windows.Forms.TabPage();
            this.pericia = new System.Windows.Forms.TabPage();
            this.btn_salvar_pericia = new System.Windows.Forms.Button();
            this.lbl_pontos_pericia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pericia = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Teste = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salvar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pericia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventario = new System.Windows.Forms.TabPage();
            this.Mapa = new System.Windows.Forms.TabPage();
            this.Log = new System.Windows.Forms.TabPage();
            this.dtg_log = new System.Windows.Forms.DataGridView();
            this.txt_nome_personagem = new System.Windows.Forms.TextBox();
            this.btn_atualiza = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_nome_personagem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_nivel_personagem = new System.Windows.Forms.Label();
            this.lbl_classe_peronsagem = new System.Windows.Forms.Label();
            this.bs_personagem = new System.Windows.Forms.BindingSource(this.components);
            this.BS_Log = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.img_imagem_personagem)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pericia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_personagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // img_imagem_personagem
            // 
            this.img_imagem_personagem.Location = new System.Drawing.Point(12, 12);
            this.img_imagem_personagem.Name = "img_imagem_personagem";
            this.img_imagem_personagem.Size = new System.Drawing.Size(282, 378);
            this.img_imagem_personagem.TabIndex = 0;
            this.img_imagem_personagem.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Status);
            this.tabControl1.Controls.Add(this.batalha);
            this.tabControl1.Controls.Add(this.pericia);
            this.tabControl1.Controls.Add(this.inventario);
            this.tabControl1.Controls.Add(this.Mapa);
            this.tabControl1.Controls.Add(this.Log);
            this.tabControl1.Location = new System.Drawing.Point(314, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 528);
            this.tabControl1.TabIndex = 1;
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(4, 24);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(3);
            this.Status.Size = new System.Drawing.Size(955, 500);
            this.Status.TabIndex = 0;
            this.Status.Text = "Status";
            this.Status.UseVisualStyleBackColor = true;
            // 
            // batalha
            // 
            this.batalha.Location = new System.Drawing.Point(4, 24);
            this.batalha.Name = "batalha";
            this.batalha.Padding = new System.Windows.Forms.Padding(3);
            this.batalha.Size = new System.Drawing.Size(955, 500);
            this.batalha.TabIndex = 1;
            this.batalha.Text = "Batalha";
            this.batalha.UseVisualStyleBackColor = true;
            // 
            // pericia
            // 
            this.pericia.Controls.Add(this.btn_salvar_pericia);
            this.pericia.Controls.Add(this.lbl_pontos_pericia);
            this.pericia.Controls.Add(this.label1);
            this.pericia.Controls.Add(this.txt_pericia);
            this.pericia.Controls.Add(this.dataGridView1);
            this.pericia.Location = new System.Drawing.Point(4, 24);
            this.pericia.Name = "pericia";
            this.pericia.Size = new System.Drawing.Size(955, 500);
            this.pericia.TabIndex = 2;
            this.pericia.Text = "Perícia";
            this.pericia.UseVisualStyleBackColor = true;
            // 
            // btn_salvar_pericia
            // 
            this.btn_salvar_pericia.Location = new System.Drawing.Point(773, 256);
            this.btn_salvar_pericia.Name = "btn_salvar_pericia";
            this.btn_salvar_pericia.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar_pericia.TabIndex = 4;
            this.btn_salvar_pericia.Text = "Editar";
            this.btn_salvar_pericia.UseVisualStyleBackColor = true;
            this.btn_salvar_pericia.Visible = false;
            this.btn_salvar_pericia.Click += new System.EventHandler(this.btn_salvar_pericia_Click);
            // 
            // lbl_pontos_pericia
            // 
            this.lbl_pontos_pericia.AutoSize = true;
            this.lbl_pontos_pericia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_pontos_pericia.Location = new System.Drawing.Point(883, 205);
            this.lbl_pontos_pericia.Name = "lbl_pontos_pericia";
            this.lbl_pontos_pericia.Size = new System.Drawing.Size(22, 25);
            this.lbl_pontos_pericia.TabIndex = 3;
            this.lbl_pontos_pericia.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(716, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pontos a Distribuir:";
            // 
            // txt_pericia
            // 
            this.txt_pericia.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_pericia.Location = new System.Drawing.Point(716, 50);
            this.txt_pericia.Multiline = true;
            this.txt_pericia.Name = "txt_pericia";
            this.txt_pericia.Size = new System.Drawing.Size(189, 110);
            this.txt_pericia.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Teste,
            this.Nome,
            this.Valor,
            this.salvar,
            this.descricao,
            this.id_pericia});
            this.dataGridView1.Location = new System.Drawing.Point(34, 27);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 120;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(635, 457);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Teste
            // 
            this.Teste.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Teste.DataPropertyName = "teste";
            this.Teste.HeaderText = "Teste";
            this.Teste.Name = "Teste";
            this.Teste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Teste.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Teste.Text = "Teste";
            this.Teste.ToolTipText = "Fazer Teste";
            this.Teste.Width = 5;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Nome.DataPropertyName = "Nome";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Nome.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 5;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "CDS (%)";
            this.Valor.Name = "Valor";
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Valor.Width = 75;
            // 
            // salvar
            // 
            this.salvar.DataPropertyName = "Salvar";
            this.salvar.HeaderText = "Salvar";
            this.salvar.Name = "salvar";
            this.salvar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salvar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.salvar.Visible = false;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "Descrição";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.descricao.DefaultCellStyle = dataGridViewCellStyle5;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.descricao.Width = 230;
            // 
            // id_pericia
            // 
            this.id_pericia.DataPropertyName = "id_pericia";
            this.id_pericia.HeaderText = "ID Pericia";
            this.id_pericia.Name = "id_pericia";
            this.id_pericia.Visible = false;
            // 
            // inventario
            // 
            this.inventario.Location = new System.Drawing.Point(4, 24);
            this.inventario.Name = "inventario";
            this.inventario.Size = new System.Drawing.Size(955, 500);
            this.inventario.TabIndex = 3;
            this.inventario.Text = "Inventário";
            this.inventario.UseVisualStyleBackColor = true;
            // 
            // Mapa
            // 
            this.Mapa.Location = new System.Drawing.Point(4, 24);
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(955, 500);
            this.Mapa.TabIndex = 4;
            this.Mapa.Text = "Mapa";
            this.Mapa.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            this.Log.Controls.Add(this.dtg_log);
            this.Log.Location = new System.Drawing.Point(4, 24);
            this.Log.Name = "Log";
            this.Log.Padding = new System.Windows.Forms.Padding(3);
            this.Log.Size = new System.Drawing.Size(955, 500);
            this.Log.TabIndex = 5;
            this.Log.Text = "log";
            this.Log.UseVisualStyleBackColor = true;
            // 
            // dtg_log
            // 
            this.dtg_log.AllowUserToAddRows = false;
            this.dtg_log.AllowUserToDeleteRows = false;
            this.dtg_log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dtg_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_log.Location = new System.Drawing.Point(6, 6);
            this.dtg_log.Name = "dtg_log";
            this.dtg_log.ReadOnly = true;
            this.dtg_log.RowTemplate.Height = 25;
            this.dtg_log.Size = new System.Drawing.Size(943, 402);
            this.dtg_log.TabIndex = 0;
            // 
            // txt_nome_personagem
            // 
            this.txt_nome_personagem.Location = new System.Drawing.Point(1096, 12);
            this.txt_nome_personagem.Name = "txt_nome_personagem";
            this.txt_nome_personagem.Size = new System.Drawing.Size(100, 23);
            this.txt_nome_personagem.TabIndex = 2;
            // 
            // btn_atualiza
            // 
            this.btn_atualiza.Location = new System.Drawing.Point(1202, 12);
            this.btn_atualiza.Name = "btn_atualiza";
            this.btn_atualiza.Size = new System.Drawing.Size(75, 23);
            this.btn_atualiza.TabIndex = 3;
            this.btn_atualiza.Text = "Atualizar";
            this.btn_atualiza.UseVisualStyleBackColor = true;
            this.btn_atualiza.Click += new System.EventHandler(this.btn_atualiza_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 228);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atributos";
            // 
            // lbl_nome_personagem
            // 
            this.lbl_nome_personagem.AutoSize = true;
            this.lbl_nome_personagem.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_nome_personagem.Location = new System.Drawing.Point(314, 9);
            this.lbl_nome_personagem.Name = "lbl_nome_personagem";
            this.lbl_nome_personagem.Size = new System.Drawing.Size(90, 37);
            this.lbl_nome_personagem.TabIndex = 5;
            this.lbl_nome_personagem.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(318, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nv.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(678, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "10 / Libra / 1695";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(678, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clima: Tropical";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(681, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 37);
            this.label5.TabIndex = 9;
            this.label5.Text = "Período: Noite";
            // 
            // lbl_nivel_personagem
            // 
            this.lbl_nivel_personagem.AutoSize = true;
            this.lbl_nivel_personagem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_nivel_personagem.Location = new System.Drawing.Point(352, 66);
            this.lbl_nivel_personagem.Name = "lbl_nivel_personagem";
            this.lbl_nivel_personagem.Size = new System.Drawing.Size(45, 28);
            this.lbl_nivel_personagem.TabIndex = 10;
            this.lbl_nivel_personagem.Text = "999";
            // 
            // lbl_classe_peronsagem
            // 
            this.lbl_classe_peronsagem.AutoSize = true;
            this.lbl_classe_peronsagem.Location = new System.Drawing.Point(321, 49);
            this.lbl_classe_peronsagem.Name = "lbl_classe_peronsagem";
            this.lbl_classe_peronsagem.Size = new System.Drawing.Size(40, 15);
            this.lbl_classe_peronsagem.TabIndex = 11;
            this.lbl_classe_peronsagem.Text = "Classe";
            // 
            // Ficha_do_Jogador
            // 
            this.AcceptButton = this.btn_atualiza;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 650);
            this.Controls.Add(this.lbl_classe_peronsagem);
            this.Controls.Add(this.lbl_nivel_personagem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_nome_personagem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_atualiza);
            this.Controls.Add(this.txt_nome_personagem);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.img_imagem_personagem);
            this.Name = "Ficha_do_Jogador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha";
            ((System.ComponentModel.ISupportInitialize)(this.img_imagem_personagem)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.pericia.ResumeLayout(false);
            this.pericia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_personagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Log)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox img_imagem_personagem;
        private TabControl tabControl1;
        private TabPage Status;
        private TabPage batalha;
        private TextBox txt_nome_personagem;
        private Button btn_atualiza;
        private GroupBox groupBox1;
        private Label lbl_nome_personagem;
        private TabPage pericia;
        private TabPage inventario;
        private TabPage Mapa;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbl_nivel_personagem;
        private Label lbl_classe_peronsagem;
        private DataGridView dataGridView1;
        private BindingSource bs_personagem;
        private TabPage Log;
        private DataGridView dtg_log;
        private BindingSource BS_Log;
        private TextBox txt_pericia;
        private Button btn_salvar_pericia;
        private Label lbl_pontos_pericia;
        private Label label1;
        private DataGridViewButtonColumn Teste;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewButtonColumn salvar;
        private DataGridViewTextBoxColumn descricao;
        private DataGridViewTextBoxColumn id_pericia;
    }
}