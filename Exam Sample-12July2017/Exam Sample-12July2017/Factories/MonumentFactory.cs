using System;
using System.Collections.Generic;

public class FactoryMonument
{
    public static Monument GetMonument(List<string> args)
    {
        string type = args[0];
        string name = args[1];
        int affinity = int.Parse(args[2]);
        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
                break;
            case "Water":
                return new WaterMonument(name, affinity);
                break;
            case "Fire":
                return new FireMonument(name, affinity);
                break;
            case "Earth":
                return new EarthMonument(name, affinity);
                break;
            default: throw new ArgumentException();

        }
    }

}
