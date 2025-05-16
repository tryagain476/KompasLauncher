namespace KompasLauncher
{
    partial class RectangularPlateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RectangularPlateForm));
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.numericLxW = new System.Windows.Forms.NumericUpDown();
            this.numericH = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUSP = new System.Windows.Forms.NumericUpDown();
            this.btnCreatePlite1 = new System.Windows.Forms.Button();
            this.numericLxW2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericLxW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLxW2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackToMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBackToMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackToMain.ForeColor = System.Drawing.Color.Black;
            this.btnBackToMain.Location = new System.Drawing.Point(17, 442);
            this.btnBackToMain.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackToMain.Size = new System.Drawing.Size(216, 66);
            this.btnBackToMain.TabIndex = 3;
            this.btnBackToMain.Text = "Вернуться на главное меню";
            this.btnBackToMain.UseVisualStyleBackColor = false;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // numericLxW
            // 
            this.numericLxW.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericLxW.Location = new System.Drawing.Point(397, 12);
            this.numericLxW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericLxW.Name = "numericLxW";
            this.numericLxW.Size = new System.Drawing.Size(74, 31);
            this.numericLxW.TabIndex = 4;
            // 
            // numericH
            // 
            this.numericH.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericH.Location = new System.Drawing.Point(397, 54);
            this.numericH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericH.Name = "numericH";
            this.numericH.Size = new System.Drawing.Size(74, 31);
            this.numericH.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ведите длину и ширину(необязательно)\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ведите толщину плиты\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ведите серию УСП";
            // 
            // numericUSP
            // 
            this.numericUSP.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUSP.Location = new System.Drawing.Point(397, 99);
            this.numericUSP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUSP.Name = "numericUSP";
            this.numericUSP.Size = new System.Drawing.Size(74, 31);
            this.numericUSP.TabIndex = 9;
            // 
            // btnCreatePlite1
            // 
            this.btnCreatePlite1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreatePlite1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreatePlite1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreatePlite1.ForeColor = System.Drawing.Color.Black;
            this.btnCreatePlite1.Location = new System.Drawing.Point(581, 36);
            this.btnCreatePlite1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCreatePlite1.Name = "btnCreatePlite1";
            this.btnCreatePlite1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCreatePlite1.Size = new System.Drawing.Size(216, 66);
            this.btnCreatePlite1.TabIndex = 11;
            this.btnCreatePlite1.Text = "Создать плиту";
            this.btnCreatePlite1.UseVisualStyleBackColor = false;
            this.btnCreatePlite1.Click += new System.EventHandler(this.btnCreatePlite1_Click);
            // 
            // numericLxW2
            // 
            this.numericLxW2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericLxW2.Location = new System.Drawing.Point(477, 12);
            this.numericLxW2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericLxW2.Name = "numericLxW2";
            this.numericLxW2.Size = new System.Drawing.Size(74, 31);
            this.numericLxW2.TabIndex = 12;
            // 
            // RectangularPlateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.numericLxW2);
            this.Controls.Add(this.btnCreatePlite1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUSP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericH);
            this.Controls.Add(this.numericLxW);
            this.Controls.Add(this.btnBackToMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RectangularPlateForm";
            this.Text = "Проектирование квадратной или прямоугольной плиты";
            
            ((System.ComponentModel.ISupportInitialize)(this.numericLxW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLxW2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.NumericUpDown numericLxW;
        private System.Windows.Forms.NumericUpDown numericH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUSP;
        private System.Windows.Forms.Button btnCreatePlite1;
        private System.Windows.Forms.NumericUpDown numericLxW2;
    }
}