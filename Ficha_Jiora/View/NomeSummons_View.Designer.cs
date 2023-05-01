namespace Ficha_Jiora.View
{
    partial class NomeSummons_View
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
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.btn_invocar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(12, 27);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(100, 23);
            this.txt_nome.TabIndex = 0;
            // 
            // btn_invocar
            // 
            this.btn_invocar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_invocar.Location = new System.Drawing.Point(118, 27);
            this.btn_invocar.Name = "btn_invocar";
            this.btn_invocar.Size = new System.Drawing.Size(75, 23);
            this.btn_invocar.TabIndex = 1;
            this.btn_invocar.Text = "Invocar";
            this.btn_invocar.UseVisualStyleBackColor = true;
            this.btn_invocar.Click += new System.EventHandler(this.btn_invocar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Informe o nome do seu Summon";
            // 
            // NomeSummons_View
            // 
            this.AcceptButton = this.btn_invocar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 67);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_invocar);
            this.Controls.Add(this.txt_nome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NomeSummons_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NomeSummons_View";
            this.Load += new System.EventHandler(this.NomeSummons_View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txt_nome;
        private Button btn_invocar;
        private Label label1;
    }
}