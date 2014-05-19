using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 저장하기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); //사용자에게 입력받아 파일명 지정

            if (saveFileDialog.ShowDialog() == DialogResult.OK)//반환값 체크(저장버튼 누를때만 저장함)
            {
                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create));//텍스트 파일을 쓸건데, (수업.txt)이고, FileMode.Create로 열어라
                sw.WriteLine(textBox1.Text);
                sw.Close();
            }
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // 파일 불러오기

            if (openFileDialog.ShowDialog() == DialogResult.OK)//반환값 체크(저장버튼 누를때만 저장함)
            {
                StreamReader sr = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open));//텍스트 파일을 쓸건데, (수업.txt)이고, FileMode.Create로 열어라
                textBox1.Text = sr.ReadToEnd();
                
                sr.Close();
            }
        }

        private void 종료하기QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
