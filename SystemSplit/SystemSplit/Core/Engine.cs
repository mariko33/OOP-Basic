using System;
using System.Runtime.InteropServices;

public class Engine
{
    private Manager manager;

    public Engine()
    {
        this.manager=new Manager();
    }

    public void Run()
    {
        string input;
        while ((input=Console.ReadLine())!= "System Split")
        {
            var args= input.Split(new[] { "(", ")", ", " }, StringSplitOptions.RemoveEmptyEntries);
            string command = args[0];
            
            switch (command)
            {//RegisterPowerHardware(name, capacity, memory)
                case "RegisterPowerHardware":
                    this.manager.RegisterPowerHardware(args[1],int.Parse(args[2]),int.Parse(args[3]));
                    break;
                case "RegisterHeavyHardware":
                    this.manager.RegisterHeavyHardware( args[1], int.Parse(args[2]), int.Parse(args[3]));
                    break;
                //RegisterExpressSoftware(hardwareComponentName, name, capacity, memory)
                //string name, string type, int capacityConsumption, int memoryConsumption
                case "RegisterExpressSoftware":
                    this.manager.RegisterExpressSoftware(args[1], args[2], int.Parse(args[3]), int.Parse(args[4]));
                    break;
                case "RegisterLightSoftware":
                    this.manager.RegisterLightSoftware(args[1],args[2], int.Parse(args[3]),int.Parse(args[4]));
                    break;
                //ReleaseSoftwareComponent(hardwareComponentName, softwareComponentName)
                case "ReleaseSoftwareComponent":
                    this.manager.ReleaseSoftwareComponent(args[1],args[2]);
                    break;
                case "Analyze":
                    Console.WriteLine(this.manager.Analyze());
                    
                    break;
            }

        }
        Console.WriteLine(this.manager.SystemSplit());
    }

}
