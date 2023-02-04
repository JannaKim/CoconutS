using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoconutS
{

    // 정적 클래스의 모든 멤버는 static으로 선언되어야 한다
    public static class PS
    {
        static PS() // 정적 클래스는 생성자를 포함할 수 없습니다 -> 가장 처음 접근할때 한 번 타는 듯
        {
            System.Console.WriteLine(" constructor : MyStaticClass ");
        }

        public static int Test(int a, int b)
        {
            return a + b;
        }

        public class ProblemSolving
        {
            public int n;
            public ProblemSolving()
            {
                System.Console.WriteLine(" constructor : ProblemSolving ");
            }
            public virtual void Input()
            {

            }
            public virtual void Solve()
            {

            }

            public virtual void Run()
            { 

            }
        }

        //클래스명 앞에다 sealed 키워드를 사용하게 되면, 이 클래스를 상속시키는 건 더이상 할 수 없습니다.
        public sealed class WineTasting : ProblemSolving
        {
            private int[] wine;
            private int[] dp;
            private int ans;

            public WineTasting()
            {
                //this.num = num;
                System.Console.WriteLine(" constructor : WineTasting.");
            }

            public override void Input()
            {
                n = int.Parse(System.Console.ReadLine());

                wine = new int[n]; // n 크기 동적 배열 생성
                dp = new int[n];

                for (int i = 0; i < n; ++i)
                {
                    wine[i] = int.Parse(System.Console.ReadLine());
                }
            }
            public override void Solve()
            {
                dp[0] = wine[0];
                dp[1] = wine[0] + wine[1];

                for (int i = 2; i < n; ++i)
                {
                    if (dp[i] < wine[i] + dp[i - 2])
                        dp[i] = wine[i] + dp[i - 2];
                    if (i - 3 > 0 && dp[i] < wine[i] + wine[i - 1] + dp[i - 3])
                        dp[i] = wine[i] + wine[i - 1] + dp[i - 3];

                    if (ans < dp[i])
                        ans = dp[i];
                }
            }

            public override void Run()
            {
                Input();
                Solve();
                System.Console.WriteLine(ans);
            }
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
            //MyStaticClass.Test(5, 3);
            //ReadFromFile("");

            PS.WineTasting winetasting = new PS.WineTasting();
            winetasting.Run();


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
