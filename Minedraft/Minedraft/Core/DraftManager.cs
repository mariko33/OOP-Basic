using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
        this.mode = "Full";
    }


    public void ChangeMode(string mode)
    {
        this.mode = mode;
    }

    

    public double TotalStoredEnergy()
    {
        return this.providers.Sum(p => p.EnergyOutput);
    }

    //public double TotalMinedOre()
    //{
    //    return this.harvesters.Sum(h => h.OreOutput);
    //}

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.GetHarvester(arguments);
            this.harvesters.Add(harvester);
        }
        catch (Exception ae)
        {
            return ae.Message;

        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";

    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.GetProvider(arguments);
            this.providers.Add(provider);

        }
        catch (Exception ae)
        {
            return ae.Message;

        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";

    }
    public string Day()
    {
        StringBuilder sb = new StringBuilder();
        var dayEnergyProvided = this.providers.Sum(p => p.EnergyOutput);
        double dayEnergyConsumed = 0;
        double dayOreOutput = 0;
        switch (this.mode)
        { 
            case "Full":
                dayOreOutput = this.harvesters.Sum(h => h.OreOutput);
                dayEnergyConsumed = this.harvesters.Sum(h => h.EnergyRequirement);
                
                
                break;
            case "Half":
                dayOreOutput = this.harvesters.Sum(h => h.OreOutput)*0.5;
                dayEnergyConsumed = this.harvesters.Sum(h => h.EnergyRequirement)*0.6;
                
                break;

            case "Energy":
                break;
                
                default:throw new ArgumentException();
                    
        }
        this.totalEnergyStored += dayEnergyProvided;
        if (dayEnergyConsumed <= this.totalEnergyStored)
        {
            this.totalEnergyStored -= dayEnergyConsumed;
            this.totalMinedOre += dayOreOutput;
        }
        else
        {
            dayOreOutput = 0;
            
        }
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {dayEnergyProvided}");
        sb.Append($"Plumbus Ore Mined: {dayOreOutput}");
        //sb.Append($"Energy Provided: {this.providers.Sum(p=>p.EnergyOutput)}\r\n");

        //var allEnergyRequirement = this.harvesters.Sum(h => h.EnergyRequirement);
        //this.totalEnergyStored += this.TotalStoredEnergy();
        //double minedOre = this.TotalMinedOre();
        //if (allEnergyRequirement > this.totalEnergyStored)
        //{
        //    minedOre = 0;


        //}
        //else
        //{
        //    this.totalEnergyStored -= allEnergyRequirement;
        //}
        //sb.Append($"Plumbus Ore Mined: { minedOre }");
        //this.totalMinedOre += minedOre;
        return sb.ToString();



    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        //switch (mode)
        //{
        //    case "Half":
        //        this.harvesters.ForEach(h => h.HalfMode());
        //        break;
        //    case "Energy":
        //        this.harvesters.ForEach(h => h.EnergyMode());
        //        break;
        //}
        this.mode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }


    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if (this.harvesters.Any(h => h.Id == id))
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
        StringBuilder sb = new StringBuilder();
        sb.Append("System Shutdown\r\n");
        sb.Append($"Total Energy Stored: {this.totalEnergyStored}\r\n");
        sb.Append($"Total Mined Plumbus Ore: { this.totalMinedOre}");

        return sb.ToString();

    }

}
