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
            this.OpenKompas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenKompas
            // 
            this.OpenKompas.Location = new System.Drawing.Point(289, 158);
            this.OpenKompas.Name = "OpenKompas";
            this.OpenKompas.Size = new System.Drawing.Size(227, 103);
            this.OpenKompas.TabIndex = 0;
            this.OpenKompas.Text = "Открыть компас";
            this.OpenKompas.UseVisualStyleBackColor = true;
            this.OpenKompas.Click += new System.EventHandler(this.OpenKompas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenKompas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenKompas;
    }
}

