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
            dataGridView1 = new DataGridView();
            buttonAtualizar = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(787, 332);
            dataGridView1.TabIndex = 0;
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
            // button2
            // 
            button2.Location = new Point(331, 362);
            button2.Name = "button2";
            button2.Size = new Size(442, 76);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 362);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(38, 381);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(131, 23);
            textBox1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(38, 410);
            button3.Name = "button3";
            button3.Size = new Size(131, 26);
            button3.TabIndex = 5;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // VisualizarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 450);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(buttonAtualizar);
            Controls.Add(dataGridView1);
            Name = "VisualizarForm";
            Text = "VisualizarForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAtualizar;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
    }
}