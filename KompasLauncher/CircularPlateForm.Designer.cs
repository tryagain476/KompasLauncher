namespace KompasLauncher
{
    partial class CircularPlateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircularPlateForm));
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.BackColor = System.Drawing.Color.White;
            this.btnBackToMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBackToMain.ForeColor = System.Drawing.Color.Black;
            this.btnBackToMain.Location = new System.Drawing.Point(333, 209);
            this.btnBackToMain.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackToMain.Size = new System.Drawing.Size(216, 66);
            this.btnBackToMain.TabIndex = 4;
            this.btnBackToMain.Text = "Вернуться на главное меню";
            this.btnBackToMain.UseVisualStyleBackColor = false;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // CircularPlateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.btnBackToMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CircularPlateForm";
            this.Text = "Проектирование круглой плиты";
            this.Load += new System.EventHandler(this.CircularPlateForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackToMain;
    }
}