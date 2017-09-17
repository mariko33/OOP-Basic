public class FireBender:Bender
{
	private double heatAggression;
	public FireBender(string name, int power, double heatAggression) : base(name, power)
	{
		this.heatAggression = heatAggression;
	}

	public override double GetTotalBenderPower()
	{
		return base.Power * this.heatAggression;
	}
}