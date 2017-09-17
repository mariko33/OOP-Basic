using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager
{
    private List<Hardware> hardwares;
    private List<Software> softwares;

    public Manager()
    {
        this.hardwares=new List<Hardware>();
        this.softwares=new List<Software>();
    }


    public void RegisterHardware(string command, string name, int capacity, int memory)
    {
        var hardware = HardwareFactory.GetHardware(command, name, capacity, memory);
        this.hardwares.Add(hardware);
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        string command = System.Reflection.MethodBase.GetCurrentMethod().Name;
        RegisterHardware(command,name,capacity,memory);
    }

    

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        string command = System.Reflection.MethodBase.GetCurrentMethod().Name;
        RegisterHardware(command,name,capacity,memory);
        
    }

    public bool IsExistHardwareComponent(string hardwareComponentName)
    {
        return this.hardwares.Any(h => h.Name == hardwareComponentName);
    }
    
    
    public void RegisterSoftware(string command,string hardwareComponentName, string name, int capacity, int memory)
    {
        if (IsExistHardwareComponent(hardwareComponentName))
        {
            var hardware = this.hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);
            if (hardware.IsEnoughCapacity(capacity)&&hardware.IsEnoughMemory(memory))
            {

                var software = SoftwareFactory.GetSoftware(command, name, capacity, memory);
                hardware.AddSoftware(software);
                this.softwares.Add(software);
            }
        }
    }

    public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        string command = System.Reflection.MethodBase.GetCurrentMethod().Name;
        RegisterSoftware(command, hardwareComponentName, name, capacity, memory);
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        string command= System.Reflection.MethodBase.GetCurrentMethod().Name;
        RegisterSoftware(command,hardwareComponentName,name,capacity,memory);

    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        if (this.IsExistHardwareComponent(hardwareComponentName))
        {
            var hardware = this.hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);
            if (hardware.IsExistSoftwareComponent(softwareComponentName))
            {
                hardware.RemoveSoftware(softwareComponentName);
            }

        }
    }

    public string Analyze()
    {
        //“System Analysis
        //Hardware Components: { countOfHardwareComponents}
        //Software Components: { countOfSoftwareComponents}
        //Total Operational Memory: { totalOperationalMemoryInUse} / { maximumMemory}
        //Total Capacity Taken: { totalCapacityTaken} / { maximumCapacity}”
        int countOfHardwareComponents = this.hardwares.Count;
        int countOfSoftwareComponents = this.softwares.Count;
        int totalOperationalMemoryInUse = this.softwares.Sum(s => s.MemoryConsumption);
        int maximumMemory = this.hardwares.Sum(h => h.MaximumMemory);
        int totalCapacityTaken = this.softwares.Sum(s => s.CapacityConsumption);
        int maximumCapacity = this.hardwares.Sum(h => h.MaximumCapacity);

        StringBuilder sb=new StringBuilder();
        sb.AppendLine("System Analysis");
        sb.AppendLine($"Hardware Components: {countOfHardwareComponents}");
        sb.AppendLine($"Software Components: {countOfSoftwareComponents}");
        sb.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");
        sb.AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

        return sb.ToString();
    }


    public string SystemSplit()
    {
        StringBuilder sb=new StringBuilder();
        //var powerHardwares = this.hardwares.Select(h => h.Type == "Power").ToList();
        //foreach (var hardware in powerHardwares)
        //{
        //    sb.AppendLine(hardware.ToString());
        //}
        //var heavyHardwares= this.hardwares.Select(h => h.Type == "Heavy").ToList();
        //foreach (var hardware in heavyHardwares)
        //{
        //    sb.AppendLine(hardware.ToString());
        //}
        foreach (var hardware in this.hardwares)
        {
            sb.AppendLine(hardware.ToString());
        }
        return sb.ToString();
    }
}
