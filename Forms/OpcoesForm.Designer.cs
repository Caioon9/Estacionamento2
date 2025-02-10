namespace Estacionamento2.Forms
{
    partial class OpcoesForm
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
            labelValor = new Label();
            labelVaga = new Label();
            buttonAlterar = new Button();
            textBoxValor = new TextBox();
            textBoxVaga = new TextBox();
            SuspendLayout();
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new Point(61, 13);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(76, 15);
            labelValor.TabIndex = 0;
            labelValor.Text = "Valor da hora";
            // 
            // labelVaga
            // 
            labelVaga.AutoSize = true;
            labelVaga.Location = new Point(49, 75);
            labelVaga.Name = "labelVaga";
            labelVaga.Size = new Size(89, 15);
            labelVaga.TabIndex = 1;
            labelVaga.Text = "Limite de vagas";
            // 
            // buttonAlterar
            // 
            buttonAlterar.Location = new Point(37, 151);
            buttonAlterar.Name = "buttonAlterar";
            buttonAlterar.Size = new Size(126, 48);
            buttonAlterar.TabIndex = 2;
            buttonAlterar.Text = "Alterar";
            buttonAlterar.UseVisualStyleBackColor = true;
            buttonAlterar.Click += buttonAlterar_Click;
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(12, 31);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(184, 23);
            textBoxValor.TabIndex = 3;
            // 
            // textBoxVaga
            // 
            textBoxVaga.Location = new Point(12, 93);
            textBoxVaga.Name = "textBoxVaga";
            textBoxVaga.Size = new Size(184, 23);
            textBoxVaga.TabIndex = 4;
            // 
            // OpcoesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(201, 232);
            Controls.Add(textBoxVaga);
            Controls.Add(textBoxValor);
            Controls.Add(buttonAlterar);
            Controls.Add(labelVaga);
            Controls.Add(labelValor);
            Name = "OpcoesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Opções Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelValor;
        private Label labelVaga;
        private Button buttonAlterar;
        private TextBox textBoxValor;
        private TextBox textBoxVaga;
    }
}