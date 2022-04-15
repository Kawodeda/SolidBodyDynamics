using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SolidBodyDynamics
{
    public class Drawer
    {
        private static List<SolidBody> solidBodies = new List<SolidBody>();
        private static List<MaterialPoint> materialPoints = new List<MaterialPoint>();

        private static readonly Color mPointColor = Color.Blue;
        private static readonly float mPointSize = 2;
        private static readonly Color bodyCenterColor = Color.Green;
        private static readonly float bodyCenterSize = 2;
        private static readonly Color massCenterColor = Color.Red;
        private static readonly float massCenterSize = 2;

        private static Bitmap bmp;
        private static Graphics g;

        public static void AddToDraw(MaterialPoint _materialPoint)
        {
            materialPoints.Add(_materialPoint);
        }

        public static void AddToDraw(IEnumerable<MaterialPoint> _materialPoints)
        {
            materialPoints.AddRange(_materialPoints);
        }

        public static void AddToDraw(SolidBody _solidBody)
        {
            solidBodies.Add(_solidBody);
        }

        public static void AddToDraw(IEnumerable<SolidBody> _solidBodies)
        {
            solidBodies.AddRange(_solidBodies);
        }

        public static void ClearToDraw()
        {
            materialPoints.Clear();
            solidBodies.Clear();
        }

        public static void Draw(PictureBox pictureBox)
        {
            if (bmp != null)
                bmp.Dispose();
            if (g != null)
                g.Dispose();

            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bmp);

            foreach(var mPoint in materialPoints)
            {
                DrawMaterialPont(mPoint);
            }

            foreach(var sBody in solidBodies)
            {
                DrawSolidBody(sBody);
            }

            pictureBox.Image = bmp;
        }

        private static void DrawSolidBody(SolidBody solidBody)
        {
            List<MaterialPoint> materialPoints = solidBody.Map.Points.ToList();

            foreach(var mPoint in materialPoints)
            {
                DrawMaterialPont(mPoint);
            }

            //SolidBrush brush = new SolidBrush(bodyCenterColor);
            //Vector2 pos = solidBody.Pos;

            //g.FillRectangle(brush, pos.x - bodyCenterSize / 2, pos.y - bodyCenterSize / 2, bodyCenterSize, bodyCenterSize);

            //brush.Color = massCenterColor;
            //pos = solidBody.Pos + solidBody.MassCenterPos;

            //g.FillRectangle(brush, pos.x - massCenterSize / 2, pos.y - massCenterSize / 2, massCenterSize, massCenterSize);
        }

        private static void DrawMaterialPont(MaterialPoint mPoint)
        {
            int red = (int)(mPoint.m * 0.5);
            if (red > 255)
                red = 255;
            if (red < 0)
                red = 0;
            Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0, red));
            Vector2 pos = mPoint.Pos;

            if(mPointSize != 1)
                g.FillRectangle(brush, pos.x - mPointSize / 2, pos.y - mPointSize / 2, mPointSize, mPointSize);
            else
                g.FillRectangle(brush, pos.x, pos.y, mPointSize, mPointSize);
        }
    }
}
