using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w11_file1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(new FileStream("수업.txt", FileMode.Create));//텍스트 파일을 쓸건데, (수업.txt)이고, FileMode.Create로 열어라

            sw.WriteLine("프로그래밍 연습");
            sw.Write("프로그래밍 ");
            sw.Write("연습\n");
            
            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("수업.txt", FileMode.Open));//텍스트 파일을 읽을건데, (수업.txt)이고, FileMode.Open으로 열어라

            while (sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }
            // 읽어요

            sr.Close();

            Console.ReadLine();
        }
    }
}

