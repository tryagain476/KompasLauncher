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


        private void OpenKompas_Click(object sender, EventArgs e)
        {
            // 1) Парсим размеры из текстбокса
            string input = Gabariti.Text.Trim();
            string[] parts = input.Split(new char[] { 'x', 'X' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                MessageBox.Show("Неверный формат размеров. Введите как ДлинаXШиринаXВысота, например 50x40x30");
                return;
            }

            if (!double.TryParse(parts[0], out double length) ||
                !double.TryParse(parts[1], out double width) ||
                !double.TryParse(parts[2], out double height))
            {
                MessageBox.Show("Не удалось распознать число. Убедитесь, что вводите числа через точку или запятую.");
                return;
            }

            try
            {
                // 2) Запуск КОМПАСа
                KompasObject kompas = (KompasObject)
                    Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
                kompas.Visible = true;

                // 3) Создание 3D-документа (деталь)
                ksDocument3D doc3D = (ksDocument3D)kompas.Document3D();
                doc3D.Create(false, true);

                // 4) Корневая «часть»
                ksPart part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

                // 5) Создаём эскиз на плоскости XOY
                ksEntity basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                ksEntity sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                ksSketchDefinition skDef = (ksSketchDefinition)sketch.GetDefinition();
                skDef.SetPlane(basePlane);
                sketch.Create();

                // 6) Рисуем прямоугольник length×width
                ksDocument2D doc2D = skDef.BeginEdit();
                doc2D.ksLineSeg(0, 0, length, 0, 1);
                doc2D.ksLineSeg(length, 0, length, width, 1);
                doc2D.ksLineSeg(length, width, 0, width, 1);
                doc2D.ksLineSeg(0, width, 0, 0, 1);
                skDef.EndEdit();

                // 7) Выдавливание на height
                ksEntity bossExtr = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                ksBossExtrusionDefinition exDef = (ksBossExtrusionDefinition)bossExtr.GetDefinition();
                exDef.directionType = (short)Direction_Type.dtNormal;
                exDef.SetSideParam(
                    /*useSide1*/ true,
                    /*endType1*/ (short)End_Type.etBlind,
                    /*value1*/   height,
                    /*value2*/   0.0,
                    /*useSide2*/ false);
                exDef.SetSketch(sketch);
                bossExtr.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с КОМПАС: " + ex.Message);
            }
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
