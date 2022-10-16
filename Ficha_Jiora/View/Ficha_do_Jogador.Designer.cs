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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ficha_do_Jogador));
            this.img_imagem_personagem = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Status = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_nascimento = new System.Windows.Forms.Label();
            this.lbl_peso = new System.Windows.Forms.Label();
            this.lbl_altura = new System.Windows.Forms.Label();
            this.lbl_cabelo = new System.Windows.Forms.Label();
            this.lbl_olhos = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.lbl_resistencia = new System.Windows.Forms.Label();
            this.lbl_defesa = new System.Windows.Forms.Label();
            this.img_resistencia = new System.Windows.Forms.PictureBox();
            this.img_defesa = new System.Windows.Forms.PictureBox();
            this.lbl_nome_personagem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_nivel_personagem = new System.Windows.Forms.Label();
            this.lbl_classe_peronsagem = new System.Windows.Forms.Label();
            this.bs_personagem = new System.Windows.Forms.BindingSource(this.components);
            this.BS_Log = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_imagem_personagem)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Status.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pericia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_resistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_defesa)).BeginInit();
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
            this.Status.Controls.Add(this.groupBox3);
            this.Status.Controls.Add(this.groupBox2);
            this.Status.Location = new System.Drawing.Point(4, 24);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(3);
            this.Status.Size = new System.Drawing.Size(955, 500);
            this.Status.TabIndex = 0;
            this.Status.Text = "Status";
            this.Status.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(6, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 232);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 15);
            this.label18.TabIndex = 11;
            this.label18.Text = "Aura";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "Magia";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Velocidade";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Foco";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Vitalidade";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Força";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_nascimento);
            this.groupBox2.Controls.Add(this.lbl_peso);
            this.groupBox2.Controls.Add(this.lbl_altura);
            this.groupBox2.Controls.Add(this.lbl_cabelo);
            this.groupBox2.Controls.Add(this.lbl_olhos);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 250);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sobre";
            // 
            // lbl_nascimento
            // 
            this.lbl_nascimento.AutoSize = true;
            this.lbl_nascimento.Location = new System.Drawing.Point(11, 200);
            this.lbl_nascimento.Name = "lbl_nascimento";
            this.lbl_nascimento.Size = new System.Drawing.Size(16, 15);
            this.lbl_nascimento.TabIndex = 10;
            this.lbl_nascimento.Text = "N";
            // 
            // lbl_peso
            // 
            this.lbl_peso.AutoSize = true;
            this.lbl_peso.Location = new System.Drawing.Point(12, 160);
            this.lbl_peso.Name = "lbl_peso";
            this.lbl_peso.Size = new System.Drawing.Size(14, 15);
            this.lbl_peso.TabIndex = 9;
            this.lbl_peso.Text = "P";
            // 
            // lbl_altura
            // 
            this.lbl_altura.AutoSize = true;
            this.lbl_altura.Location = new System.Drawing.Point(12, 120);
            this.lbl_altura.Name = "lbl_altura";
            this.lbl_altura.Size = new System.Drawing.Size(15, 15);
            this.lbl_altura.TabIndex = 8;
            this.lbl_altura.Text = "A";
            // 
            // lbl_cabelo
            // 
            this.lbl_cabelo.AutoSize = true;
            this.lbl_cabelo.Location = new System.Drawing.Point(12, 80);
            this.lbl_cabelo.Name = "lbl_cabelo";
            this.lbl_cabelo.Size = new System.Drawing.Size(15, 15);
            this.lbl_cabelo.TabIndex = 7;
            this.lbl_cabelo.Text = "C";
            // 
            // lbl_olhos
            // 
            this.lbl_olhos.AutoSize = true;
            this.lbl_olhos.Location = new System.Drawing.Point(12, 40);
            this.lbl_olhos.Name = "lbl_olhos";
            this.lbl_olhos.Size = new System.Drawing.Size(16, 15);
            this.lbl_olhos.TabIndex = 6;
            this.lbl_olhos.Text = "O";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Raça:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Nascimento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Peso:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Altura:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cabelo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Olhos:";
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
            this.Teste.MinimumWidth = 6;
            this.Teste.Name = "Teste";
            this.Teste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Teste.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Teste.Text = "Teste";
            this.Teste.ToolTipText = "Fazer Teste";
            this.Teste.Width = 6;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Nome.DataPropertyName = "Nome";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Nome.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 6;
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 6;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "CDS (%)";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Valor.Width = 75;
            // 
            // salvar
            // 
            this.salvar.DataPropertyName = "Salvar";
            this.salvar.HeaderText = "Salvar";
            this.salvar.MinimumWidth = 6;
            this.salvar.Name = "salvar";
            this.salvar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salvar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.salvar.Visible = false;
            this.salvar.Width = 125;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.descricao.DataPropertyName = "Descrição";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.descricao.DefaultCellStyle = dataGridViewCellStyle5;
            this.descricao.HeaderText = "Descrição";
            this.descricao.MinimumWidth = 6;
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.descricao.Width = 6;
            // 
            // id_pericia
            // 
            this.id_pericia.DataPropertyName = "id_pericia";
            this.id_pericia.HeaderText = "ID Pericia";
            this.id_pericia.MinimumWidth = 6;
            this.id_pericia.Name = "id_pericia";
            this.id_pericia.Visible = false;
            this.id_pericia.Width = 125;
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
            this.dtg_log.RowHeadersWidth = 51;
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
            this.groupBox1.Controls.Add(this.lbl_resistencia);
            this.groupBox1.Controls.Add(this.lbl_defesa);
            this.groupBox1.Controls.Add(this.img_resistencia);
            this.groupBox1.Controls.Add(this.img_defesa);
            this.groupBox1.Location = new System.Drawing.Point(12, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 228);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atributos";
            // 
            // lbl_resistencia
            // 
            this.lbl_resistencia.AutoSize = true;
            this.lbl_resistencia.Location = new System.Drawing.Point(176, 33);
            this.lbl_resistencia.Name = "lbl_resistencia";
            this.lbl_resistencia.Size = new System.Drawing.Size(13, 15);
            this.lbl_resistencia.TabIndex = 3;
            this.lbl_resistencia.Text = "0";
            // 
            // lbl_defesa
            // 
            this.lbl_defesa.AutoSize = true;
            this.lbl_defesa.Location = new System.Drawing.Point(50, 33);
            this.lbl_defesa.Name = "lbl_defesa";
            this.lbl_defesa.Size = new System.Drawing.Size(13, 15);
            this.lbl_defesa.TabIndex = 2;
            this.lbl_defesa.Text = "0";
            // 
            // img_resistencia
            // 
            this.img_resistencia.Image = ((System.Drawing.Image)(resources.GetObject("img_resistencia.Image")));
            this.img_resistencia.Location = new System.Drawing.Point(155, 33);
            this.img_resistencia.Name = "img_resistencia";
            this.img_resistencia.Size = new System.Drawing.Size(15, 15);
            this.img_resistencia.TabIndex = 1;
            this.img_resistencia.TabStop = false;
            this.img_resistencia.MouseHover += new System.EventHandler(this.img_resistencia_MouseHover);
            // 
            // img_defesa
            // 
            this.img_defesa.Image = global::Ficha_Jiora.Properties.Resources.armor_15_151;
            this.img_defesa.Location = new System.Drawing.Point(29, 33);
            this.img_defesa.Name = "img_defesa";
            this.img_defesa.Size = new System.Drawing.Size(15, 15);
            this.img_defesa.TabIndex = 0;
            this.img_defesa.TabStop = false;
            this.img_defesa.MouseHover += new System.EventHandler(this.img_defesa_MouseHover);
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
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(711, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "10 / Virgem / 1285";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1164, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clima: Tropical";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1164, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Período: Noite";
            // 
            // lbl_nivel_personagem
            // 
            this.lbl_nivel_personagem.AutoSize = true;
            this.lbl_nivel_personagem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_nivel_personagem.Location = new System.Drawing.Point(352, 66);
            this.lbl_nivel_personagem.Name = "lbl_nivel_personagem";
            this.lbl_nivel_personagem.Size = new System.Drawing.Size(23, 28);
            this.lbl_nivel_personagem.TabIndex = 10;
            this.lbl_nivel_personagem.Text = "0";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(752, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data";
            // 
            // Ficha_do_Jogador
            // 
            this.AcceptButton = this.btn_atualiza;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 650);
            this.Controls.Add(this.label6);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ficha_do_Jogador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha";
            ((System.ComponentModel.ISupportInitialize)(this.img_imagem_personagem)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pericia.ResumeLayout(false);
            this.pericia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_resistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_defesa)).EndInit();
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
        private PictureBox img_defesa;
        private PictureBox img_resistencia;
        private Label lbl_resistencia;
        private Label lbl_defesa;
        private Label label6;
        private GroupBox groupBox3;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private GroupBox groupBox2;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label lbl_nascimento;
        private Label lbl_peso;
        private Label lbl_altura;
        private Label lbl_cabelo;
        private Label lbl_olhos;
    }
}