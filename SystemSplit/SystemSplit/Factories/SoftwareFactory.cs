using System;
using System.Linq.Expressions;

public class SoftwareFactory
{
    public static Software GetSoftware(string command, string name, int capacity, int memory)
    {
        string type = String.Empty;
        switch (command)
        {
            case "RegisterExpressSoftware":
                type = "Express";
                return new ExpressSoftware(name,type,capacity,memory);
                break;
            case "RegisterLightSoftware":
                type = "Light";
                return new LightSoftware(name,type,capacity,memory);
                break;
                default:throw new ArgumentException("Invalid command");


        }
    }
}
