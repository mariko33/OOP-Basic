using System.Collections.Generic;
using System.Linq;

public class Departement
{
    private string name;
    private List<Employee> employees;

    public Departement(string name)
    {
        this.name = name;
        this.employees = new List<Employee>();
    }

    public List<Employee> Employees=>this.employees;
    public string Name { get=>this.name; set=>this.name=value; }
    public void AddEmployees(Employee emploee) => this.employees.Add(emploee);

    public decimal AverageSalary()
    {
        return this.employees.Average(e => e.Salary);
    }
}