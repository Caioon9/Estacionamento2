namespace Estacionamento2.Forms
{
    partial class VisualizarForm
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
            dataGridViewVisualizar = new DataGridView();
            buttonAtualizar = new Button();
            buttonCalcular = new Button();
            label1 = new Label();
            textBoxplaca = new TextBox();
            buttonProcurar = new Button();
            buttonFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVisualizar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewVisualizar
            // 
            dataGridViewVisualizar.AllowUserToAddRows = false;
            dataGridViewVisualizar.AllowUserToDeleteRows = false;
            dataGridViewVisualizar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVisualizar.Location = new Point(38, 12);
            dataGridViewVisualizar.Name = "dataGridViewVisualizar";
            dataGridViewVisualizar.ReadOnly = true;
            dataGridViewVisualizar.Size = new Size(787, 332);
            dataGridViewVisualizar.TabIndex = 0;
            // 
            // buttonAtualizar
            // 
            buttonAtualizar.BackColor = SystemColors.ActiveCaption;
            buttonAtualizar.ForeColor = SystemColors.ButtonHighlight;
            buttonAtualizar.Location = new Point(6, 9);
            buttonAtualizar.Name = "buttonAtualizar";
            buttonAtualizar.Size = new Size(26, 23);
            buttonAtualizar.TabIndex = 1;
            buttonAtualizar.Text = "@";
            buttonAtualizar.UseVisualStyleBackColor = false;
            buttonAtualizar.Click += buttonAtualizar_Click;
            // 
            // buttonCalcular
            // 
            buttonCalcular.Location = new Point(257, 362);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(442, 76);
            buttonCalcular.TabIndex = 2;
            buttonCalcular.Text = "Calcular";
            buttonCalcular.UseVisualStyleBackColor = true;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 362);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 3;
            label1.Text = "Selecione por placa";
            // 
            // textBoxplaca
            // 
            textBoxplaca.Location = new Point(38, 381);
            textBoxplaca.Name = "textBoxplaca";
            textBoxplaca.Size = new Size(131, 23);
            textBoxplaca.TabIndex = 4;
            // 
            // buttonProcurar
            // 
            buttonProcurar.Location = new Point(38, 410);
            buttonProcurar.Name = "buttonProcurar";
            buttonProcurar.Size = new Size(131, 26);
            buttonProcurar.TabIndex = 5;
            buttonProcurar.Text = "Procurar";
            buttonProcurar.UseVisualStyleBackColor = true;
            buttonProcurar.Click += buttonProcurar_Click;
            // 
            // buttonFechar
            // 
            buttonFechar.Location = new Point(714, 362);
            buttonFechar.Name = "buttonFechar";
            buttonFechar.Size = new Size(111, 76);
            buttonFechar.TabIndex = 6;
            buttonFechar.Text = "Fechar";
            buttonFechar.UseVisualStyleBackColor = true;
            buttonFechar.Click += buttonFechar_Click;
            // 
            // VisualizarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 450);
            Controls.Add(buttonFechar);
            Controls.Add(buttonProcurar);
            Controls.Add(textBoxplaca);
            Controls.Add(label1);
            Controls.Add(buttonCalcular);
            Controls.Add(buttonAtualizar);
            Controls.Add(dataGridViewVisualizar);
            Name = "VisualizarForm";
            Text = "VisualizarForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewVisualizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewVisualizar;
        private Button buttonAtualizar;
        private Button buttonCalcular;
        private Label label1;
        private TextBox textBoxplaca;
        private Button buttonProcurar;
        private Button buttonFechar;
    }
}