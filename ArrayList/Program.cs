using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace _lab1_Arraylist
{
    [Serializable] // attribute
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
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            ArrayList students = new ArrayList();
            students.Add(new Student("조영호", "국어", 80));
            students.Add(new Student("홍길동", "불어", 90));
            students.Add(new Student("임꺽정", "수학", 85));
            students.Add(new Student("아이유", "영어", 70));

            serializer.Serialize(ws, students); //array리스트로 직렬화

            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            students = (ArrayList)deserializer.Deserialize(rs); // 역직렬화
            foreach(Student student in students)
            Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());
            rs.Close();

            Console.ReadLine();
        }
    }
}
