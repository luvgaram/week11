using System;
using System.IO;
using System.Collections.Generic;
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
           
            Student student = new Student("임은주", "프로그래밍연습", 100);
            serializer.Serialize(ws, student); 

            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open); 
            BinaryFormatter deserializer = new BinaryFormatter(); 

            student = (Student)deserializer.Deserialize(rs); 
            Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());
            rs.Close();

            Console.ReadLine();
        }
    }
}