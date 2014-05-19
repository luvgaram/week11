using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w11_binaryFile
{
    class Student
    {
        private string Name;
        private string Subject;
        private int Score;

        public Student(string Name, string Subject, int Score)
        {
            this.Name = Name;
            this.Subject = Subject;
            this.Score = Score;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSubject()
        {
            return Subject;
        }

        public int GetScore()
        {
            return Score;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));//바이너리 파일을 쓸건데, (a.dat)이고, FileMode.Create로 열어라

            Student student = new Student("임은주", "프로그래밍 연습", 100);
            bw.Write(student.GetName());
            bw.Write(student.GetSubject());
            bw.Write(student.GetScore());

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));//바이너리 파일을 읽을건데, (a.dat)이고, FileMode.Open으로 열어라

            student = new Student(br.ReadString(), br.ReadString(), br.ReadInt32());

            Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());
            
            br.Close();

            Console.ReadLine();
        }
    }
}