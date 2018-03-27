using System;
using System.Collections.Generic;

public class FactoryBender
{
    public static Bender GetBender(List<string> args)
    {
        string type = args[0];
        string name = args[1];
        int power = int.Parse(args[2]);
        double secondaryParameter = double.Parse(args[3]);
        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParameter);
                break;
            case "Water":
                return new WaterBender(name, power, secondaryParameter);
                break;
            case "Fire":
                return new FireBender(name, power, secondaryParameter);
                break;
            case "Earth":
                return new EarthBender(name, power, secondaryParameter);
                break;
            default: throw new ArgumentException();
        }
    }
}
