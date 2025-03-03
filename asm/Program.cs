using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Customer name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Type of customer: ");
            string type = Console.ReadLine();

            Console.WriteLine("Last month's water meter reading: ");
            double lastMonth = double.Parse(Console.ReadLine());

            Console.WriteLine("This month's water meter reading: ");
            double thisMonth = double.Parse(Console.ReadLine());

            double consumption = thisMonth - lastMonth;
            double bill = 0;

            if (type.Equals("household", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Number of people in the family: ");
                double numberOfPeople = double.Parse(Console.ReadLine());
                double consumptionPerPerson = consumption / numberOfPeople;

                if (consumptionPerPerson <= 10)
                {
                    bill = consumption * 5.973;
                }
                else if (consumptionPerPerson <= 20)
                {
                    bill = (10 * numberOfPeople * 5.973) + ((consumption - 10 * numberOfPeople) * 7.052);
                }
                else if (consumptionPerPerson <= 30)
                {
                    bill = (10 * numberOfPeople * 5.973) + (10 * numberOfPeople * 7.052) + ((consumption - 20 * numberOfPeople) * 8.699);
                }
                else
                {
                    bill = (10 * numberOfPeople * 5.973) + (10 * numberOfPeople * 7.052) + (10 * numberOfPeople * 8.699) + ((consumption - 30 * numberOfPeople) * 15.929);
                }
            }
            else if (type.Equals("administrative", StringComparison.OrdinalIgnoreCase) || type.Equals("public services", StringComparison.OrdinalIgnoreCase))
            {
                bill = consumption * 9.955;
            }
            else if (type.Equals("production", StringComparison.OrdinalIgnoreCase))
            {
                bill = consumption * 11.615;
            }
            else if (type.Equals("business", StringComparison.OrdinalIgnoreCase))
            {
                bill = consumption * 22.068;
            }

            double environmentProtectionFee = bill * 0.10;
            double totalBill = bill + environmentProtectionFee;
            double vat = totalBill * 0.10;
            totalBill += vat;

            Console.WriteLine($"Customer name: {name}");
            Console.WriteLine($"Type of customer: {type}");
            Console.WriteLine($"Last month's water meter reading: {lastMonth}");
            Console.WriteLine($"This month's water meter reading: {thisMonth}");
            Console.WriteLine($"Amount of consumption: {consumption} m³");
            Console.WriteLine($"Total water bill: {totalBill} VND");

        }
    }
}
