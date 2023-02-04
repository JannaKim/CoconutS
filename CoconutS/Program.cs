using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoconutS
{

    // 정적 클래스의 모든 멤버는 static으로 선언되어야 한다
    public static class MyStaticClass
    {
        static MyStaticClass() // 정적 클래스는 생성자를 포함할 수 없습니다 -> 가장 처음 접근할때 한 번 타는 듯
        {
            System.Console.WriteLine(" constructor : PS ");
        }

        public static int Test(int a, int b)
        {
            return a + b;
        }
    }

    public class Program
    {
        static Program() // Main 전에 생성자를 먼저 탄다
        {
            System.Console.WriteLine(" constructor : Program ");
        }
        static void Main(string[] args)
        {
            MyStaticClass.Test(5, 3);

            ReadFromFile("");

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private static void ReadFromFile(string filename)
        {
            // System.IO.File 클래스의
            // 정적 메서드 ReadAllText 및 ReadAllLines를 사용하여 텍스트 파일의 내용을 읽습니다.

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"..\2156.txt");

            // 상대 경로로부터 절대 경로를 구하려면 Path 클래스에 있는 GetFullPath라는 정적 메서드를 사용한다.
            // var fullPath = Path.GetFullPath(@”..\Example.txt”);

            System.Console.WriteLine("2156");
            System.Console.WriteLine("input : ");

            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                System.Console.WriteLine(line);
            }


            System.IO.StreamReader Console = new System.IO.StreamReader(@"..\2156.txt");

            // Console.ReadLine() 대신 sr.ReadLine;
        }
    }
}
