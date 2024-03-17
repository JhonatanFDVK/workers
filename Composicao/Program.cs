using Composicao.Entities;
using Composicao.Entities.Enums;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Enter department's name: ");
        string depaetmentName = Console.ReadLine();

        Department department = new Department(depaetmentName);

        Console.WriteLine("Enter worker data: ");
        Console.Write("Name: ");
        string workerName = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkLevel workLevel = Enum.Parse<WorkLevel>(Console.ReadLine());
        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Worker worker = new Worker(workerName, workLevel, baseSalary, department);

        Console.Write("How many contracts to this worker? ");
        int numberContracts = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberContracts; i++)
        {
            Console.WriteLine($"Enter #{i + 1} contract data:");

            Console.Write("Date (DD/MM/YYYY): ");
            DateTime dateP = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int hours = int.Parse(Console.ReadLine());

            HourContract hourContract = new HourContract(dateP, valuePerHour, hours);
            worker.AddContract(hourContract);
        }

        Console.Write("\nEnter month and year to calculate income (YYYY/MM): ");
        
        string date = Console.ReadLine();

        DateTime formattedDate = DateTime.Parse(date);

        Console.WriteLine(worker);
        Console.Write("Income for: " + formattedDate.Month + "/" + formattedDate.Year + ": ");
        Console.Write(worker.Income(formattedDate.Year, formattedDate.Month).ToString("F2", CultureInfo.InvariantCulture));
       
    }
}