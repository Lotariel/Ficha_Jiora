namespace Ficha_Jiora.View
{
    partial class Tela_Login
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
            this.btn_logar = new System.Windows.Forms.Button();
            this.txt_nome_personagem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_logar
            // 
            this.btn_logar.Image = global::Ficha_Jiora.Properties.Resources.Atualizar_16;
            this.btn_logar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_logar.Location = new System.Drawing.Point(807, 12);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.Size = new System.Drawing.Size(65, 23);
            this.btn_logar.TabIndex = 5;
            this.btn_logar.Text = "Entrar";
            this.btn_logar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logar.UseVisualStyleBackColor = true;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // txt_nome_personagem
            // 
            this.txt_nome_personagem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txt_nome_personagem.Location = new System.Drawing.Point(701, 12);
            this.txt_nome_personagem.Name = "txt_nome_personagem";
            this.txt_nome_personagem.Size = new System.Drawing.Size(100, 23);
            this.txt_nome_personagem.TabIndex = 4;
            // 
            // Tela_Login
            // 
            this.AcceptButton = this.btn_logar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 470);
            this.Controls.Add(this.btn_logar);
            this.Controls.Add(this.txt_nome_personagem);
            this.Name = "Tela_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_logar;
        private TextBox txt_nome_personagem;
    }
}