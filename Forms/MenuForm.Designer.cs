namespace Estacionamento2
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAdicionar = new Button();
            buttonVisualizar = new Button();
            buttonEditar = new Button();
            buttonOpcoes = new Button();
            SuspendLayout();
            // 
            // buttonAdicionar
            // 
            buttonAdicionar.BackColor = Color.FromArgb(192, 255, 192);
            buttonAdicionar.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            buttonAdicionar.Location = new Point(36, 22);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(150, 33);
            buttonAdicionar.TabIndex = 0;
            buttonAdicionar.Text = "Adicionar";
            buttonAdicionar.UseVisualStyleBackColor = false;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // buttonVisualizar
            // 
            buttonVisualizar.BackColor = Color.FromArgb(192, 255, 255);
            buttonVisualizar.Location = new Point(36, 64);
            buttonVisualizar.Name = "buttonVisualizar";
            buttonVisualizar.Size = new Size(150, 33);
            buttonVisualizar.TabIndex = 1;
            buttonVisualizar.Text = "Visualizar";
            buttonVisualizar.UseVisualStyleBackColor = false;
            // 
            // buttonEditar
            // 
            buttonEditar.BackColor = Color.FromArgb(255, 255, 192);
            buttonEditar.Location = new Point(36, 106);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(150, 33);
            buttonEditar.TabIndex = 2;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = false;
            // 
            // buttonOpcoes
            // 
            buttonOpcoes.BackColor = Color.FromArgb(255, 192, 192);
            buttonOpcoes.Location = new Point(36, 148);
            buttonOpcoes.Name = "buttonOpcoes";
            buttonOpcoes.Size = new Size(150, 33);
            buttonOpcoes.TabIndex = 3;
            buttonOpcoes.Text = "Opções";
            buttonOpcoes.UseVisualStyleBackColor = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 199);
            Controls.Add(buttonOpcoes);
            Controls.Add(buttonEditar);
            Controls.Add(buttonVisualizar);
            Controls.Add(buttonAdicionar);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAdicionar;
        private Button buttonVisualizar;
        private Button buttonEditar;
        private Button buttonOpcoes;
    }
}
