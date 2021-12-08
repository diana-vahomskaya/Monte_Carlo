using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Monte_Carlo
{
    public class Drawer
    {
        public PictureBox pic_box;
        public Bitmap bmp;
        public Graphics g;

        public Color
            ColorBackGround = Color.Black,
            ColorPen = Color.Green,
            ColorBrush = Color.Black;

        public int width, height;
        public double minX, maxX, minY, maxY, minZ, maxZ;

        public Drawer() { }
        public Drawer(PictureBox pb, Array _sizes)
        {
            pic_box = pb;
            if (_sizes == null || _sizes.Length < 1)
            {
                minX = minY = minZ = 0;
                maxX = maxY = maxZ = 1;
            }
            else
            {
                double[] sizes;
                sizes = (double[])_sizes;
                minX = sizes[0];
                maxX = sizes[1];
                minY = sizes[2];
                maxY = sizes[3];
                minZ = sizes[4];
                maxZ = sizes[5];
            }
        }
        public void resize(Array _sizes)
        {
            double[] sizes;
            sizes = (double[])_sizes;
            minX = sizes[0];
            maxX = sizes[1];
            minY = sizes[2];
            maxY = sizes[3];
            minZ = sizes[4];
            maxZ = sizes[5];
            GraphicsSetTransform();
        }
        public void InitGraphics()
        {
            width = pic_box.Width;
            height = pic_box.Height;
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            GraphicsSetTransform();
        }
        public void GraphicsSetTransform()
        {
            g.ResetTransform();
            g.ScaleTransform((float)((double)width / (maxX - minX)), -(float)((double)height / (maxY - minY)));
            g.TranslateTransform((float)maxX, -(float)maxY);
        }
    }

    public class Drawer3D : Drawer
    {
        public Drawer3D() { }
        public Drawer3D(PictureBox pb)
        {
            pic_box = pb;
            minX = minY = minZ = 0;
            maxX = maxY = maxZ = 1;
            InitGraphics();
        }
        public Drawer3D(PictureBox pb, Array _sizes)
        {
            pic_box = pb;
            if (_sizes == null || _sizes.Length < 1)
            {
                minX = minY = minZ = 0;
                maxX = maxY = maxZ = 1;
            }
            else
            {
                resize(_sizes);
            }
            InitGraphics();
        }

        public void Draw(double[,] data, double angleZ, double angleY, double mult)
        {
            g.Clear(ColorBackGround);

            int l1 = data.GetLength(0);
            int l2 = data.GetLength(1);

            double x1 = 0, y1 = 0, z1 = 0;
            double x2 = 0, y2 = 0, z2 = 0;
            double x3 = 0, y3 = 0, z3 = 0;
            double x4 = 0, y4 = 0, z4 = 0;

            double teta1, teta2, fi1, fi2;

            for (int i = l1 - 1; i > 0; i--)
            {
                for (int j = l2; j > 0; j--)
                {
                    if (j == l2)
                    {
                        z1 = data[i - 1, j - 1];
                        z2 = data[i, j - 1];
                        z3 = data[i, 0];
                        z4 = data[i - 1, 0];
                    }
                    else
                    {
                        z1 = data[i - 1, j - 1];
                        z2 = data[i, j - 1];
                        z3 = data[i, j];
                        z4 = data[i - 1, j];
                    }

                    teta1 = Math.PI * (double)(i - 1) / (double)(l1 * 2.0) - 0.01;
                    teta2 = Math.PI * (double)(i) / (double)(l1 * 2.0) - 0.01;
                    fi1 = Math.PI * (double)(j - 1) / (double)(l1 / 2.0) - 0.01;
                    fi2 = Math.PI * (double)(j) / (double)(l1 / 2.0) - 0.01;

                    x1 = 0.5 * (maxX + minX) + 0.5 * (maxX - minX) * Math.Sin(teta1) * Math.Cos(fi1);
                    y1 = 0.5 * (maxY + minY) + 0.5 * (maxY - minY) * Math.Sin(teta1) * Math.Sin(fi1);

                    x2 = 0.5 * (maxX + minX) + 0.5 * (maxX - minX) * Math.Sin(teta2) * Math.Cos(fi1);
                    y2 = 0.5 * (maxY + minY) + 0.5 * (maxY - minY) * Math.Sin(teta2) * Math.Sin(fi1);

                    x3 = 0.5 * (maxX + minX) + 0.5 * (maxX - minX) * Math.Sin(teta2) * Math.Cos(fi2);
                    y3 = 0.5 * (maxY + minY) + 0.5 * (maxY - minY) * Math.Sin(teta2) * Math.Sin(fi2);

                    x4 = 0.5 * (maxX + minX) + 0.5 * (maxX - minX) * Math.Sin(teta1) * Math.Cos(fi2);
                    y4 = 0.5 * (maxY + minY) + 0.5 * (maxY - minY) * Math.Sin(teta1) * Math.Sin(fi2);

                    mat4 m4 = new mat4();
                    m4.scale(mult, mult, mult);
                    m4.perspective(10);
                    m4.rotateZ(angleZ);
                    m4.rotateY(angleY);

                    vec4 v1 = new vec4(x1, y1, z1);
                    vec4 v2 = new vec4(x2, y2, z2);
                    vec4 v3 = new vec4(x3, y3, z3);
                    vec4 v4 = new vec4(x4, y4, z4);

                    v1 = v1 * m4;
                    v2 = v2 * m4;
                    v3 = v3 * m4;
                    v4 = v4 * m4;

                    PointF[] matr = new PointF[]
                    {
                        new PointF(v1.y(), v1.z()),
                        new PointF(v2.y(), v2.z()),
                        new PointF(v3.y(), v3.z()),
                        new PointF(v4.y(), v4.z())
                    };

                    Color colorPen, colorBrush;
                    colorBrush = Color.FromArgb(
                        (int)(data[i - 1, j - 1] * 255),
                        (int)(data[i - 1, j - 1] * 255),
                        (int)(data[i - 1, j - 1] * 255));
                    colorPen = Color.FromArgb(
                        (int)(Math.Sqrt(data[i - 1, j - 1]) * 255),
                        (int)(Math.Sqrt(data[i - 1, j - 1]) * 255),
                        (int)(Math.Sqrt(data[i - 1, j - 1]) * 255));

                    SolidBrush brush = new SolidBrush(colorBrush);
                    Pen pen = new Pen(colorBrush, (float)0);

                    g.DrawPolygon(pen, matr);
                    g.FillPolygon(brush, matr);
                }
            }
            pic_box.Image = bmp;
        }
    }

    public class DrawerSmth
    {
        PictureBox pic_box;
        Bitmap bmp;
        Graphics g;
        Color clr;
        Brush brsh;
        Pen pen;

        int width, height;
        int sizeX, sizeY;
        double minX, maxX, minY, maxY;
        int length1, length2;

        double[,] data;

        DrawerSmth(PictureBox pbox, double[,] dt, Array sizes)
        {
            pic_box = pbox;
            width = pic_box.Width;
            height = pic_box.Height;
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            data = dt;
            length1 = data.GetLength(0);
            length2 = data.GetLength(1);

            brsh = Brushes.Black;
            pen = new Pen(brsh);

            minX = (double)sizes.GetValue(0);
            maxX = (double)sizes.GetValue(1);
            minY = (double)sizes.GetValue(2);
            maxY = (double)sizes.GetValue(3);
        }

        public void convert_255()
        {
            double max = 0;
            for (int i = 0; i < length1; i++)
                for (int j = 0; j < length2; j++)
                {
                    if (data[i, j] > max) max = data[i, j];
                }
            for (int i = 0; i < length1; i++)
                for (int j = 0; j < length2; j++)
                {
                    data[i, j] = 255 * data[i, j] / max;
                }
        }

        public void draw()
        {
            convert_255();
            /*double cx = (size) * lambda * k / 2;
            double cy = (size) * lambda * k / 2;
            double teta;
            double fi;
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    teta = Math.PI * (double)i / (double)(I_size * 2.0);
                    fi = Math.PI * (double)j / (double)(I_size / 2.0);
                    double x = cx + r * Math.Sin(teta) * Math.Cos(fi);
                    double y = cy + r * Math.Sin(teta) * Math.Sin(fi);
                    double z = r * Math.Cos(teta);

                    var = get_pt()
                    g.FillEllipse(brsh, get_pt);
                }
            }*/
        }

        public Point get_pt(double x, double y)
        {
            var ptx = (x - minX) / (maxX - minX) * width;
            var pty = (1 - (y - minY) / (maxY - minY)) * height;
            Point pt = new Point((int)ptx, (int)pty);
            return pt;
        }
    }
}