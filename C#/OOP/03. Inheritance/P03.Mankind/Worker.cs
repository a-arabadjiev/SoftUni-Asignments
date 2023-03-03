using System.Text;

namespace P03.Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            :base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get 
            { 
                return this.weekSalary; 
            }
            set 
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value; 
            }
        }
        public decimal WorkHoursPerDay
        {
            get 
            { 
                return this.workHoursPerDay; 
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        private decimal HourlyIncome()
        {
            decimal hourlyIncome = (this.WeekSalary / this.WorkHoursPerDay) / 5;

            return hourlyIncome;
        }

        public override string ToString()
        {
            var workerInfo = new StringBuilder();

            workerInfo.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            workerInfo.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
            workerInfo.AppendLine($"Salary per hour: {this.HourlyIncome():F2}");

            return base.ToString() + workerInfo.ToString();
        }
    }
}
