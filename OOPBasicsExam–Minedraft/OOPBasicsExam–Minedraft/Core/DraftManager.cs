
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    public DraftManager()
    {
        this.mode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.GetHarvester(arguments);
            this.harvesters.Add(harvester);
            return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
        }
        catch (Exception e)
        {
            return e.Message;

        }

    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.GetProvider(arguments);
            this.providers.Add(provider);
            return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
    public string Day()
    {
        this.totalStoredEnergy += this.providers.Sum(p => p.EnergyOutput);
        double energyProvidedPerDay = this.providers.Sum(p => p.EnergyOutput);
        double energyRequirement = 0;
        double mineOrePerDay = 0;
        switch (this.mode)
        {
            case "Full":
                energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement);
                mineOrePerDay = this.harvesters.Sum(h => h.OreOutput);
                break;
            case "Half":
                energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement) * 0.6;
                mineOrePerDay = this.harvesters.Sum(h => h.OreOutput) * 0.5;
                break;
            case "Energy":
                energyRequirement = 0;
                mineOrePerDay = 0;
                break;
        }

        if (this.totalStoredEnergy >= energyRequirement)
        {
            this.totalStoredEnergy -= energyRequirement;
            this.totalMinedOre += mineOrePerDay;
        }
        else
        {
            mineOrePerDay = 0;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyProvidedPerDay}")
            .Append($"Plumbus Ore Mined: {mineOrePerDay}");

        return sb.ToString();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if (this.harvesters.Any(h=>h.Id==id))
        {
            return this.harvesters.FirstOrDefault(h => h.Id == id).ToString();
        }
        if (this.providers.Any(p => p.Id == id))
        {
            return this.providers.FirstOrDefault(p => p.Id == id).ToString();
        }
        
        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        StringBuilder sb=new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }
}
