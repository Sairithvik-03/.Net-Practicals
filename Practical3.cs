using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Expense(string category, decimal amount, DateTime date)
    {
        Category = category;
        Amount = amount;
        Date = date;
    }
}

class ExpenseManager
{
    private List<Expense> expenses = new List<Expense>();

    public void AddExpense(string category, decimal amount, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be empty.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        expenses.Add(new Expense(category, amount, date));
    }

    public void DisplayExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("\nNo expenses found.");
            return;
        }

        Console.WriteLine("\nExpense List");
        Console.WriteLine("-----------------------------------------");

        foreach (var expense in expenses)
        {
            Console.WriteLine($"{expense.Date:dd-MM-yyyy} | {expense.Category,-15} | ${expense.Amount}");
        }
    }

    public decimal GetTotalExpense()
    {
        return expenses.Sum(e => e.Amount);
    }
}
class Program
{
    static void Main(string[] args)
    {
        ExpenseManager manager = new ExpenseManager();

        while (true)
        {
            Console.WriteLine("\n===== Expense Tracker =====");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. View Total Expense");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Category: ");
                        string category = Console.ReadLine();

                        Console.Write("Enter Amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Enter Date (yyyy-MM-dd): ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());

                        manager.AddExpense(category, amount, date);
                        Console.WriteLine("Expense added successfully!");
                        break;

                    case 2:
                        manager.DisplayExpenses();
                        break;

                    case 3:
                        Console.WriteLine($"\nTotal Expense: ${manager.GetTotalExpense()}");
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using Expense Tracker!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select between 1 and 4.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter valid numbers and dates.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Validation Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
    }
}
