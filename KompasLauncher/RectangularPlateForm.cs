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
            // 1. Считываем и валидируем длину, ширину и толщину
            double length = (double)numericLxW.Value;
            double width = (double)numericLxW2.Value;
            double height = (double)numericH.Value;
            int usp = (int)numericUSP.Value;

            if (length <= 0 || height <= 0)
            {
                MessageBox.Show(
                    "Длина и толщина плиты должны быть больше нуля.",
                    "Неверный ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            // Если ширина не задана (0), считаем квадрат
            if (width <= 0) width = length;

            // 2. Параметры пазов/отверстий по серии УСП
            double slotWidth, slotDepth;
            switch (usp)
            {
                case 8:
                    slotWidth = 8; slotDepth = 10; break;
                case 12:
                    slotWidth = 12; slotDepth = 15; break;
                case 16:
                    slotWidth = 16; slotDepth = 20; break;
                default:
                    MessageBox.Show(
                        "Серия УСП должна быть 8, 12 или 16.",
                        "Неверная серия",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                    return;
            }

            try
            {
                // 3. Запуск КОМПАСа
                KompasObject kompas = (KompasObject)
                    Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
                kompas.Visible = true;

                // 4. Создание 3D-документа (деталь)
                ksDocument3D doc3D = (ksDocument3D)kompas.Document3D();
                doc3D.Create(false, true);
                ksPart part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

                // 5. Эскиз на плоскости XOY
                ksEntity basePlane = (ksEntity)part.GetDefaultEntity(
                    (short)Obj3dType.o3d_planeXOY);
                ksEntity sketchEnt = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_sketch);
                ksSketchDefinition skDef = (ksSketchDefinition)sketchEnt.GetDefinition();
                skDef.SetPlane(basePlane);
                sketchEnt.Create();

                ksDocument2D doc2D = skDef.BeginEdit();
                doc2D.ksLineSeg(0, 0, length, 0, 1);
                doc2D.ksLineSeg(length, 0, length, width, 1);
                doc2D.ksLineSeg(length, width, 0, width, 1);
                doc2D.ksLineSeg(0, width, 0, 0, 1);
                skDef.EndEdit();

                // 6. Выдавливание на толщину
                ksEntity bossExtr = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_bossExtrusion);
                ksBossExtrusionDefinition exDef =
                    (ksBossExtrusionDefinition)bossExtr.GetDefinition();
                exDef.directionType = (short)Direction_Type.dtNormal;
                exDef.SetSideParam(
                    /*useSide1*/ true,
                    /*endType1*/ (short)End_Type.etBlind,
                    /*value1*/   height,
                    /*value2*/   0.0,
                    /*useSide2*/ false
                );
                exDef.SetSketch(sketchEnt);
                bossExtr.Create();

                // Здесь можно добавить логику для пазов и отверстий...
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при работе с КОМПАС: " + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }
    }
}
