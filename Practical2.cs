using System;

namespace EmployeePayroll
{
    // Interface
    interface IPayroll
    {
        void CalculateSalary();
    }

    // Base Class
    class Employee
    {
        public int EmpId;
        public string Name;
        public double BasicSalary;
        public int Leaves;

        public Employee()
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" Employee Payroll Management");
            Console.WriteLine("=================================");
        }

        public void AcceptDetails()
        {
            Console.Write("Enter Employee ID : ");
            EmpId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name : ");
            Name = Console.ReadLine();

            Console.Write("Enter Basic Salary : ");
            BasicSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Leaves Taken : ");
            Leaves = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\nEmployee ID : " + EmpId);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Basic Salary : " + BasicSalary);
            Console.WriteLine("Leaves Taken : " + Leaves);
        }
    }

    // Full-Time Employee
    class FullTimeEmployee : Employee, IPayroll
    {
        public void CalculateSalary()
        {
            double hra = BasicSalary * 0.40;
            double da = BasicSalary * 0.20;
            double pf = BasicSalary * 0.12;

            double deduction = 0;

            // First 2 leaves are free
            if (Leaves > 2)
            {
                deduction = (Leaves - 2) * 500;
            }

            double netSalary = (BasicSalary + hra + da) - pf - deduction;

            Console.WriteLine("Employee Type : Full-Time");
            Console.WriteLine("Leave Deduction : " + deduction);
            Console.WriteLine("Net Salary : " + netSalary);
        }
    }

    // Part-Time Employee
    class PartTimeEmployee : Employee, IPayroll
    {
        public void CalculateSalary()
        {
            double allowance = BasicSalary * 0.15;

            double deduction = 0;

            // One leave is free
            if (Leaves > 1)
            {
                deduction = (Leaves - 1) * 300;
            }

            double netSalary = BasicSalary + allowance - deduction;

            Console.WriteLine("Employee Type : Part-Time");
            Console.WriteLine("Leave Deduction : " + deduction);
            Console.WriteLine("Net Salary : " + netSalary);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPayroll emp;

            Console.WriteLine("1. Full-Time Employee");
            Console.WriteLine("2. Part-Time Employee");
            Console.Write("Enter Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                FullTimeEmployee ft = new FullTimeEmployee();
                ft.AcceptDetails();
                ft.DisplayDetails();

                emp = ft;     // Polymorphism
                emp.CalculateSalary();
            }
            else
            {
                PartTimeEmployee pt = new PartTimeEmployee();
                pt.AcceptDetails();
                pt.DisplayDetails();

                emp = pt;     // Polymorphism
                emp.CalculateSalary();
            }

            Console.ReadLine();
        }
    }
}
