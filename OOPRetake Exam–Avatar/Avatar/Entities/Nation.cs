using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
	private List<Bender> benders;
	private List<Monument> monuments;
	private string nationType;

	public Nation(string nationType)
	{
		this.nationType = nationType;
		this.benders=new List<Bender>();
		this.monuments=new List<Monument>();
	}

	public void AddNationBender(Bender bender)
	{
		this.benders.Add(bender);
	}

	public void AddNationMonuent(Monument monument)
	{
		this.monuments.Add(monument);
	}

	public double GetNationTotalPower()
	{
		var totalPower = this.benders.Sum(b => b.GetTotalBenderPower());
		var totalPowerIncrease = totalPower + (totalPower * this.GetNationTotalPowerBonus()) / 100;
		return totalPowerIncrease;
	}

	public int GetNationTotalPowerBonus()
	{
		return this.monuments.Sum(m => m.Bonus());

	}

	public override string ToString()
	{
		StringBuilder sb=new StringBuilder();
		sb.AppendLine($"{this.nationType} Nation");
		sb.AppendLine("Benders:");
		foreach (var bender in this.benders)
		{
			sb.AppendLine(bender.ToString());
		}
		sb.AppendLine(". . .");
		foreach (var monument in this.monuments)
		{
			sb.AppendLine(monument.ToString());
		}
		sb.AppendLine(". . . ");
		return sb.ToString();

	}
}
