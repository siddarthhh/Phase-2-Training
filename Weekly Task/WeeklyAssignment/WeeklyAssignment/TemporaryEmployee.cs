using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyAssignment
{
    public class TemporaryEmployee:Employee
    {
        public int DailyWages;
        public int NoOfDays;

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            NetSalary = DailyWages * NoOfDays;
            Bonus = CalculateBonus(NetSalary, DailyWages);
            return NetSalary;
        }

        public override float CalculateBonus(float netSalary, int dailyWages)
        {
            if (dailyWages < 1000)
                return netSalary * 0.15f;
            else if (dailyWages >= 1000 && dailyWages < 1500)
                return netSalary * 0.12f;
            else if (dailyWages >= 1500 && dailyWages < 1750)
                return netSalary * 0.11f;
            else
                return netSalary * 0.08f;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Employee Id: {Id}");
            Console.WriteLine($"Employee Name: {Name}");
            Console.WriteLine($"Daily Wages: {DailyWages}");
            Console.WriteLine($"No.of days worked: {NoOfDays}");
            Console.WriteLine($"Bonus: {Bonus}");
            Console.WriteLine($"Net Salary: {NetSalary}");
        }
    }
}
