﻿using System;
using System.Collections.Generic;

namespace BethanysPieShopHRMEmployeeApp
{
    class Program
    {
        private static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************");
            Console.WriteLine("* Bethany's Pie Shop Employee App *");
            Console.WriteLine("***********************************");
            Console.ForegroundColor = ConsoleColor.White;

            string userSelection;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1: Register employee");
                Console.WriteLine("2: Register work hours for employee");
                Console.WriteLine("3: Pay employee");
                Console.WriteLine("4: Update employee hourly rate");
                Console.WriteLine("5: Add an employee bonus");
                Console.WriteLine("9: Quit application");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1": RegisterEmployee();
                        break;
                    case "2": RegisterWork();
                        break;
                    case "3": PayEmployee();
                        break;
                    case "4": UpdateHourlyRate();
                        break;
                    case "5": AddBonus();
                        break;
                    case "9": break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "9");

            Console.WriteLine("Thanks for using the application");
            Console.Read();

        }

        private static void AddBonus()
        {
            Console.WriteLine("Select an employee");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {employees[i].FirstName} {employees[i].LastName}");
            }

            int selection = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter bonus amount: ");

            int bonus = int.Parse(Console.ReadLine());

            employees[selection - 1].Bonus = bonus;

            Console.WriteLine("Bonus added!\n\n");
        }

        private static void UpdateHourlyRate()
        {
            Console.WriteLine("Select an employee");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {employees[i].FirstName} {employees[i].LastName}");
            }

            int selection = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new hourly rate");

            int newRate = int.Parse(Console.ReadLine());

            employees[selection - 1].HourlyRate = newRate;

            Console.WriteLine("Rate updated!\n\n");

        }

        private static void RegisterEmployee()
        {
            Console.WriteLine("Creating an employee");
            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the hourly rate: ");
            string hourlyRate = Console.ReadLine();
            double rate = double.Parse(hourlyRate);//we will assume here that input is in the correct format

            Employee employee = new Employee(firstName, lastName, rate);
            employees.Add(employee);
            
            Console.WriteLine("Employee created!\n\n");
        }

        private static void RegisterWork()
        {
            Console.WriteLine("Select an employee");

            for (int i = 1; i <= employees.Count; i++)
            {
                Console.WriteLine($"{i}. {employees[i - 1].FirstName} {employees[i - 1].LastName}");
            }

            int selection = int.Parse(Console.ReadLine());//we will assume here that a valid ID is selected

            Console.Write("Enter the number of hours worked: ");
            int hours = int.Parse(Console.ReadLine());//we will assume here that a valid amount was entered

            Employee selectedEmployee = employees[selection - 1];
            int numberOfHoursWorked = selectedEmployee.PerformWork(hours);
            Console.WriteLine($"{selectedEmployee.FirstName} {selectedEmployee.LastName} has now worked {numberOfHoursWorked} hours in total.\n\n");
        }

        private static void PayEmployee()
        {
            Console.WriteLine("Select an employee");

            for (int i = 1; i <= employees.Count; i++)
            {
                Console.WriteLine($"{i}. {employees[i - 1].FirstName} {employees[i - 1].LastName}");
            }

            int selection = int.Parse(Console.ReadLine());//we will assume here that a valid ID is selected

            Employee selectedEmployee = employees[selection - 1];
            int hoursWorked;
            double currentBonus;
            double receivedWage = selectedEmployee.ReceiveWage(out hoursWorked, out currentBonus);
            
            Console.WriteLine($"{selectedEmployee.FirstName} {selectedEmployee.LastName} has received a wage of {receivedWage}. The hours worked is reset to {hoursWorked} and the bonus is reset to {currentBonus}.\n\n");
        }
    }
}
