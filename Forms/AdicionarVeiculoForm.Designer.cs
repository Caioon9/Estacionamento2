namespace Estacionamento2.Forms
{
    partial class AdicionarVeiculoForm
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
            buttonAdicionar = new Button();
            labelVeiculo = new Label();
            labelCliente = new Label();
            textBoxPlaca = new TextBox();
            textBoxModelo = new TextBox();
            textBoxAno = new TextBox();
            textBoxEmail = new TextBox();
            textBoxNome = new TextBox();
            textBoxCpf = new TextBox();
            textBoxTelefone = new TextBox();
            comboBoxMarca = new ComboBox();
            comboBoxCor = new ComboBox();
            comboBoxVaga = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonAdicionar
            // 
            buttonAdicionar.Location = new Point(223, 186);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(133, 35);
            buttonAdicionar.TabIndex = 0;
            buttonAdicionar.Text = "Adicionar";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // labelVeiculo
            // 
            labelVeiculo.AutoSize = true;
            labelVeiculo.Location = new Point(185, 9);
            labelVeiculo.Name = "labelVeiculo";
            labelVeiculo.Size = new Size(45, 15);
            labelVeiculo.TabIndex = 1;
            labelVeiculo.Text = "Veiculo";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(351, 10);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(44, 15);
            labelCliente.TabIndex = 2;
            labelCliente.Text = "Cliente";
            // 
            // textBoxPlaca
            // 
            textBoxPlaca.ForeColor = SystemColors.MenuText;
            textBoxPlaca.Location = new Point(185, 27);
            textBoxPlaca.Name = "textBoxPlaca";
            textBoxPlaca.PlaceholderText = "Placa...";
            textBoxPlaca.Size = new Size(121, 23);
            textBoxPlaca.TabIndex = 3;
            // 
            // textBoxModelo
            // 
            textBoxModelo.ForeColor = SystemColors.MenuText;
            textBoxModelo.Location = new Point(185, 56);
            textBoxModelo.Name = "textBoxModelo";
            textBoxModelo.PlaceholderText = "Modelo...";
            textBoxModelo.Size = new Size(121, 23);
            textBoxModelo.TabIndex = 4;
            // 
            // textBoxAno
            // 
            textBoxAno.ForeColor = SystemColors.MenuText;
            textBoxAno.Location = new Point(185, 85);
            textBoxAno.Name = "textBoxAno";
            textBoxAno.PlaceholderText = "Ano...";
            textBoxAno.Size = new Size(121, 23);
            textBoxAno.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(351, 114);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email...";
            textBoxEmail.Size = new Size(188, 23);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(351, 27);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.PlaceholderText = "Nome...";
            textBoxNome.Size = new Size(188, 23);
            textBoxNome.TabIndex = 7;
            // 
            // textBoxCpf
            // 
            textBoxCpf.Location = new Point(351, 56);
            textBoxCpf.Name = "textBoxCpf";
            textBoxCpf.PlaceholderText = "Cpf...";
            textBoxCpf.Size = new Size(188, 23);
            textBoxCpf.TabIndex = 8;
            // 
            // textBoxTelefone
            // 
            textBoxTelefone.Location = new Point(351, 85);
            textBoxTelefone.Name = "textBoxTelefone";
            textBoxTelefone.PlaceholderText = "Telefone...";
            textBoxTelefone.Size = new Size(188, 23);
            textBoxTelefone.TabIndex = 9;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.FormattingEnabled = true;
            comboBoxMarca.Items.AddRange(new object[] { "Fiat", "Volkswagen", "Chevrolet", "Toyota" });
            comboBoxMarca.Location = new Point(185, 113);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(121, 23);
            comboBoxMarca.TabIndex = 10;
            comboBoxMarca.Text = "Marca...";
            // 
            // comboBoxCor
            // 
            comboBoxCor.FormattingEnabled = true;
            comboBoxCor.Items.AddRange(new object[] { "Preto", "Cinza", "Branco", "Vermelho", "Azul" });
            comboBoxCor.Location = new Point(185, 142);
            comboBoxCor.Name = "comboBoxCor";
            comboBoxCor.Size = new Size(121, 23);
            comboBoxCor.TabIndex = 11;
            comboBoxCor.Text = "Cor...";
            // 
            // comboBoxVaga
            // 
            comboBoxVaga.FormattingEnabled = true;
            comboBoxVaga.Location = new Point(12, 155);
            comboBoxVaga.Name = "comboBoxVaga";
            comboBoxVaga.Size = new Size(121, 23);
            comboBoxVaga.TabIndex = 14;
            comboBoxVaga.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 109);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 137);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 17;
            label1.Text = "Selecione a vaga";
            // 
            // AdicionarVeiculoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 258);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(comboBoxVaga);
            Controls.Add(comboBoxCor);
            Controls.Add(comboBoxMarca);
            Controls.Add(textBoxTelefone);
            Controls.Add(textBoxCpf);
            Controls.Add(textBoxNome);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxAno);
            Controls.Add(textBoxModelo);
            Controls.Add(textBoxPlaca);
            Controls.Add(labelCliente);
            Controls.Add(labelVeiculo);
            Controls.Add(buttonAdicionar);
            Name = "AdicionarVeiculoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adicionar Veiculo";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdicionar;
        private Label labelVeiculo;
        private Label labelCliente;
        private TextBox textBoxPlaca;
        private TextBox textBoxModelo;
        private TextBox textBoxAno;
        private TextBox textBoxEmail;
        private TextBox textBoxNome;
        private TextBox textBoxCpf;
        private TextBox textBoxTelefone;
        private ComboBox comboBoxMarca;
        private ComboBox comboBoxCor;
        private ComboBox comboBoxVaga;
        private PictureBox pictureBox1;
        private Label label1;
    }
}