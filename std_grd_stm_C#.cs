using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagement
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            Grades = new List<double>();
        }

        public double CalculateAverageGrade()
        {
            return Grades.Count > 0 ? Grades.Average() : 0.0;
        }

        public bool HasPassed(double passThreshold)
        {
            return CalculateAverageGrade() >= passThreshold;
        }
    }

  
    public class GradeManagementSystem
    {
        private List<Student> students = new List<Student>();
        private double passThreshold = 60.0;

        public void AddStudent(int id, string name)
        {
            students.Add(new Student(id, name));
            Console.WriteLine($"Student {name} added successfully.");
        }

        public void EnterGrade(int studentId, double grade)
        {
            Student student = students.Find(s => s.Id == studentId);
            if (student != null)
            {
                student.Grades.Add(grade);
                Console.WriteLine($"Grade {grade} added for {student.Name}.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DisplayStudentDetails(int studentId)
        {
            Student student = students.Find(s => s.Id == studentId);
            if (student != null)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                Console.WriteLine("Grades: " + string.Join(", ", student.Grades));
                Console.WriteLine($"Average Grade: {student.CalculateAverageGrade():F2}");
                Console.WriteLine(student.HasPassed(passThreshold) ? "Status: Passed" : "Status: Failed");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            GradeManagementSystem gradeSystem = new GradeManagementSystem();

            while (true)
            {
                Console.WriteLine("\nStudent Grade Management System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Enter Grade for Student");
                Console.WriteLine("3. Display Student Details");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();
                        gradeSystem.AddStudent(id, name);
                        break;

                    case 2:
                        Console.Write("Enter Student ID: ");
                        int studentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Grade: ");
                        double grade = double.Parse(Console.ReadLine());
                        gradeSystem.EnterGrade(studentId, grade);
                        break;

                    case 3:
                        Console.Write("Enter Student ID: ");
                        int displayId = int.Parse(Console.ReadLine());
                        gradeSystem.DisplayStudentDetails(displayId);
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

