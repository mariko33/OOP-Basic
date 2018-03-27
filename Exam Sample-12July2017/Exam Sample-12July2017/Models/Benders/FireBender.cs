public class FireBender : Bender
{
    private double heatAggression;


    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    public override double TotalPower()
    {
        return base.TotalPower() * this.heatAggression;
    }

    public override string ToString()
    {
        return base.ToString() + $" Heat Aggression: {this.heatAggression:f2}";
    }
}
