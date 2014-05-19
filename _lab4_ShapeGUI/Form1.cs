using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace _lab4_ShapeGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private ArrayList rectangles = new ArrayList();

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Random random = new Random();
            int type = random.Next(1, 5);
            int left = random.Next(1, 100);
            int top = random.Next(1, 100);
            int right = random.Next(200, 300);
            int bottom = random.Next(200, 300);
            Brush Color = Brushes.SkyBlue;

            Rectangle rectangle = new Rectangle(left, top, right, bottom);
            Square square = new Square(left, top, right, Color);
            Ellipse ellipse = new Ellipse(left, top, right, Color);
            Triangle triangle = new Triangle(left, top, right, Color);

            switch (type)
            {
                case 1:
                    rectangles.Add(square);
                    break;
                case 2:
                    rectangles.Add(rectangle);
                    break;
                case 3:
                    rectangles.Add(ellipse);
                    break;
                case 4:
                    rectangles.Add(triangle);
                    break;
            }
            Form1_Paint(null, null);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.Show(g);
                }
            }
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // 파일 불러오기

            if (openFileDialog.ShowDialog() == DialogResult.OK)//반환값 체크(ok버튼 누를때만 로드함)
            {
                ArrayList rectangls = new ArrayList();
                Stream rs = new FileStream(openFileDialog.FileName, FileMode.Open);//바이너리 파일을 쓸건데, 유저한테 입력받고, FileMode.Open으로 열어라
                BinaryFormatter deserializer = new BinaryFormatter();

                rectangls = (ArrayList)deserializer.Deserialize(rs); // 역직렬화
                using (Graphics g = this.CreateGraphics())
                {
                    foreach (Rectangle rectangle in rectangls)
                    {
                        rectangle.Show(g);
                    }
                }
                rs.Close();
            }
        }

        private void 저장하기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveFileDialog saveFileDialog = new SaveFileDialog(); // 파일 저장하기

           if (saveFileDialog.ShowDialog() == DialogResult.OK)//반환값 체크(저장버튼 누를때만 저장함)
           {
               Stream rs = new FileStream(saveFileDialog.FileName, FileMode.Create);
               BinaryFormatter serializer = new BinaryFormatter();

               ArrayList rectangls = new ArrayList();
               serializer.Serialize(rs, rectangles);
               rs.Close();
           }
         }

        private void 종료하기QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    [Serializable] // attribute
    class Rectangle
    {
        protected Point LeftTop;
        protected Point RightBottom;


        public Rectangle(int Left, int Top, int Right, int Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public virtual void Show(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

        }
    }

    [Serializable] // attribute
    class Square : Rectangle
    {
        private Brush Color;

        public Square(int Left, int Top, int Width, Brush Color)
            : base(Left, Top, Left + Width, Top + Width)
        {
            this.Color = Color;
        }

        public override void Show(Graphics g)
        {
            g.FillRectangle(Color,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    [Serializable] // attribute
    class Triangle : Rectangle
    {
        private Brush Color;

        public Triangle(int Left, int Top, int Width, Brush Color)
            : base(Left, Top, Left + Width, Top + Width)
        {
            this.Color = Color;

        }

        public override void Show(Graphics g)
        {
            Point[] pts = new Point[] { new Point((LeftTop.X + RightBottom.Y) / 2, LeftTop.X), new Point(LeftTop.X, RightBottom.Y), new Point(RightBottom.Y, RightBottom.X) };
            g.FillPolygon(Color, pts);
            g.DrawPolygon(Pens.Black, pts);
        }
    }

    [Serializable] // attribute
    class Ellipse : Rectangle
    {
        private Brush Color;

        public Ellipse(int Left, int Top, int Width, Brush Color)
            : base(Left, Top, Left + Width, Top + Width)
        {
            this.Color = Color;
        }

        public override void Show(Graphics g)
        {
            g.FillEllipse(Brushes.SkyBlue,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawEllipse(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

        }
    }
}
