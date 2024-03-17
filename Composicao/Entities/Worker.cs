using Composicao.Entities.Enums;
using System.Text;

namespace Composicao.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract> ();

        public Worker(string name, WorkLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int year, int month)
        {
            
            foreach (HourContract item in Contracts)
            {
                if (item.Date.Year == year && item.Date.Month == month)
                {
                    BaseSalary += item.TotalValue();   
                }
            }

            return BaseSalary;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name);
            sb.Append("\nDepartment: " + Department.Name);

            return sb.ToString();
        }
    }
}
