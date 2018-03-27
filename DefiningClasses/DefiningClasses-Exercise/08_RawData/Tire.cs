
public class Tire
{
    private int age;
    private double pressure;

    public Tire(double pressure, int age)
    {
        this.age = age;
        this.pressure = pressure;
    }
    public int Age { get=>this.age; private set=>this.age=value; }
    public double Pressure { get=>this.pressure; private set=>this.pressure=value; }
    
}
