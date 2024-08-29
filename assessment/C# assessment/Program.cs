using Assesment;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Insurance Number: ");
        string insuranceNo = Console.ReadLine();

        Console.WriteLine("Insurance Name: ");
        string insuranceName = Console.ReadLine();

        Console.WriteLine("Amount Covered: ");
        double amountCovered = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Select\n1.Life Insurance\n2.Motor Insurance");
        int option = Convert.ToInt32(Console.ReadLine());

        Program ps = new Program();
        Insurance insurance = null;

        if (option == 1)
        {
            LifeInsurance lifeInsurance = new LifeInsurance();
            lifeInsurance.InsuranceNo = insuranceNo;
            lifeInsurance.InsuranceName = insuranceName;
            lifeInsurance.AmountCovered = amountCovered;

            Console.WriteLine("Policy Term: ");
            lifeInsurance.PolicyTerm = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Benefit Percent: ");
            lifeInsurance.BenefitPercent = float.Parse(Console.ReadLine());

            insurance = lifeInsurance;
        }
        else if (option == 2)
        {
            MotorInsurance motorInsurance = new MotorInsurance();
            motorInsurance.InsuranceNo = insuranceNo;
            motorInsurance.InsuranceName = insuranceName;
            motorInsurance.AmountCovered = amountCovered;

            Console.WriteLine("Depreciation Percent: ");
            motorInsurance.DepPercent = float.Parse(Console.ReadLine());
                
            insurance = motorInsurance;
        }

        double calculatedPremium = ps.AddPolicy(insurance, option);
        Console.WriteLine("Calculated Premium: " + calculatedPremium);
    }

    public  double AddPolicy(Insurance ins, int opt)
    {
        if (opt == 1)
        {
            LifeInsurance lifeInsurance = new LifeInsurance();
            lifeInsurance = (LifeInsurance)ins;
            return lifeInsurance.calculatePremium();
        }
        else if (opt == 2)
        {
            MotorInsurance motorInsurance = new MotorInsurance();
            motorInsurance=(MotorInsurance)ins;
            return motorInsurance.calculatePremium();
        }

        return 0;
    }
}
