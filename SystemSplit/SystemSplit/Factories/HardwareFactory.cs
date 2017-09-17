using System;

public class HardwareFactory
{
    public static Hardware  GetHardware(string command, string name, int capacity, int memory)
    {
        string type=String.Empty;
        switch (command)
        {
            case "RegisterPowerHardware":
                 type = "Power";
                return new PowerHardware(name, type,capacity, memory );
                break;
            case "RegisterHeavyHardware":
                 type = "Heavy";
                return new HeavyHardware(name, type,capacity,memory);
                break;
                default:throw new ArgumentException();
        }
    }
}
