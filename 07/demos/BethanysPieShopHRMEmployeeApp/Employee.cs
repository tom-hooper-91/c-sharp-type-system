using System;

namespace BethanysPieShopHRMEmployeeApp
{
    public class Employee
    {
        private string firstName;
        private string lastName;

        private int numberOfHoursWorked;
        private double wage;
        private double hourlyRate;
        private double bonus;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }

        public double HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                hourlyRate = value;
            }
        }

        public int NumberOfHoursWorked
        {
            get { return numberOfHoursWorked; }
            set
            {
                numberOfHoursWorked = value;
            }
        }

        public double Wage
        {
            get { return wage; }
            set
            {
                wage = value;
            }
        }

        public double Bonus
        {
            get { return bonus; }
            set
            {
                bonus = value;
            }
        }

        public Employee(string first, string last, double rate)
        {
            FirstName = first;
            LastName = last;
            HourlyRate = rate;
        }

        public int PerformWork(int hours)
        {
            NumberOfHoursWorked += hours;
            return NumberOfHoursWorked;
        }

        public double ReceiveWage(out int hoursWorked, out double currentBonus)
        {
            Wage = NumberOfHoursWorked * HourlyRate + Bonus;
            
            Console.WriteLine($"The wage for {NumberOfHoursWorked} hours of work is {Wage}. Including a bonus of {bonus}");

            NumberOfHoursWorked = 0;
            Bonus = 0;
            hoursWorked = NumberOfHoursWorked;
            currentBonus = Bonus;

            return Wage;
        }
    }
}
