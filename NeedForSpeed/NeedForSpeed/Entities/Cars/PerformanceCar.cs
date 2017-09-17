using System.Collections.Generic;
using System.Linq;

public class PerformanceCar:Car
{
    private List<string> addOns;
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.HoursePower =this.HoursePower+ this.HoursePower * 50 / 100;
        this.Suspension = this.Suspension-this.Suspension * 25 / 100;
        this.addOns=new List<string>();
    }
    
    public override void TuneCar(int tuneIndex, string tuneAddOn)
    {
        base.TuneCar(tuneIndex, tuneAddOn);
        this.addOns.Add(tuneAddOn);
    }

    public override string ToString()
    {
        if (this.addOns.Any())
        {
            return base.ToString() + $"Add-ons: {string.Join(", ", this.addOns)}";
        }
        else
        {
            return base.ToString() + "Add-ons: None";
        }
    }
}
