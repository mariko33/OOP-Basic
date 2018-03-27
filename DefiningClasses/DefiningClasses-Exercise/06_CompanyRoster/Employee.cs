public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private Departement department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, Departement department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string name, decimal salary, string position, Departement department, string email, int age)
    : this(name, salary, position, department)
    {

        this.email = email;
        this.age = age;
    }

    public string Name { get => this.name; private set => this.name = value; }
    public decimal Salary { get => this.salary; private set => this.salary = value; }
    public string Position { get => this.position; private set => this.position = value; }
    public Departement Departement { get => this.department; private set => this.department = value; }
    public string Email { get => this.email; private set => this.email = value; }
    public int Age { get => this.age; private set => this.age = value; }
}
