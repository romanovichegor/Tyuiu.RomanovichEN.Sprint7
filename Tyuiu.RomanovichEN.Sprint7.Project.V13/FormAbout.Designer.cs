namespace Tyuiu.RomanovichEN.Sprint7.Project.V13
{
    partial class FormAbout_REN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout_REN));
            pictureBox_REN = new PictureBox();
            textBoxHelp_REN = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_REN).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_REN
            // 
            pictureBox_REN.Image = (Image)resources.GetObject("pictureBox_REN.Image");
            pictureBox_REN.Location = new Point(12, 23);
            pictureBox_REN.Name = "pictureBox_REN";
            pictureBox_REN.Size = new Size(213, 264);
            pictureBox_REN.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_REN.TabIndex = 0;
            pictureBox_REN.TabStop = false;
            // 
            // textBoxHelp_REN
            // 
            textBoxHelp_REN.BackColor = SystemColors.ControlLight;
            textBoxHelp_REN.BorderStyle = BorderStyle.None;
            textBoxHelp_REN.Location = new Point(281, 47);
            textBoxHelp_REN.Multiline = true;
            textBoxHelp_REN.Name = "textBoxHelp_REN";
            textBoxHelp_REN.ReadOnly = true;
            textBoxHelp_REN.Size = new Size(359, 240);
            textBoxHelp_REN.TabIndex = 1;
            textBoxHelp_REN.Text = "Выполнил: Романович Е. Н.\r\nгруппа ПКТб-25-1\r\nTyuiu.RomanovichEN.Sprint7.Project.V13";
            // 
            // FormAbout_REN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 310);
            Controls.Add(textBoxHelp_REN);
            Controls.Add(pictureBox_REN);
            MaximizeBox = false;
            Name = "FormAbout_REN";
            Text = "Информация";
            ((System.ComponentModel.ISupportInitialize)pictureBox_REN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_REN;
        private TextBox textBoxHelp_REN;
    }
}