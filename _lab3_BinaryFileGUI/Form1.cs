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
using _lab1_Arraylist;

namespace _lab3_BinaryFileGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // 파일 불러오기

            if (openFileDialog.ShowDialog() == DialogResult.OK)//반환값 체크(저장버튼 누를때만 저장함)
            {
                ArrayList students = new ArrayList();
                Stream rs = new FileStream(openFileDialog.FileName, FileMode.Open);//바이너리 파일을 쓸건데, 유저한테 입력받고, FileMode.Open으로 열어라
                BinaryFormatter deserializer = new BinaryFormatter();

                students = (ArrayList)deserializer.Deserialize(rs); // 역직렬화
                foreach (Student student in students)
                {
                    listBox1.Items.Add(student.GetName() + "\t" + student.GetSubject() + "\t" + student.GetScore());
                }
                rs.Close();
            }
        }
    }
}
