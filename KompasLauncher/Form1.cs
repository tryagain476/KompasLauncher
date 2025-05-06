using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace KompasLauncher
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var uiFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRectangularPlate_Click(object sender, EventArgs e)
        {
            // Скрываем главное окно
            this.Hide();

            using (var frm = new RectangularPlateForm())
            {
                // Открываем модально
                frm.ShowDialog(this);
            }

            // После закрытия дочерней формы возвращаем главное
            this.Show();
        }

        private void btnCircularPlate_Click(object sender, EventArgs e)
        {
            // Скрываем главное окно
            this.Hide();

            using (var frm = new CircularPlateForm())
            {
                // Открываем модально
                frm.ShowDialog(this);
            }

            // После закрытия дочерней формы возвращаем главное
            this.Show();
        }
    }
}
