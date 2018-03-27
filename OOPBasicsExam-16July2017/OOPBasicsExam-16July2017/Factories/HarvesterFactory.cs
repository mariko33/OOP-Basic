
using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester GetHarvester(List<string> arguments)
    {
        switch (arguments[0])
        {
            case "Hammer":
                return new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
                break;
            case "Sonic":
                return new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]),
                    int.Parse(arguments[4]));
                break;
            default:
                throw new ArgumentException();
        }
    }
}