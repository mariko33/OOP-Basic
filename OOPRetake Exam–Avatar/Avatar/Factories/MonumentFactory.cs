using System.Collections.Generic;

public class MonumentFactory
{
	public static Monument GetMonument(List<string>args)
	{
		var monumentType = args[0];
		switch (monumentType)
		{
			case "Air":
				return new AirMonument(args[1], int.Parse(args[2]));
				break;
			case "Water":
				return new WaterMonument(args[1], int.Parse(args[2]));
				break;
			case "Fire":
				return new FireMonument(args[1], int.Parse(args[2]));
				break;
			case "Earth":
				return new EarthMonument(args[1], int.Parse(args[2]));
				break;
			default: return null;
				break;
		}
	}
}
