using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

public class NationsBuilder
{
    
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation("Air")},
            {"Water", new Nation("Water")},
            {"Fire", new Nation("Fire")},
            {"Earth", new Nation("Earth")}
        };
        this.wars=new List<string>();
    }
    
    public void AssignBender(List<string> benderArgs)
    {
         var bender = FactoryBender.GetBender(benderArgs);
        this.nations[benderArgs[0]].AddBender(bender);

    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monument = FactoryMonument.GetMonument(monumentArgs);
        this.nations[monumentArgs[0]].AddMonuments(monument);
    }

    public string GetStatus(string nationsType)
    {
        return this.nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);
        var winner = this.nations.Max(n => n.Value.TotalPowerWithBonus());
        foreach (var nation in this.nations)
        {
            if (nation.Value.TotalPowerWithBonus()!=winner)
            {
                nation.Value.DeleteBenders();
                nation.Value.DeleteMonuments();
            }
        }
    }

    public string GetWarsRecord()
    {
        StringBuilder sb=new StringBuilder();
        int count = 1;
        foreach (var war in this.wars)
        {
            sb.AppendLine($"War {count} issued by {war}");
            count++;
        }
        
        return sb.ToString();
    }

}


