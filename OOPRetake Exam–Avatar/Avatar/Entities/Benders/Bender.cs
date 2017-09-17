public abstract class Bender
{
	private string name;
	private int power;

	public Bender(string name, int power)
	{
		this.name = name;
		this.power = power;
	}

	protected int Power { get; private set; }

	public abstract double GetTotalBenderPower();

}
