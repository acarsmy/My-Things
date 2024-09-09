using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static List<decimal>incomes = new List<decimal>();
        static List<(decimal amount,string category)> expenses=new List<(decimal ,string )> ();
        static void Main(string[] args)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("                   Welcome to your Bank Account Control App\n Choose what you want to do:");
                Console.WriteLine("1- Add Income\n2- Add Expense\n3- Show Situation");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        AddIncome();
                        break;
                    case "2":
                        AddExpense();
                        break;
                    case "3":
                        Situation();
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }



                Console.ReadLine();
            }
        }
        static void AddIncome()
        {
            Console.Clear ();
            Console.WriteLine("Enter the amount for income");

            string input = Console.ReadLine();
            decimal income;
            if(decimal.TryParse(input, out income))
            {
                incomes.Add(income);
                Console.WriteLine($"{income} has been added as income");
            }
            else
            {
                Console.WriteLine("Invalid money amount!");
            }
            Console.WriteLine("Press any key to return main menu");
            Console.ReadKey();
          
        }
        static void AddExpense()
            {
            Console.Clear ();
                Console.WriteLine("Enter the amount for expense");
                string input = Console.ReadLine();
                decimal expense;
                if (decimal.TryParse(input, out expense))
                {
                    string category = SelectCategory();
                    if (!string.IsNullOrEmpty(category))
                    {
                        expenses.Add((expense,category));
                        Console.WriteLine($"{expense} has been added for {category} category as an expense.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid money amount!");
                }

            Console.WriteLine("Press any key to return main menu");
            Console.ReadKey();
        }

        static void Situation()
        {
            Console.Clear();
            Console.WriteLine("Income and Expense Summary:");

            decimal totalIncome = incomes.Sum();
            decimal totalExpense=expenses.Sum(e=> e.amount);

            Console.WriteLine($"\nTotal Incomes: {totalIncome}");
            Console.WriteLine($"\nTotal Expenses: {totalExpense}");
            decimal balance = totalIncome-totalExpense;
            Console.WriteLine($"Balance: {balance}");

            Dictionary<string, decimal> categoryTotals = new Dictionary<string, decimal>();

            foreach (var expense in expenses)
            {
                if (categoryTotals.ContainsKey(expense.category))
                {
                    categoryTotals[expense.category] += expense.amount;
                }
                else
                {
                    categoryTotals[expense.category] = expense.amount;
                }
            }

            if (expenses != null)
            {
                Console.WriteLine("\nExpenses by Category:");
                foreach (var entry in categoryTotals)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
            else
            {
                Console.WriteLine("");
            }
            

            Console.WriteLine("Press any key to return main menu");
            Console.ReadKey();
        }
        static string SelectCategory()
          { 
            Console.WriteLine("Choose a category for this expense:");
            Console.WriteLine("1- Food\n2- Clothes\n3- Education\n4- Fun\n5- Other");
            string categoryChoise= Console.ReadLine();
            string category = " ";

            switch(categoryChoise)
            {
                case "1": category = "Food";
                    break;
                case "2":
                    category = "Clothes";
                    break;
                case "3":
                    category = "Education";
                    break;
                case "4":
                    category = "Fun";
                    break;
                case "5":
                    category = "Other";
                    break;
                default:
                    Console.WriteLine("Invalid Category!");
                    break;
            }
            return category;

          }
        
    }
}
