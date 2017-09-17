using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
        this.participants = new List<Car>();
    }

    public void AddParticipants(Car car)
    {
        
            this.participants.Add(car);
        
        
    }

    public int GetPraziByPlace(int place)
    {
        switch (place)
        {
            case 1:
                return this.prizePool * 50 / 100;
                break;
            case 2:
                return this.prizePool * 30 / 100;
                break;
            case 3:
                return this.prizePool * 20 / 100;
                break;
                default:throw new ArgumentException();           
        }       
        
    }

    public string GetRaceType()
    {
        string nameRace = this.GetType().Name;
        int index = nameRace.IndexOf("Race");
        return nameRace.Substring(0, index);
    }

    public List<Car> GetWinners()
    {
        string tapeRace = this.GetRaceType();
        return this.participants.OrderByDescending(p => p.GetPerformancePoint(tapeRace)).Take(3).ToList();
    }

    public List<Car> GetParticipants()
    {
        return this.participants;
    }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.Append($"{this.route} - {this.length}");
        int count = 1;
        foreach (var winer in GetWinners())
        {
            sb.AppendLine();
            sb.Append($"{count}. {winer.Brand} {winer.Model} {winer.GetPerformancePoint(this.GetRaceType())}PP - ${this.GetPraziByPlace(count)}");
            count++;
        }
        return sb.ToString();
    }
}
