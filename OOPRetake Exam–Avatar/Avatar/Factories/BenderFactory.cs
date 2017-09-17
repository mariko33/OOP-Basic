using System.Collections.Generic;

public class BenderFactory
{
	public static Bender GetBender(List<string>args)
	{
		string benderType = args[0];
		switch (benderType)
		{
			case "Air":
				return new AirBender(args[1],int.Parse(args[2]),double.Parse(args[3]));
				break;
			case "Water":
				return new WaterBender(args[1], int.Parse(args[2]), double.Parse(args[3]));
				break;
			case "Fire":
				return new FireBender(args[1], int.Parse(args[2]), double.Parse(args[3]));
				break;
			case "Earth":
				return new EarthBender(args[1], int.Parse(args[2]), double.Parse(args[3]));
				break;
			default: return null;
				break;
		}
	}
}
