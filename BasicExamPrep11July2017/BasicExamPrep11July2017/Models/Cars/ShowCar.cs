
using System;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars { get; private set; }

    public override void TuneCar(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
        this.Stars += tuneIndex;

    }

    public override string ToString()
    {
        return base.ToString() + $"{this.Stars} *";
    }
}
