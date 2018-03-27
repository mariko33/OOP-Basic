using System;
using System.Collections.Generic;

public class ProviderFactory
{

    public static Provider GetProvider(List<string> arguments)
    {
        switch (arguments[0])
        {
            case "Solar":
                return new SolarProvider(arguments[1], double.Parse(arguments[2]));
                break;
            case "Pressure":
                return new PressureProvider(arguments[1], double.Parse(arguments[2]));
                break;
            default: throw new ArgumentException();

        }
    }
}
