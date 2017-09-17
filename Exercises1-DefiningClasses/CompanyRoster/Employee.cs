using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
   public class Employee
   {
       private string name;
       private double salary;
       private string position;
       private string department;
       private string email= "n/a";
       private int age=-1;

       public Employee(string name, double salary, string position, string department)
       {
           this.Name = name;
           this.Salary = salary;
           this.Position = position;
           this.Department = department;
       }

       public Employee(string name, double salary, string position, string department, string email)
           : this(name, salary, position, department)
       {
           this.email = email;
       }

       public Employee(string name, double salary, string position, string department, string email,int age)
            :this(name, salary, position, department,email)
       {
           this.age = age;
       }

       public string Name
        {
            get { return this.name; }
           set
           {
               if (value == null)
               {
                   throw new ArgumentException("The name can not be null");
               }
               this.name = value;
           }
        }
       public double Salary
        {
           get { return this.salary; }
           set
           {
               if (value == 0)
               {
                   throw new ArgumentException("The salary can not be null");
               }
               this.salary = value;
           } }
       public string Position
        {
            get { return this.position; }
           set
           {
               if (value == null)
               {
                   throw new ArgumentException("The position can not be null");
                   this.position = value;
               }
           } }
       public string Department
        {
            get { return this.department; }
           set
           {
               if (value == null)
               {
                   throw new ArgumentException("The department can not be null");
               }
               this.department = value;
           } }
       public string Email
        {
            get { return this.email; }
           set { this.email = value; }
        }
       public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

       public override string ToString()
       {
           return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
       }
   }
}
