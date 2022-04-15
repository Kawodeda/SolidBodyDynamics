using SolidBodyDynamics.Classes.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace SolidBodyDynamics
{
    public partial class Form1 : Form
    {
        DispatcherTimer timer;
        List<MaterialPoint> mPoints;
        SolidBody body;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mPoints = new List<MaterialPoint>();
            mPoints.Add(new MaterialPoint(100, 100, 1));

            Random rnd = new Random();

            int lnt = 900, s = 30, a = rnd.Next(1, 4);
            MaterialPoint[] mapPoints = new MaterialPoint[lnt];
            for(int i = 0; i < mapPoints.Length; i++)
            {
                if(i % 15 == 0)
                    a = rnd.Next(1, 10);
                mapPoints[i] = new MaterialPoint(300) ;
            }

            Vector2[] mapPos = new Vector2[lnt];
            for(int i = 0; i < mapPos.Length; i++)
            {
                mapPos[i] = new Vector2(i - (i / s) * s - s / 2, i / s - s / 2);
            }

            body = new SolidBody(
                    new MaterialPointMap(
                        mapPoints,
                        mapPos),
                    new Vector2(100, 100));

            Drawer.AddToDraw(body);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Physics.Run(body);
            Drawer.Draw(pictureBox1);
        }
    }
}
