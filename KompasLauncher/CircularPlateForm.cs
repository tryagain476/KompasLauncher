﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class CircularPlateForm : Form
    {
        public CircularPlateForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CircularPlateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            // Закрываем эту форму — ShowDialog() в главной форме вернёт управление
            this.Close();
        }
    }
}
