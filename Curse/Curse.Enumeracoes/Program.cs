using Curse.Enumeracoes.Entities;
using Curse.Enumeracoes.Entities.Enums;
using System;
using System.Globalization;

namespace Curse.Enumeracoes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter departamen's name : ");
            string depName = Console.ReadLine();
            Console.Write("Enter worker data : ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary : ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dep = new Departament(depName);
            Worker worker = new Worker(name, level, baseSalary, dep);

            Console.Write("How many contracts to this worker? ");
            int totalContracts = int.Parse(Console.ReadLine());

            Console.Write("Enter #1 contract data: ");

            for (int i = 1; i <= totalContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime contractData = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                worker.AddContract(new HourContract(contractData, valuePerHour, hours));
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculte income (MM/YYYY): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(4));

            Console.WriteLine("Name" + worker.Name);
            Console.WriteLine("Department " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthYear + ": "+ worker.Income(year,month));
        }
    }
}
