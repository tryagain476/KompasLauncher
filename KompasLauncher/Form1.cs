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
        }

        private void OpenKompas_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Запуск КОМПАСа
                KompasObject kompas = (KompasObject)
                    Activator.CreateInstance(
                        Type.GetTypeFromProgID("KOMPAS.Application.5"));
                kompas.Visible = true;

                // 2) Создание 3D-документа (деталь)
                ksDocument3D doc3D = (ksDocument3D)kompas.Document3D();
                doc3D.Create(false, true);

                // 3) Получаем корневую «часть»
                ksPart part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

                // 4) Создаём эскиз на плоскости XOY
                ksEntity basePlane = (ksEntity)part.GetDefaultEntity(
                    (short)Obj3dType.o3d_planeXOY);
                ksEntity sketch = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_sketch);
                ksSketchDefinition skDef = (ksSketchDefinition)sketch.GetDefinition();

                skDef.SetPlane(basePlane);    // <-- привязали эскиз к плоскости
                sketch.Create();

                // 5) Рисуем прямоугольник 40×30
                ksDocument2D doc2D = skDef.BeginEdit();
                doc2D.ksLineSeg(0, 0, 40, 0, 1);
                doc2D.ksLineSeg(40, 0, 40, 30, 1);
                doc2D.ksLineSeg(40, 30, 0, 30, 1);
                doc2D.ksLineSeg(0, 30, 0, 0, 1);
                skDef.EndEdit();

                // 6) Выдавливание на 20
                ksEntity bossExtr = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_bossExtrusion);
                ksBossExtrusionDefinition exDef =
                    (ksBossExtrusionDefinition)bossExtr.GetDefinition();

                exDef.directionType = (short)Direction_Type.dtNormal;
                exDef.SetSideParam(
                    /*useSide1*/  true,
                    /*endType1*/  (short)End_Type.etBlind,
                    /*value1*/    20.0,
                    /*value2*/    0.0,
                    /*useSide2*/  false);

                exDef.SetSketch(sketch);  // <-- указываем эскиз для выдавливания
                bossExtr.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
