using System;
using System.Text;

public abstract class Provider:Machine
{
    
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        
        this.EnergyOutput = energyOutput;
    }

    

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }


    public override string ToString()
    {
        int index = this.GetType().Name.IndexOf("Provider");
        string providerType = this.GetType().Name.Substring(0, index);
        StringBuilder sb = new StringBuilder();
        sb.Append($"{providerType} Provider - {this.Id}\r\n");
        sb.Append($"Energy Output: {this.EnergyOutput}");
        return sb.ToString();
    }
}
