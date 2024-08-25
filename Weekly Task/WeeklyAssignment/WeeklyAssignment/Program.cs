using System;
using WeeklyAssignment;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the details");
        Console.Write("Enter the type of Employee (Permanent/Temporary): ");
        string type = Console.ReadLine();

        Console.Write("Employee Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Employee Name: ");
        string name = Console.ReadLine();

        if (type.ToLower() == "permanent")
        {
            Console.Write("Basic Salary: ");
            float basicSalary = float.Parse(Console.ReadLine());

            Console.Write("PF: ");
            int pf = int.Parse(Console.ReadLine());

            PermanentEmployee emp = new PermanentEmployee
            {
                Id = id,
                Name = name,
                BasicSalary = basicSalary,
                Pf = pf
            };

            emp.CalculateSalary(emp.Id, emp.Name, emp.BasicSalary);
            emp.DisplayDetails(); 
        }
        else if (type.ToLower() == "temporary")
        {
            Console.Write("Daily Wages: ");
            int dailyWages = int.Parse(Console.ReadLine());

            Console.Write("No.of days worked: ");
            int noOfDays = int.Parse(Console.ReadLine());

          
            TemporaryEmployee emp = new TemporaryEmployee
            {
                Id = id,
                Name = name,
                DailyWages = dailyWages,
                NoOfDays = noOfDays
            };

            emp.CalculateSalary(emp.Id, emp.Name, 0);
            emp.DisplayDetails(); 
        }
        else
        {
            Console.WriteLine("Invalid Employee Type!");
        }
    }

}
