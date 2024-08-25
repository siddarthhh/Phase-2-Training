using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyAssignment
{
    public class PermanentEmployee : Employee
    {
        public int Pf { get; set; }
        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            NetSalary = basicSalary - Pf;
            Bonus = CalculateBonus(BasicSalary, Pf);
            return NetSalary;

        }
        public override float CalculateBonus(float salary, int pf)
        {
            if (pf < 1000)
                return salary * 0.10f;
            else if (pf >= 1000 && pf < 1500)
                return salary * 0.115f;
            else if (pf >= 1500 && pf < 1800)
                return salary * 0.12f;
            else
                return salary * 0.15f;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee Id: {Id}");
            Console.WriteLine($"Employee Name: {Name}");
            Console.WriteLine($"Basic Salary: {BasicSalary}");
            Console.WriteLine($"PF: {Pf}");
            Console.WriteLine($"Bonus: {Bonus}");
            Console.WriteLine($"Net Salary: {NetSalary}");
        }
    }
}
