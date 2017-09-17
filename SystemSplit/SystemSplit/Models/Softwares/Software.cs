public abstract class Software
{
    private string name;
    private string type;
    private int capacityConsumption;
    private int memoryConsumption;

    protected Software(string name, string type, int capacityConsumption, int memoryConsumption)
    {
        this.name = name;
        this.type = type;
        this.capacityConsumption = capacityConsumption;
        this.memoryConsumption = memoryConsumption;
    }

    public string Name { get { return this.name; } set { this.name = value; } }

    public string Type { get { return this.type; } set { this.type = value; } }
    
    public int CapacityConsumption
    {
        get { return this.capacityConsumption; }
        set { this.capacityConsumption = value; }
    }

    public int MemoryConsumption { get { return this.memoryConsumption; } set { this.memoryConsumption = value; } }

    
}
