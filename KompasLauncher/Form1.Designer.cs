namespace KompasLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenKompas = new System.Windows.Forms.Button();
            this.Gabariti = new System.Windows.Forms.TextBox();
            this.btnRectangularPlate = new System.Windows.Forms.Button();
            this.btnCircularPlate = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenKompas
            // 
            this.OpenKompas.Location = new System.Drawing.Point(4, 14);
            this.OpenKompas.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.OpenKompas.Name = "OpenKompas";
            this.OpenKompas.Size = new System.Drawing.Size(265, 119);
            this.OpenKompas.TabIndex = 0;
            this.OpenKompas.Text = "Открыть компас";
            this.OpenKompas.UseVisualStyleBackColor = true;
            this.OpenKompas.Click += new System.EventHandler(this.OpenKompas_Click);
            // 
            // Gabariti
            // 
            this.Gabariti.Location = new System.Drawing.Point(287, 14);
            this.Gabariti.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gabariti.Name = "Gabariti";
            this.Gabariti.Size = new System.Drawing.Size(216, 23);
            this.Gabariti.TabIndex = 1;
            // 
            // btnRectangularPlate
            // 
            this.btnRectangularPlate.BackColor = System.Drawing.Color.White;
            this.btnRectangularPlate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRectangularPlate.ForeColor = System.Drawing.Color.Black;
            this.btnRectangularPlate.Location = new System.Drawing.Point(354, 179);
            this.btnRectangularPlate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnRectangularPlate.Name = "btnRectangularPlate";
            this.btnRectangularPlate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRectangularPlate.Size = new System.Drawing.Size(216, 66);
            this.btnRectangularPlate.TabIndex = 2;
            this.btnRectangularPlate.Text = "Прямоугольная (или квадратная) плита";
            this.btnRectangularPlate.UseVisualStyleBackColor = false;
            this.btnRectangularPlate.Click += new System.EventHandler(this.btnRectangularPlate_Click);
            // 
            // btnCircularPlate
            // 
            this.btnCircularPlate.BackColor = System.Drawing.Color.White;
            this.btnCircularPlate.Location = new System.Drawing.Point(354, 272);
            this.btnCircularPlate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCircularPlate.Name = "btnCircularPlate";
            this.btnCircularPlate.Size = new System.Drawing.Size(216, 66);
            this.btnCircularPlate.TabIndex = 3;
            this.btnCircularPlate.Text = "Круглая плита";
            this.btnCircularPlate.UseVisualStyleBackColor = false;
            this.btnCircularPlate.Click += new System.EventHandler(this.btnCircularPlate_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.ErrorImage = global::KompasLauncher.Properties.Resources.btnRectangularPlatePNG;
            this.pictureBox2.Image = global::KompasLauncher.Properties.Resources.btnCircularPlatePNG;
            this.pictureBox2.InitialImage = global::KompasLauncher.Properties.Resources.btnRectangularPlatePNG;
            this.pictureBox2.Location = new System.Drawing.Point(599, 272);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ErrorImage = global::KompasLauncher.Properties.Resources.btnRectangularPlatePNG;
            this.pictureBox1.Image = global::KompasLauncher.Properties.Resources.btnRectangularPlatePNG;
            this.pictureBox1.InitialImage = global::KompasLauncher.Properties.Resources.btnRectangularPlatePNG;
            this.pictureBox1.Location = new System.Drawing.Point(599, 179);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(933, 520);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCircularPlate);
            this.Controls.Add(this.btnRectangularPlate);
            this.Controls.Add(this.Gabariti);
            this.Controls.Add(this.OpenKompas);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "Основное меню программы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenKompas;
        private System.Windows.Forms.TextBox Gabariti;
        private System.Windows.Forms.Button btnRectangularPlate;
        private System.Windows.Forms.Button btnCircularPlate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

