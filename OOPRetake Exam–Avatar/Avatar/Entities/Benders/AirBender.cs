public class AirBender : Bender
{
	private double aerialIntegrity;
	public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
	{
		this.aerialIntegrity = aerialIntegrity;
	}

	public override double GetTotalBenderPower()
	{
		return (base.Power * this.aerialIntegrity);
	}
}
