
using System.Text;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.IsInRace = false;
        this.IsParked = false;
    }

    public bool IsInRace { get; set; }
    public bool IsParked { get; set; }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int YearOfProduction { get; private set; }
    public int Horsepower { get; protected set; }
    public int Acceleration { get; private set; }
    public int Suspension { get; protected set; }
    public int Durability { get; set; }

    public int OverallPerformance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int EnginePerformance()
    {
        return (this.Horsepower / this.Acceleration);
    }

    public int SuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public int TimePerformance()
    {
        return (this.Horsepower / 100) * this.Acceleration;
    }


    public abstract void TuneCar(int tuneIndex, string addOn);
    

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        return sb.ToString();
    }
}
