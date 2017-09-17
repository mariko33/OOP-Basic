using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private string nationType;
    private List<Bender> benders;
    private List<Monument> monuments;
   

    public Nation(string nationType)
    {
        this.nationType = nationType;
        this.benders=new List<Bender>();
        this.monuments=new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonuments(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public double NationTotalPower()
    {
        return this.benders.Sum(b => b.TotalPower());
    }

    public double TotalPowerWithBonus()
    {
        int bonus = this.monuments.Sum(m => m.GetAffinity());
        var bonusSum = (this.NationTotalPower() / 100) * bonus;
        return this.NationTotalPower() + bonusSum;
    }

    public void DeleteBenders()
    {
        this.benders.Clear();
    }

    public void DeleteMonuments()
    {
        this.monuments.Clear();
    }
    
    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.AppendLine($"{this.nationType} Nation");
        sb.Append("Benders:");
        if (this.benders.Count > 0)
        { 
            sb.AppendLine();
            //foreach (var bender in this.benders)
            //{
            //    sb.AppendLine($"###{bender.ToString()}");
            //}
            sb.AppendLine(string.Join(Environment.NewLine, this.benders.Select(b => $"###{b}")));

        }
        else
        {
            sb.AppendLine(" None");
        }
        
        
        sb.Append("Monuments:");
        
        if (this.monuments.Count>0)
        {
            sb.AppendLine();
            //foreach (var monument in this.monuments)
            //{
            //    sb.Append($"###{monument.ToString()}{Environment.NewLine}");
            //}
            sb.Append(string.Join(Environment.NewLine, this.monuments.Select(m => $"###{m}")));

        }
        else
        {
            sb.Append(" None");
        }
        

        return sb.ToString();
    }
}
