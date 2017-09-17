using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
   public class SturtUp
    {
       public static void Main(string[] args)
       {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            int numberOfEmploee = int.Parse(Console.ReadLine());
            List<Employee>employees=new List<Employee>();
           for (int i = 0; i < numberOfEmploee; i++)
           {
               var employeeInfo = Console.ReadLine().Split(' ');
               Employee employee;
               if (employeeInfo.Length==4)
               {
                    employee=new Employee(employeeInfo[0],double.Parse(employeeInfo[1]),employeeInfo[2],employeeInfo[3]);
                    employees.Add(employee);
                }
               else if (employeeInfo.Length==5)
               {
                   int age=0;

                   if (int.TryParse(employeeInfo[4],out age))
                   {
                        employee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2], employeeInfo[3],"n/a", age);
                    }
                   else
                   {
                        employee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2], employeeInfo[3], employeeInfo[4]);
                    }
                   
                   employees.Add(employee);
                }
               else if (employeeInfo.Length==6)
               {
                    employee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2], employeeInfo[3], employeeInfo[4],int.Parse(employeeInfo[5]));
                    employees.Add(employee);
                }
           }

           var group = employees
               .GroupBy(em => em.Department)
               .Select(gr => new
               {
                   Name = gr.Key,
                   AvarageSalary = gr.Average(em => em.Salary),
                   Employees = gr
               })
               .OrderByDescending(gr => gr.AvarageSalary);

           Console.WriteLine($"Highest Average Salary: {group.First().Name}");
           foreach (var employee in group.First().Employees.OrderByDescending(e=>e.Salary))
           {
               Console.WriteLine(employee.ToString());
           }

       }
    }
}
