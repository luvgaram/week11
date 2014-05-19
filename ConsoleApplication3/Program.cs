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
    public class Student
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
        static void Add(ref ArrayList students)
        {
            Console.WriteLine("이름, 과목, 성적을 쉼표로 나누어 입력하세요.");
            Console.Write("(ex.홍길동,국어,90) : ");
            string s = Console.ReadLine();
            string[] words = s.Split(',');
            int score = Int32.Parse(words[2]);
            
            students.Add(new Student(words[0], words[1], score));

        }
        static void Main(string[] args)
        {
            string more = "y";
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            ArrayList students = new ArrayList();

            do
            {
                Add(ref students);
                Console.Write("더 입력하시겠습니까? (중단하고 결과를 보려면 n) : ");
                more = Console.ReadLine();
                Console.WriteLine();
            } while (more != "n");

            serializer.Serialize(ws, students); //array리스트로 직렬화

            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            students = (ArrayList)deserializer.Deserialize(rs); // 역직렬화
            foreach (Student student in students)
                Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());
            rs.Close();

            Console.ReadLine();
        }
    }
}