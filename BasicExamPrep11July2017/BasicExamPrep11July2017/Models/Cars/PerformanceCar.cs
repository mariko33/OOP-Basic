
using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    public PerformanceCar
     (string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
     : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns=new List<string>();
        this.Horsepower = this.Horsepower * 3 / 2; //this.Horsepower + (this.Horsepower * 50) / 100;
        this.Suspension -= this.Suspension * 25 / 100; //this.Suspension - (this.Suspension * 25) / 100;
    }

    public List<string> AddOns { get; private set; }

    public override void TuneCar(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
        this.AddOns.Add(addOn);

    }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        if (this.AddOns.Count == 0) sb.Append($"Add-ons: None");
        else sb.Append($"Add-ons: {string.Join(", ", this.AddOns)}");

        return base.ToString()+sb.ToString();
    }
}
