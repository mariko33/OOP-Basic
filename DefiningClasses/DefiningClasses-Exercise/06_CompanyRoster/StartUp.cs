using System;
using System.Collections.Generic;
using System.Linq;


    public class StartUp
    {
        static void Main()
        {
            List<Departement> departements = new List<Departement>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string departement = input[3];
                if (!departements.Any(d => d.Name == departement))
                {
                    Departement dep = new Departement(departement);
                    departements.Add(dep);
                }
                var currDepartement = departements.FirstOrDefault(d => d.Name == departement);

                int age = -1;

                if (input.Length == 4)
                {
                    Employee employee = new Employee(name, salary, position, currDepartement);
                    currDepartement.AddEmployees(employee);

                }
                if (input.Length==5)
                {
                    bool isNumber=int.TryParse(input[4], out age);
                    if (isNumber)
                    {
                        Employee employee1 = new Employee(name,salary,position,currDepartement,"n/a",age);
                        currDepartement.AddEmployees(employee1);
                    }
                    else
                    {
                        Employee employee2 = new Employee(name, salary, position, currDepartement, input[4], -1);
                        currDepartement.AddEmployees(employee2);
                    }
                    
                        
                    
                }
                if (input.Length == 6)
                {
                    string email = input[4];
                    int age1 = int.Parse(input[5]);
                    Employee employee3 = new Employee(name, salary, position, currDepartement, email, age1);
                    currDepartement.AddEmployees(employee3);

                }
            }

            Departement result = departements.OrderByDescending(d => d.AverageSalary()).First();
            Console.WriteLine($"Highest Average Salary: {result.Name}");
            foreach (var emp in result.Employees.OrderByDescending(e=>e.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
            }
        }
    }

