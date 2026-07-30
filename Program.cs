using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Student
{
    // Private Data Members
    private int studentId;
    private string studentName;
    private int age;
    private string course;

    // Constructor
    public Student(int id, string name, int studentAge, string studentCourse)
    {
        studentId = id;
        studentName = name;
        age = studentAge;
        course = studentCourse;
    }

    // Method to Display Student Details
    public void DisplayDetails()
    {
        Console.WriteLine("\n Student Admission Details");
        Console.WriteLine("Student ID   : " + studentId);
        Console.WriteLine("Student Name : " + studentName);
        Console.WriteLine("Age          : " + age);
        Console.WriteLine("Course       : " + course);
    }
}


class Program
{
    static int ReadInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value))
                return value;
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Student Admission Management");

        int id = ReadInt("Enter Student ID: ");
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        int age = ReadInt("Enter Age: ");
        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        Student s1 = new Student(id, name, age, course);
        s1.DisplayDetails();

        Console.WriteLine("\nAdmission Successful!");
    }
}
