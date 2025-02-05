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
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            comboBoxMarca = new ComboBox();
            comboBoxCor = new ComboBox();
            comboBoxVaga = new ComboBox();
            pictureBox1 = new PictureBox();
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
            labelVeiculo.Location = new Point(80, 9);
            labelVeiculo.Name = "labelVeiculo";
            labelVeiculo.Size = new Size(45, 15);
            labelVeiculo.TabIndex = 1;
            labelVeiculo.Text = "Veiculo";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(453, 10);
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
            // textBox4
            // 
            textBox4.Location = new Point(439, 152);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(439, 65);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(439, 94);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 8;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(439, 123);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 9;
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
            comboBoxVaga.Items.AddRange(new object[] { "Fiat", "Volkswagen", "Chevrolet", "Toyota" });
            comboBoxVaga.Location = new Point(37, 142);
            comboBoxVaga.Name = "comboBoxVaga";
            comboBoxVaga.Size = new Size(121, 23);
            comboBoxVaga.TabIndex = 14;
            comboBoxVaga.Text = "Vaga";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 109);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // AdicionarVeiculoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(610, 258);
            Controls.Add(pictureBox1);
            Controls.Add(comboBoxVaga);
            Controls.Add(comboBoxCor);
            Controls.Add(comboBoxMarca);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
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
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private ComboBox comboBoxMarca;
        private ComboBox comboBoxCor;
        private ComboBox comboBoxVaga;
        private PictureBox pictureBox1;
    }
}