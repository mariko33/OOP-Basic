
using System;
using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre GetTyre(List<string> arguments)
    {
        string type = arguments[0];
        double hardness = double.Parse(arguments[1]);
        switch (type)
        {
            case "Hard": return new HardTyre(hardness);
            case "Ultrasoft": return new UltrasoftTyre(hardness, double.Parse(arguments[2]));
            default: throw new ArgumentException();
        }
    }
}
