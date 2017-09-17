using System.Collections.Generic;

public class NationsBuilder
{
	private List<Bender> benders;
	private List<Monument> monuments;

	public NationsBuilder()
	{
		this.benders=new List<Bender>();
		this.monuments=new List<Monument>();
		
	}

	public void AssignBender(List<string> benderArgs)
	{
		var bender=BenderFactory.GetBender(benderArgs);
		benders.Add(bender);
	}
	public void AssignMonument(List<string> monumentArgs)
	{
		var monument = MonumentFactory.GetMonument(monumentArgs);
		monuments.Add(monument);

	}
	public string GetStatus(string nationsType)
	{
		return "";
	}
	public void IssueWar(string nationsType)
	{
		//TODO: Add some logic here … 
	}
	public string GetWarsRecord()
	{
		return "";
	}


}
