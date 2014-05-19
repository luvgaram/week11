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

        private ArrayList shapes = new ArrayList();

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
            Square square = new Square(left, top, right, bottom);
            Ellipse ellipse = new Ellipse(left, top, right, bottom);
            Triangle triangle = new Triangle(left, top, right, bottom);

            switch (type)
            {
                case 1:
                    shapes.Add(square);
                    break;
                case 2:
                    shapes.Add(rectangle);
                    break;
                case 3:
                    shapes.Add(ellipse);
                    break;
                case 4:
                    shapes.Add(triangle);
                    break;
            }
            Form1_Paint(null, null);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Shape shape in shapes)
                {
                    shape.Show(g);
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
                    foreach (Shape shape in rectangls)
                    {
                        shape.Show(g);
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
               serializer.Serialize(rs, shapes);
               rs.Close();
           }
         }

        private void 종료하기QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
}
