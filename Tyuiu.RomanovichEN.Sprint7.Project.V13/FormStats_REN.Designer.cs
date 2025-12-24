namespace Tyuiu.RomanovichEN.Sprint7.Project.V13
{
    partial class FormStats_REN
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
            textBoxSum = new TextBox();
            textBoxAvg = new TextBox();
            textBoxMin = new TextBox();
            textBoxMax = new TextBox();
            labelSum = new Label();
            labelAvg = new Label();
            labelMin = new Label();
            labelMax = new Label();
            SuspendLayout();
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(130, 32);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.ReadOnly = true;
            textBoxSum.Size = new Size(153, 23);
            textBoxSum.TabIndex = 0;
            // 
            // textBoxAvg
            // 
            textBoxAvg.Location = new Point(130, 72);
            textBoxAvg.Name = "textBoxAvg";
            textBoxAvg.ReadOnly = true;
            textBoxAvg.Size = new Size(153, 23);
            textBoxAvg.TabIndex = 1;
            // 
            // textBoxMin
            // 
            textBoxMin.Location = new Point(130, 114);
            textBoxMin.Name = "textBoxMin";
            textBoxMin.ReadOnly = true;
            textBoxMin.Size = new Size(153, 23);
            textBoxMin.TabIndex = 2;
            // 
            // textBoxMax
            // 
            textBoxMax.Location = new Point(130, 155);
            textBoxMax.Name = "textBoxMax";
            textBoxMax.ReadOnly = true;
            textBoxMax.Size = new Size(153, 23);
            textBoxMax.TabIndex = 3;
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Location = new Point(15, 35);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(109, 15);
            labelSum.TabIndex = 4;
            labelSum.Text = "Сумма населения:";
            // 
            // labelAvg
            // 
            labelAvg.AutoSize = true;
            labelAvg.Location = new Point(15, 75);
            labelAvg.Name = "labelAvg";
            labelAvg.Size = new Size(56, 15);
            labelAvg.TabIndex = 5;
            labelAvg.Text = "Среднее:";
            // 
            // labelMin
            // 
            labelMin.AutoSize = true;
            labelMin.Location = new Point(15, 117);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(66, 15);
            labelMin.TabIndex = 6;
            labelMin.Text = "Минимум:";
            // 
            // labelMax
            // 
            labelMax.AutoSize = true;
            labelMax.Location = new Point(15, 158);
            labelMax.Name = "labelMax";
            labelMax.Size = new Size(70, 15);
            labelMax.TabIndex = 7;
            labelMax.Text = "Максимум:";
            // 
            // FormStats_REN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 211);
            Controls.Add(labelMax);
            Controls.Add(labelMin);
            Controls.Add(labelAvg);
            Controls.Add(labelSum);
            Controls.Add(textBoxMax);
            Controls.Add(textBoxMin);
            Controls.Add(textBoxAvg);
            Controls.Add(textBoxSum);
            MaximizeBox = false;
            Name = "FormStats_REN";
            Text = "FormStats_REN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSum;
        private TextBox textBoxAvg;
        private TextBox textBoxMin;
        private TextBox textBoxMax;
        private Label labelSum;
        private Label labelAvg;
        private Label labelMin;
        private Label labelMax;
    }
}