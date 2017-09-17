using System;
using System.Text;

public abstract class Harvester:Machine
{
    
    private double oreOutput;
    private double energyRequirement;
   

    protected Harvester(string id, double oreOutput, double energyRequirement):base(id)
    {
        
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        

    }

    //public string Id { get { return this.id; } protected set { this.id = value; } }
    
    
    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");

            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }


    public void HalfMode()
    {
        this.EnergyRequirement = EnergyRequirement * 0.6;
        this.OreOutput = OreOutput * 0.5;
    }




    public void EnergyMode()
    {
        this.EnergyRequirement = 0;
        this.OreOutput = 0;

    }


    public override string ToString()
    {
        int index = this.GetType().Name.IndexOf("Harvester");
        string harvesterType = this.GetType().Name.Substring(0, index);

        StringBuilder sb = new StringBuilder();
        sb.Append($"{harvesterType} Harvester - {this.Id}\r\n");
        sb.Append($"Ore Output: {this.OreOutput}\r\n");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString();

    }



}
