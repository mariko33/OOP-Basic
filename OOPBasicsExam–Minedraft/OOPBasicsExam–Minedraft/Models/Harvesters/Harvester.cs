using System;
using System.Text;

public abstract class Harvester
{
    private double oreoOutput;
    private double energyRequirement;
    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id { get; private set; }

    public double OreOutput
    {
        get => this.oreoOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }

            this.oreoOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name.Replace("Harvester", "")} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}
