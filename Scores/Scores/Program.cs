using System;

namespace Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter you name");
            string date = DateTime.Today.ToShortDateString();
            string name = Console.ReadLine();
            string msg = $"\nWelcome back {name}. Today is {date}";
            Console.WriteLine(msg);

            string path = @"C:\Users\Delegate\Desktop\C-Sharp-Projects\C-Sharp-Coding-Projects\Scores\Scores\StudentScores.txt";
            string[] lines = System.IO.File.ReadAllLines(path);

            double tScore = 0.0;

            Console.WriteLine("\nStudents Score: \n ");
            foreach (string line in lines)
            {
                Console.Write("\n"+ line );
                double score = Convert.ToDouble(line);
                tScore += score;
            }

            double avgScore = tScore / lines.Length;

            Console.WriteLine("\nTotal of " + lines.Length + " Student scores. \tAverage score: " + avgScore);

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
