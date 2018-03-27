
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool,int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }

    public override Dictionary<Car, int> GetPerformancePointsCars()
    {
        Dictionary<Car, int> winnersList = new Dictionary<Car, int>();

        List<Car> carsList = this.Participants.ToList();
        foreach (var car in carsList)
        {
            winnersList.Add(car, car.TimePerformance() * this.Length);
        }

        return winnersList;
    }

    private int TimePerformance()
    {
        return this.Participants[0].TimePerformance() * this.Length;
    }

    private Dictionary<string, int> GetWonPrize()
    {
        Dictionary<string, int> prize = new Dictionary<string, int>();
        int wonPrize = 0;
        if (this.TimePerformance() <= this.GoldTime) prize.Add("Gold", this.PrizePool);
        else if (this.TimePerformance() <= this.GoldTime + 15) prize.Add("Silver", this.PrizePool * 50 / 100);
        else if (this.TimePerformance() > this.GoldTime + 15) prize.Add("Bronze", this.PrizePool * 30 / 100);

        return prize;
    }

    public override string ToString()
    {
        
        StringBuilder sb=new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}")
            .AppendLine(
                $"{this.Participants[0].Brand} {this.Participants[0].Model} - {this.TimePerformance()} s.")
            .Append($"{this.GetWonPrize().First().Key} Time, ${this.GetWonPrize().First().Value}.");

               
        return sb.ToString();
    }
}
