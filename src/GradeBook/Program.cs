using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Sidney's Grade Book");
            book.GradeAdded += OnGradeAdded;


            // input loop for grades
            System.Console.WriteLine("Enter a grade or 'q' to quit.");
            var input = Console.ReadLine();

            input = EnterGrades(book, input);

            var stats = book.GetStatistics();
            
            System.Console.WriteLine($"For the book named {book.Name}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            System.Console.WriteLine($"The highest grade is {stats.High:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static string EnterGrades(IBook book, string input)
        {

            while (input != "q")
            {
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                System.Console.WriteLine("Enter a grade or 'q' to quit.");
                input = Console.ReadLine();
            }

            return input;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added.");
        }
    }
}
