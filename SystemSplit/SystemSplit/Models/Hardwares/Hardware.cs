using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Hardware
{
    private string name;
    private string type;
    private int maximumCapacity;
    private int maximumMemory;
    private List<Software> softwares;

    protected Hardware(string name, string type, int maximumCapacity,int maximumMemory)
    {
        this.name = name;
        this.type = type;
        this.maximumCapacity = maximumCapacity;
        this.maximumMemory = maximumMemory;
        this.softwares=new List<Software>();
    }

    public string Name { get { return this.name; } set { this.name = value; } }

    public string Type { get { return this.type; } set { this.type = value; } }
    
    public int MaximumCapacity {
        get { return this.maximumCapacity; }
        set { this.maximumCapacity = value; }
        
    }

    public int MaximumMemory { get { return this.maximumMemory; } set { this.maximumMemory = value; } }

    public void AddSoftware(Software software)
    {
        this.softwares.Add(software);
    }


    public bool IsEnoughCapacity(int newCapacity)
    {
        return this.maximumCapacity >= (this.softwares.Sum(s => s.CapacityConsumption)+newCapacity);
    }

    public bool IsEnoughMemory(int newMemory)
    {
        return this.MaximumMemory >= (this.softwares.Sum(s => s.MemoryConsumption)+newMemory);
    }

    public bool IsExistSoftwareComponent(string softwareName)
    {
        return this.softwares.Any(s => s.Name == softwareName);
    }

    public void RemoveSoftware(string softwareName)
    {
        var software = this.softwares.FirstOrDefault(s => s.Name == softwareName);
        this.softwares.Remove(software);
    }

    public override string ToString()
    {
        //Hardware Component – { componentName}
        //Express Software Components: { countOfExpressSoftwareComponents}
        //Light Software Components: { countOfLightSoftwareComponents}
        //Memory Usage: { memoryUsed} / { maximumMemory}
        //Capacity Usage: { capacityUsed} / { maximumCapacity}
        //Type: { Power / Heavy}
        //Software Components: { softwareComponent1, softwareComponent2…}”
        
        StringBuilder sb=new StringBuilder();
        sb.AppendLine($"Hardware Component – {this.name}");
        sb.AppendLine($"Express Software Components: {this.softwares.Where(s=>s.Type=="Express").Select(s=>s.Type).ToList().Count}");
        sb.AppendLine($"Light Software Components: {this.softwares.Where(s => s.Type == "Light").Select(s => s.Type).ToList().Count}");
        sb.AppendLine($"Memory Usage: {this.softwares.Sum(s=>s.MemoryConsumption)} / {this.maximumMemory}");
        sb.AppendLine($"Capacity Usage: {this.softwares.Sum(s => s.CapacityConsumption)} / {this.maximumCapacity}");
        sb.AppendLine($"Type: {this.type}");
        if (this.softwares.Count==0)
        {
            sb.AppendLine("Software Components: None");
        }
        sb.AppendLine($"Software Components: {string.Join(", ", this.softwares.Select(s => s.Name))}");
        
        return sb.ToString();
    }
}
