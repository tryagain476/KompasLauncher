using System;
using System.Drawing;
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

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreatePlite1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Запуск Компас-3D и создание документа
                var kompas = (KompasObject)Activator.CreateInstance(
                    Type.GetTypeFromProgID("KOMPAS.Application.5"));
                kompas.Visible = true;

                ksDocument3D doc3D = (ksDocument3D)kompas.Document3D();
                doc3D.Create(false, true);
                ksPart part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);

                // 2) Эскиз №1 на плоскости XOZ
                ksEntity planeXOZ = (ksEntity)part.GetDefaultEntity(
                    (short)Obj3dType.o3d_planeXOZ);
                ksEntity sketch1 = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_sketch);
                var skDef1 = (ksSketchDefinition)sketch1.GetDefinition();
                skDef1.SetPlane(planeXOZ);
                sketch1.Create();

                ksDocument2D doc2d1 = skDef1.BeginEdit();
                // Нарисовать квадрат 360×360
                doc2d1.ksLineSeg(-180, -180, 180, -180, 1);
                doc2d1.ksLineSeg(180, -180, 180, 180, 1);
                doc2d1.ksLineSeg(180, 180, -180, 180, 1);
                doc2d1.ksLineSeg(-180, 180, -180, -180, 1);
                // Диагонали
                doc2d1.ksLineSeg(180, -180, -180, 180, 2);
                doc2d1.ksLineSeg(-180, -180, 180, 180, 2);
                // Центральная точка
                doc2d1.ksPoint(0, 0, 0);
                skDef1.EndEdit();

                // 3) Повернуть эскиз на 90°
                var skDef1After = (ksSketchDefinition)sketch1.GetDefinition();
                skDef1After.angle = 90;
                sketch1.Update();

                // 4) Первое выдавливание (bossExtrusion) по ребру в точке (0,0,180)
                ksEntity boss1 = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_bossExtrusion);
                var defBoss1 = (ksBossExtrusionDefinition)boss1.GetDefinition();

                // Найти ребро
                var edgeColl = (ksEntityCollection)part.EntityCollection(
                    (short)Obj3dType.o3d_edge);
                edgeColl.SelectByPoint(0, 0, 180);
                ksEntity edge = edgeColl.Last();
                var edgeDef = (ksEdgeDefinition)edge.GetDefinition();
                ksEntity sketchEdge = edgeDef.GetOwnerEntity();
                defBoss1.SetSketch(sketchEdge);

                // Параметры экструзии
                var extrParam = defBoss1.ExtrusionParam();
                extrParam.direction = (short)Direction_Type.dtNormal;
                extrParam.depthNormal = 60;
                extrParam.depthReverse = 0;
                extrParam.draftOutwardNormal = false;
                extrParam.draftOutwardReverse = false;
                extrParam.draftValueNormal = 0;
                extrParam.draftValueReverse = 0;
                extrParam.typeNormal = (short)End_Type.etBlind;
                extrParam.typeReverse = (short)End_Type.etBlind;

                defBoss1.ThinParam().thin = false;
                boss1.name = "Элемент выдавливания:1";

                // Цвет
                var clr = boss1.ColorParam();
                clr.ambient = 0.5;
                clr.color = 9474192;
                clr.diffuse = 0.6;
                clr.emission = 0.5;
                clr.shininess = 0.8;
                clr.specularity = 0.8;
                clr.transparency = 1.0;

                boss1.Create();

                // 2-й макрос: эскиз на грани, выбранной по точке (0,30,180)
                var faceColl2 = (ksEntityCollection)part.EntityCollection(
                    (short)Obj3dType.o3d_face);
                faceColl2.SelectByPoint(0, 30, 180);
                ksEntity face2 = faceColl2.First();

                ksEntity sketch2 = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_sketch);
                var skDef2 = (ksSketchDefinition)sketch2.GetDefinition();
                skDef2.SetPlane(face2);
                sketch2.Create();

                // Начало редактирования эскиза
                ksDocument2D doc2d2 = skDef2.BeginEdit();

                // Переносим все команды из макроса #2:
                doc2d2.ksLine(-132, 49.05509299893, 90);
                doc2d2.ksLine(-155.433056375092, 30, 0);
                doc2d2.ksLine(-152.081653788472, 38.5, 0);
                doc2d2.ksLine(-108, 50.587161935233, 90);
                doc2d2.ksLineSeg(-132, 30, -108, 30, 1);
                doc2d2.ksLine(-120, 30, 90);
                doc2d2.ksLine(-112, 67.687712428828, 90);
                doc2d2.ksLine(-128, 67.687712428828, 90);
                doc2d2.ksLineSeg(-132, 30, -132, 38.5, 1);
                doc2d2.ksLineSeg(-132, 38.5, -128, 38.5, 1);
                doc2d2.ksLineSeg(-128, 38.5, -128, 60, 1);
                doc2d2.ksLineSeg(-128, 60, -112, 60, 1);
                doc2d2.ksLineSeg(-112, 60, -112, 38.5, 1);
                doc2d2.ksLineSeg(-112, 38.5, -108, 38.5, 1);
                doc2d2.ksLineSeg(-108, 38.5, -108, 30, 1);
                doc2d2.ksLine(-144, 34.988306820168, 270);
                doc2d2.ksLine(-72, 34.988306820168, 270);
                doc2d2.ksLine(-72, 54.139152801088, 90);
                doc2d2.ksLine(-72, 0, 90);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(0, 38.5, 0);
                doc2d2.ksLine(-48, 0, 90);
                doc2d2.ksLineSeg(-72, 30, -48, 30, 1);
                doc2d2.ksLine(-60, 0, 90);
                doc2d2.ksLine(-52, 0, 90);
                doc2d2.ksLine(-68, 0, 90);
                doc2d2.ksLineSeg(-72, 30, -72, 38.5, 1);
                doc2d2.ksLineSeg(-72, 38.5, -68, 38.5, 1);
                doc2d2.ksLineSeg(-68, 38.5, -68, 60, 1);
                doc2d2.ksLineSeg(-68, 60, -52, 60, 1);
                doc2d2.ksLineSeg(-52, 60, -52, 38.5, 1);
                doc2d2.ksLineSeg(-52, 38.5, -48, 38.5, 1);
                doc2d2.ksLineSeg(-48, 38.5, -48, 30, 1);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(0, 38.5, 0);
                doc2d2.ksLine(-12, 0, 90);
                doc2d2.ksLine(-12, 0, 90);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(60, 38.5, 0);
                doc2d2.ksLine(12, 0, 90);
                doc2d2.ksLineSeg(-12, 30, 12, 30, 1);
                doc2d2.ksLine(0, 0, 90);
                doc2d2.ksLine(8, 0, 90);
                doc2d2.ksLine(-8, 0, 90);
                doc2d2.ksLineSeg(-12, 30, -12, 38.5, 1);
                doc2d2.ksLineSeg(-12, 38.5, -8, 38.5, 1);
                doc2d2.ksLineSeg(-8, 38.5, -8, 60, 1);
                doc2d2.ksLineSeg(-8, 60, 8, 60, 1);
                doc2d2.ksLineSeg(8, 60, 8, 38.5, 1);
                doc2d2.ksLineSeg(8, 38.5, 12, 38.5, 1);
                doc2d2.ksLineSeg(12, 38.5, 12, 30, 1);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(0, 38.5, 0);
                doc2d2.ksLine(48, 0, 90);
                doc2d2.ksLine(48, 0, 90);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(120, 38.5, 0);
                doc2d2.ksLine(72, 0, 90);
                doc2d2.ksLineSeg(48, 30, 72, 30, 1);
                doc2d2.ksLine(60, 0, 90);
                doc2d2.ksLine(68, 0, 90);
                doc2d2.ksLine(52, 0, 90);
                doc2d2.ksLineSeg(48, 30, 48, 38.5, 1);
                doc2d2.ksLineSeg(48, 38.5, 52, 38.5, 1);
                doc2d2.ksLineSeg(52, 38.5, 52, 60, 1);
                doc2d2.ksLineSeg(52, 60, 68, 60, 1);
                doc2d2.ksLineSeg(68, 60, 68, 38.5, 1);
                doc2d2.ksLineSeg(68, 38.5, 72, 38.5, 1);
                doc2d2.ksLineSeg(72, 38.5, 72, 30, 1);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(0, 38.5, 0);
                doc2d2.ksLine(108, 0, 90);
                doc2d2.ksLine(108, 0, 90);
                doc2d2.ksLine(0, 30, 0);
                doc2d2.ksLine(180, 38.5, 0);
                doc2d2.ksLine(132, 0, 90);
                doc2d2.ksLineSeg(108, 30, 132, 30, 1);
                doc2d2.ksLine(120, 0, 90);
                doc2d2.ksLine(128, 0, 90);
                doc2d2.ksLine(112, 0, 90);
                doc2d2.ksLineSeg(108, 30, 108, 38.5, 1);
                doc2d2.ksLineSeg(108, 38.5, 112, 38.5, 1);
                doc2d2.ksLineSeg(112, 38.5, 112, 60, 1);
                doc2d2.ksLineSeg(112, 60, 128, 60, 1);
                doc2d2.ksLineSeg(128, 60, 128, 38.5, 1);
                doc2d2.ksLineSeg(128, 38.5, 132, 38.5, 1);
                doc2d2.ksLineSeg(132, 38.5, 132, 30, 1);

                // Завершаем эскиз
                skDef2.EndEdit();

                // ==== макрос "Вырезание эскиза 2" ====

                // создаём вырезное выдавливание
                var cut2 = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                var defCut2 = (ksCutExtrusionDefinition)cut2.GetDefinition();

                // находим ребро, по которому привязан эскиз №2
                var edgeColl2 = (ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_edge);
                edgeColl2.SelectByPoint(-132, 34.25, 180); // используем ваши координаты
                if (edgeColl2.GetCount() == 0)
                    throw new InvalidOperationException("Ребро для выреза не найдено.");

                var edge2 = (ksEntity)edgeColl2.Last();
                var edgeDef2 = (ksEdgeDefinition)edge2.GetDefinition();
                defCut2.SetSketch(edgeDef2.GetOwnerEntity());
                defCut2.cut = true;

                // параметры выдавливания-вычистки
                var p2 = defCut2.ExtrusionParam();
                p2.direction = (short)Direction_Type.dtNormal;
                p2.depthNormal = 360;
                p2.depthReverse = 0;
                p2.draftOutwardNormal = false;
                p2.draftOutwardReverse = false;
                p2.draftValueNormal = 0;
                p2.draftValueReverse = 0;
                p2.typeNormal = (short)End_Type.etBlind;
                p2.typeReverse = (short)End_Type.etBlind;

                defCut2.ThinParam().thin = false;
                cut2.name = "Элемент выдавливания:2";

                // цвет
                var clr2 = cut2.ColorParam();
                clr2.ambient = 0.5;
                clr2.color = 9474192;
                clr2.diffuse = 0.6;
                clr2.emission = 0.5;
                clr2.shininess = 0.8;
                clr2.specularity = 0.8;
                clr2.transparency = 1.0;

                cut2.Create();

                // === конец макроса ===

                // ==== макрос "Создание эскиза 3" ====

                // 1) Находим грань по точке (180, 30, 0)
                var faceColl3 = (ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_face);
                faceColl3.SelectByPoint(180, 30, 0);
                if (faceColl3.GetCount() == 0)
                    throw new InvalidOperationException("Грань для эскиза 3 не найдена.");
                ksEntity face3 = faceColl3.First();

                // 2) Создаём эскиз на этой грани
                ksEntity sketch3 = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                var skDef3 = (ksSketchDefinition)sketch3.GetDefinition();
                skDef3.SetPlane(face3);
                sketch3.Create();

                // 3) Начинаем редактирование эскиза
                ksDocument2D doc2d3 = skDef3.BeginEdit();

                // 4) Копируем все команды из вашего Python-макроса
                doc2d3.ksLine(-132, 44.602521164983, 90);
                doc2d3.ksLine(-108, 53.699173464767, 90);
                doc2d3.ksLine(-155.720311283723, 45, 0);
                doc2d3.ksLine(-124.600187527387, 36.5, 0);
                doc2d3.ksLineSeg(-132, 36.5, -108, 36.5, 1);
                doc2d3.ksLine(-120, 36.5, 90);
                doc2d3.ksLine(-112, 53.845461613919, 90);
                doc2d3.ksLine(-128, 53.845461613919, 90);
                doc2d3.ksLine(-72, 50.382128581024, 90);
                doc2d3.ksLineSeg(-132, 36.5, -132, 45, 1);
                doc2d3.ksLineSeg(-132, 45, -128, 45, 1);
                doc2d3.ksLineSeg(-128, 45, -128, 60, 1);
                doc2d3.ksLineSeg(-128, 60, -112, 60, 1);
                doc2d3.ksLineSeg(-112, 60, -112, 45, 1);
                doc2d3.ksLineSeg(-112, 45, -108, 45, 1);
                doc2d3.ksLineSeg(-108, 45, -108, 36.5, 1);

                doc2d3.ksLine(-72, 0, 90);
                doc2d3.ksLine(-48, 0, 90);
                doc2d3.ksLine(0, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLineSeg(-72, 36.5, -48, 36.5, 1);
                doc2d3.ksLine(-60, 0, 90);
                doc2d3.ksLine(-52, 0, 90);
                doc2d3.ksLine(-68, 0, 90);
                doc2d3.ksLineSeg(-72, 36.5, -72, 45, 1);
                doc2d3.ksLineSeg(-72, 45, -68, 45, 1);
                doc2d3.ksLineSeg(-68, 45, -68, 60, 1);
                doc2d3.ksLineSeg(-68, 60, -52, 60, 1);
                doc2d3.ksLineSeg(-52, 60, -52, 45, 1);
                doc2d3.ksLineSeg(-52, 45, -48, 45, 1);
                doc2d3.ksLineSeg(-48, 45, -48, 36.5, 1);

                doc2d3.ksLine(0, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLine(-12, 0, 90);
                doc2d3.ksLine(-12, 0, 90);
                doc2d3.ksLine(12, 0, 90);
                doc2d3.ksLine(60, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLineSeg(-12, 36.5, 12, 36.5, 1);

                doc2d3.ksLine(0, 0, 90);
                doc2d3.ksLine(8, 0, 90);
                doc2d3.ksLine(-8, 0, 90);
                doc2d3.ksLineSeg(-12, 36.5, -12, 45, 1);
                doc2d3.ksLineSeg(-12, 45, -8, 45, 1);
                doc2d3.ksLineSeg(-8, 45, -8, 60, 1);
                doc2d3.ksLineSeg(-8, 60, 8, 60, 1);
                doc2d3.ksLineSeg(8, 60, 8, 45, 1);
                doc2d3.ksLineSeg(8, 45, 12, 45, 1);
                doc2d3.ksLineSeg(12, 45, 12, 36.5, 1);

                doc2d3.ksLine(0, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLine(48, 0, 90);
                doc2d3.ksLine(48, 0, 90);
                doc2d3.ksLine(72, 0, 90);
                doc2d3.ksLine(120, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLineSeg(48, 36.5, 72, 36.5, 1);

                doc2d3.ksLine(60, 0, 90);
                doc2d3.ksLine(68, 0, 90);
                doc2d3.ksLine(52, 0, 90);
                doc2d3.ksLineSeg(48, 36.5, 48, 45, 1);
                doc2d3.ksLineSeg(48, 45, 52, 45, 1);
                doc2d3.ksLineSeg(52, 45, 52, 60, 1);
                doc2d3.ksLineSeg(52, 60, 68, 60, 1);
                doc2d3.ksLineSeg(68, 60, 68, 45, 1);
                doc2d3.ksLineSeg(68, 45, 72, 45, 1);
                doc2d3.ksLineSeg(72, 45, 72, 36.5, 1);

                doc2d3.ksLine(0, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLine(108, 0, 90);
                doc2d3.ksLine(108, 0, 90);
                doc2d3.ksLine(132, 0, 90);
                doc2d3.ksLine(180, 45, 0);
                doc2d3.ksLine(0, 36.5, 0);
                doc2d3.ksLineSeg(108, 36.5, 132, 36.5, 1);

                doc2d3.ksLine(120, 0, 90);
                doc2d3.ksLine(128, 0, 90);
                doc2d3.ksLine(112, 0, 90);
                doc2d3.ksLineSeg(108, 36.5, 108, 45, 1);
                doc2d3.ksLineSeg(108, 45, 112, 45, 1);
                doc2d3.ksLineSeg(112, 45, 112, 60, 1);
                doc2d3.ksLineSeg(112, 60, 128, 60, 1);
                doc2d3.ksLineSeg(128, 60, 128, 45, 1);
                doc2d3.ksLineSeg(128, 45, 132, 45, 1);
                doc2d3.ksLineSeg(132, 45, 132, 36.5, 1);

                // 5) Завершаем эскиз
                skDef3.EndEdit();
                // 6) Поворачиваем на 180°
                skDef3.angle = 180;
                sketch3.Update();

                // ==== макрос "Вырезание эскиза 3" ====

                // 1) создаём вырезное выдавливание
                var cut3 = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                var defCut3 = (ksCutExtrusionDefinition)cut3.GetDefinition();

                // 2) находим ребро, по которому привязан эскиз 3 (точка на ребре: (180, 60, 60))
                var edgeColl3 = (ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_edge);
                edgeColl3.SelectByPoint(180, 60, 60);
                if (edgeColl3.GetCount() == 0)
                    throw new InvalidOperationException("Ребро для выреза эскиза 3 не найдено.");
                ksEntity edge3 = (ksEntity)edgeColl3.Last();
                var edgeDef3 = (ksEdgeDefinition)edge3.GetDefinition();

                // 3) привязываем эскиз к вырезу
                defCut3.SetSketch(edgeDef3.GetOwnerEntity());
                defCut3.cut = true;

                // 4) параметры вырезного выдавливания
                var p3 = defCut3.ExtrusionParam();
                p3.direction = (short)Direction_Type.dtNormal;
                p3.depthNormal = 360;
                p3.depthReverse = 0;
                p3.draftOutwardNormal = false;
                p3.draftOutwardReverse = false;
                p3.draftValueNormal = 0;
                p3.draftValueReverse = 0;
                p3.typeNormal = (short)End_Type.etBlind;
                p3.typeReverse = (short)End_Type.etBlind;

                defCut3.ThinParam().thin = false;
                cut3.name = "Элемент выдавливания:3";

                // 5) цвет
                var clr3 = cut3.ColorParam();
                clr3.ambient = 0.5;
                clr3.color = 9474192;
                clr3.diffuse = 0.6;
                clr3.emission = 0.5;
                clr3.shininess = 0.8;
                clr3.specularity = 0.8;
                clr3.transparency = 1.0;

                // 6) создаём вырез
                cut3.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при автоматизации КОМПАС: " + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


    }
}
