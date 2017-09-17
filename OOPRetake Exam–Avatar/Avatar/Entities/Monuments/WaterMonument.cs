public class WaterMonument : Monument
{
	private int waterAffinity;
	public WaterMonument(string name, int waterAffinity) : base(name)
	{
		this.waterAffinity = this.waterAffinity;
	}

	//public int WaterAffinity { get { return this.waterAffinity; } }

	public override int Bonus()
	{
		return this.waterAffinity;
	}
}
