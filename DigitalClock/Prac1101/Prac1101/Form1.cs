using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prac1101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[,] x = new double[3, 4];
        double[,] y = new double[3, 4];
        int[] points = new int[3];

        private void DisplayPoint(float x, float y)
        {
            Graphics g = panel.CreateGraphics();
            g.DrawLine(Pens.White, x, panel.Height - y, x + 0.1f, panel.Height - y);
        }

        private void DeletePoint(float x, float y)
        {
            Graphics g = panel.CreateGraphics();
            g.DrawLine(Pens.Black, x, panel.Height - y, x + 0.1f, panel.Height - y);
        }

        private void DisplayLine(float x1, float y1, float x2, float y2)
        {
            Graphics g = panel.CreateGraphics();
            if ((x1 == x2) && (y1 == y2))
            {
                DisplayPoint(x1, y1);
            }
            else
            {
                g.DrawLine(Pens.White, x1, panel.Height - y1, x2, panel.Height - y2);
            }
        }

        private void DeleteLine(float x1, float y1, float x2, float y2)
        {
            Graphics g = panel.CreateGraphics();
            if ((x1 == x2) && (y1 == y2))
            {
                DeletePoint(x1, y1);
            }
            else
            {
                g.DrawLine(Pens.Black, x1, panel.Height - y1, x2, panel.Height - y2);
            }
        }

        private void DrawPolygon(int o)
        {
            int i, j;
            for (i = 0; i < points[o]; i++)
            {
                j = (i + 1) % points[o];
                DisplayLine((float)x[o, i], (float)y[o, i], (float)x[o, j], (float)y[o, j]);
            }
        }

        private void DeletePolygon(int o)
        {
            int i, j;
            for (i = 0; i < points[o]; i++)
            {
                j = (i + 1) % points[o];
                DeleteLine((float)x[o, i], (float)y[o, i], (float)x[o, j], (float)y[o, j]);
            }
        }

        void translate(int o, int i, double tx, double ty)
        {
            x[o, i] += tx;
            y[o, i] += ty;
        }

        void rotate(int o, int i, double t)
        {
            double x1, y1;

            x1 = x[o, i];
            y1 = y[o, i];
            x[o, i] = x1 * Math.Cos(t) - y1 * Math.Sin(t);
            y[o, i] = x1 * Math.Sin(t) + y1 * Math.Cos(t);
        }

        void f_rotate(int o, int i, double t, double x, double y)
        {
            translate(o, i, -x, -y);
            rotate(o, i, t);
            translate(o, i, x, y);
        }

        void scale(int o, int i, double sx, double sy)
        {
            x[o, i] *= sx;
            y[o, i] *= sy;
        }

        void f_scale(int o, int i, double sx, double sy, double x, double y)
        {
            translate(o, i, -x, -y);
            scale(o, i, sx, sy);
            translate(o, i, x, y);
        }
       

        private void btnStart_Click(object sender, EventArgs e)
        {
            /*int i, n;

            x[0, 0] = -5; y[0, 0] = 0;
            x[0, 1] = 0; y[0, 1] = -5;
            x[0, 2] = 5; y[0, 2] = 0;
            x[0, 3] = 0; y[0, 3] = 200;

            points[0] = 4;

            x[1, 0] = -5; y[1, 0] = 0;
            x[1, 1] = 0; y[1, 1] = -5;
            x[1, 2] = 5; y[1, 2] = 0;
            x[1, 3] = 0; y[1, 3] = 150;

            points[1] = 4;

            x[2, 0] = -5; y[2, 0] = 0;
            x[2, 1] = 0; y[2, 1] = -5;
            x[2, 2] = 5; y[2, 2] = 0;
            x[2, 3] = 0; y[2, 3] = 100;

            points[2] = 4;

            for (i = 0; i < 4; i++)
            {
                translate(0, i, 250, 250);
                translate(1, i, 250, 250);
                translate(2, i, 250, 250);
            }
            DrawPolygon(0);
            DrawPolygon(1);
            DrawPolygon(2);
            for (n = 1; ; n++)
            {

                
                System.Threading.Thread.Sleep(1000);
                DeletePolygon(0);

                for (i = 0; i < 4; i++)
                {
                    f_rotate(0, i, -0.10472, 250, 250);
                }
                DrawPolygon(0);

                if ((n % 60) == 0)
                {
                    DeletePolygon(1);
                    for (i = 0; i < 4; i++)
                    {
                        f_rotate(1, i, -0.10472, 250, 250);
                    }
                    DrawPolygon(1);
                }

                if ((n % 3600) == 0)
                {
                    DeletePolygon(2);
                    for (i = 0; i < 4; i++)
                    {
                        f_rotate(2, i, -0.10472, 250, 250);
                    }
                    DrawPolygon(2);
                }

            }*/

            _t = new System.Threading.Thread(new System.Threading.ThreadStart(DoSomething));
            _t.Start();
        }

        private System.Threading.Thread _t;

        private void DoSomething()
        {
            int i, n;

            x[0, 0] = -5; y[0, 0] = 0;
            x[0, 1] = 0; y[0, 1] = -5;
            x[0, 2] = 5; y[0, 2] = 0;
            x[0, 3] = 0; y[0, 3] = 200;

            points[0] = 4;

            x[1, 0] = -5; y[1, 0] = 0;
            x[1, 1] = 0; y[1, 1] = -5;
            x[1, 2] = 5; y[1, 2] = 0;
            x[1, 3] = 0; y[1, 3] = 150;

            points[1] = 4;

            x[2, 0] = -5; y[2, 0] = 0;
            x[2, 1] = 0; y[2, 1] = -5;
            x[2, 2] = 5; y[2, 2] = 0;
            x[2, 3] = 0; y[2, 3] = 100;

            points[2] = 4;

            int sec = int.Parse(txtSec.Text);
            int min = int.Parse(txtMin.Text);
            int hrs = int.Parse(txtHrs.Text);
            for (i = 0; i < 4; i++)
            {
                rotate(0, i, -0.10472*sec);
                rotate(1, i, -0.10472*min);
                rotate(2, i, -0.10472*hrs*5);
            }

            for (i = 0; i < 4; i++)
            {
                translate(0, i, 250, 250);
                translate(1, i, 250, 250);
                translate(2, i, 250, 250);
            }
            DrawPolygon(0);
            DrawPolygon(1);
            DrawPolygon(2);
            for (n = 1*sec; ; n++)
            {
                
                System.Threading.Thread.Sleep(1000);

                DeletePolygon(0);
                for (i = 0; i < 4; i++)
                {
                    f_rotate(0, i, -0.10472, 250, 250);
                }
                /*
                DeletePolygon(1);
                for (i = 0; i < 4; i++)
                {
                    f_rotate(1, i, -0.10472/60, 250, 250);
                }
                DeletePolygon(2);
                for (i = 0; i < 4; i++)
                {
                    f_rotate(2, i, -0.10472/3600, 250, 250);
                }
                DrawPolygon(0);
                DrawPolygon(1);
                DrawPolygon(2);
                */
                DrawPolygon(0);

                if ((n % 60) == 0)
                {
                    DeletePolygon(1);
                    for (i = 0; i < 4; i++)
                    {
                        f_rotate(1, i, -0.10472, 250, 250);
                    }
                    DrawPolygon(1);
                }
                else
                {
                    DrawPolygon(1);
                }

                if (((n+(min*60)) % 3600) == 0)
                {
                    DeletePolygon(2);
                    for (i = 0; i < 4; i++)
                    {
                        f_rotate(2, i, -0.10472*5, 250, 250);
                    }
                    DrawPolygon(2);
                }
                else
                {
                    DrawPolygon(2);
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _t.Abort();
            panel.Invalidate();
        }
    }
}
