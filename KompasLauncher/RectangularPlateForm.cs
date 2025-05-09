using System;
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
    public partial class RectangularPlateForm : Form
    {
        public RectangularPlateForm()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RectangularPlateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            // Закрываем эту форму — ShowDialog() в главной форме вернёт управление
            this.Close();
        }

        private void btnCreatePlite1_Click(object sender, EventArgs e)
        {
            // 1. Ввод и простая проверка
            double length = (double)numericLxW.Value;
            double width = (double)numericLxW2.Value;
            double height = (double)numericH.Value;
            int usp = (int)numericUSP.Value;

            if (length <= 0 || height <= 0)
            {
                MessageBox.Show("Длина и толщина должны быть больше нуля.",
                                "Неверный ввод",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (width <= 0) width = length;  // квадрат

            // 2. Параметры сетки
            const double grooveWidth = 10.0;  // ширина и глубина канавки
            const double grooveDepth = 10.0;
            const double offset = 10.0;  // отступ от краёв

            try
            {
                // 3. Запускаем КОМПАС и создаём документ
                var kompas = (KompasObject)Activator.CreateInstance(
                    Type.GetTypeFromProgID("KOMPAS.Application.5"));
                kompas.Visible = true;

                var doc3D = (ksDocument3D)kompas.Document3D();
                doc3D.Create(false, true);
                var part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

                // 4. Базовая плоскость XOY
                var basePlane = (ksEntity)part.GetDefaultEntity(
                    (short)Obj3dType.o3d_planeXOY);

                // 5. Эскиз и выдавливание плиты, центр по XY
                double x0 = -length / 2.0, y0 = -width / 2.0;
                var sk0 = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                var sd0 = (ksSketchDefinition)sk0.GetDefinition();
                sd0.SetPlane(basePlane);
                sk0.Create();

                var d0 = sd0.BeginEdit();
                d0.ksLineSeg(x0, y0, x0 + length, y0, 1);
                d0.ksLineSeg(x0 + length, y0, x0 + length, y0 + width, 1);
                d0.ksLineSeg(x0 + length, y0 + width, x0, y0 + width, 1);
                d0.ksLineSeg(x0, y0 + width, x0, y0, 1);
                sd0.EndEdit();

                var boss = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                var bd = (ksBossExtrusionDefinition)boss.GetDefinition();
                bd.directionType = (short)Direction_Type.dtNormal;
                bd.SetSideParam(true, (short)End_Type.etBlind, height, 0, false);
                bd.SetSketch(sk0);
                boss.Create();

                // 6. Расчёт числа канавок
                int rows = (int)Math.Floor((width - 2 * offset) / grooveWidth) + 1;
                int cols = (int)Math.Floor((length - 2 * offset) / grooveWidth) + 1;

                // 7.1 Горизонтальные канавки (параллельно X)
                for (int i = 0; i < rows; i++)
                {
                    double yGroove = -width / 2.0 + offset + i * grooveWidth;

                    var skH = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                    var sdH = (ksSketchDefinition)skH.GetDefinition();
                    // просто на базовую плоскость XOY (Z=0)
                    sdH.SetPlane(basePlane);
                    skH.Create();

                    var dH = sdH.BeginEdit();
                    dH.ksLineSeg(-length / 2.0, yGroove, length / 2.0, yGroove, 1);
                    dH.ksLineSeg(length / 2.0, yGroove, length / 2.0, yGroove + grooveWidth, 1);
                    dH.ksLineSeg(length / 2.0, yGroove + grooveWidth, -length / 2.0, yGroove + grooveWidth, 1);
                    dH.ksLineSeg(-length / 2.0, yGroove + grooveWidth, -length / 2.0, yGroove, 1);
                    sdH.EndEdit();

                    var cutH = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                    var cdH = (ksCutExtrusionDefinition)cutH.GetDefinition();
                    cdH.directionType = (short)Direction_Type.dtNormal;
                    // режем «вверх» из Z=0 внутрь детали
                    cdH.SetSideParam(true, (short)End_Type.etBlind, grooveDepth, 0, false);
                    cdH.SetSketch(skH);
                    cutH.Create();
                }

                // 7.2 Вертикальные канавки (параллельно Y)
                for (int j = 0; j < cols; j++)
                {
                    double xGroove = -length / 2.0 + offset + j * grooveWidth;

                    var skV = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                    var sdV = (ksSketchDefinition)skV.GetDefinition();
                    sdV.SetPlane(basePlane);
                    skV.Create();

                    var dV = sdV.BeginEdit();
                    dV.ksLineSeg(xGroove, -width / 2.0, xGroove, width / 2.0, 1);
                    dV.ksLineSeg(xGroove, width / 2.0, xGroove + grooveWidth, width / 2.0, 1);
                    dV.ksLineSeg(xGroove + grooveWidth, width / 2.0, xGroove + grooveWidth, -width / 2.0, 1);
                    dV.ksLineSeg(xGroove + grooveWidth, -width / 2.0, xGroove, -width / 2.0, 1);
                    sdV.EndEdit();

                    var cutV = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                    var cdV = (ksCutExtrusionDefinition)cutV.GetDefinition();
                    cdV.directionType = (short)Direction_Type.dtNormal;
                    cdV.SetSideParam(true, (short)End_Type.etBlind, grooveDepth, 0, false);
                    cdV.SetSketch(skV);
                    cutV.Create();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с КОМПАС: " + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
