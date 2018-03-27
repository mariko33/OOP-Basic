
    using System;
    using System.Text;

public class Worker:Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
        
        public Worker(string firstName, string lastName, decimal weekSalary,decimal workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value<10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value<1||value>12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        private decimal CalculateMonyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Week Salary: {this.WeekSalary:f2}")
                .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
                .AppendLine($"Salary per hour: {this.CalculateMonyPerHour():f2}");


            return sb.ToString();
        }
    }
