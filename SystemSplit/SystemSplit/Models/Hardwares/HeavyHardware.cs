public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, string type, int maximumCapacity, int maximumMemory) : base(name, type, maximumCapacity, maximumMemory)
    {
        this.MaximumMemory = this.MaximumMemory - this.MaximumMemory * 25 / 100;
        this.MaximumCapacity = this.MaximumCapacity * 2;
    }
}
