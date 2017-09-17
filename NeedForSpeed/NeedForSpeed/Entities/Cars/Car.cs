using System;
using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsepower = horsepower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
        this.IsInRace = false;
    }

    public bool IsInRace { get; set; }
    public int HoursePower { get { return this.horsepower; }
        protected set { this.horsepower = value; }
        
    }

    public string Brand { get { return this.brand; } protected set { this.brand = value; }}
    public string Model { get { return this.model; } protected set { this.model = value; }}

    public int Suspension { get { return this.suspension; } protected set { this.suspension = value; } }


    public int GetPerformancePoint(string raceType)
    {
        switch (raceType)
        {
            case "Casual":
                return (this.horsepower / this.acceleration) + (this.suspension + this.durability);
                break;
            case "Drag":
                return (this.horsepower / this.acceleration);
                break;
            case "Drift":
                return (this.suspension + this.durability);
                default:throw new ArgumentException();
        }
    }

    public virtual void TuneCar(int tuneIndex, string tuneAddOn)
    {
        this.horsepower += tuneIndex;
        this.suspension += (tuneIndex / 2);
    }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.Append($"{this.brand} {this.model} {this.yearOfProduction}\r\n");
        sb.Append($"{this.horsepower} HP, 100 m/h in {this.acceleration} s\r\n");
        sb.Append($"{this.suspension} Suspension force, {this.durability} Durability\r\n");
        return sb.ToString();
    }
}
