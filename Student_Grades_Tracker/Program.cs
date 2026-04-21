namespace Student_Grades_Tracker
{
    internal class Program
    {
        static void GetLevel(double averageGrade, string studentName)
        {
            if (averageGrade >= 0 && averageGrade <= 20)
            {
                Console.WriteLine($"{studentName} average grade is {Math.Round(averageGrade, 2)} and he is freshman");
            }
            else if (averageGrade > 20 && averageGrade <= 40)
            {
                Console.WriteLine($"{studentName} average grade is {Math.Round(averageGrade, 2)} and he is sophomore");
            }
            else if (averageGrade > 40 && averageGrade <= 80)
            {
                Console.WriteLine($"{studentName} average grade is {Math.Round(averageGrade, 2)} and he is junior");
            }
            else if (averageGrade > 80 && averageGrade <= 100)
            {
                Console.WriteLine($"{studentName} average grade is {Math.Round(averageGrade,2)} and he is senior");
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View current students with grades");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Choice: ");
                var userInput = int.TryParse(Console.ReadLine() ,out int a);
                switch (a)
                {
                    case 1:
                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine();
                        Random rand = new Random();
                        students[studentName] = new List<int> { rand.Next(1, 101), rand.Next(1, 101), rand.Next(1, 101) };
                        Console.WriteLine($"student {studentName} has been added.");
                        break;
                    case 2:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No Students available to view Please add one.");
                            break;
                        }
                        for (int i = 0; i <= students.Count -1; i++)
                        {
                            double studentAverage = 0;
                            List<int> grades = students.ElementAt(i).Value;
                            Console.Write("Grades are :");
                            for (int j = 0; j <= grades.Count -1; j++)
                            {
                                studentAverage += grades[j];
                                Console.Write(grades[j] + " ");
                            }
                            studentAverage /= grades.Count;

                            GetLevel(studentAverage, students.ElementAt(i).Key);
                        }
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }

        }
    }
}
