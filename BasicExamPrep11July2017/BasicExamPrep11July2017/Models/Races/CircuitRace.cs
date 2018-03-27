using System.Collections.Generic;
using System.Linq;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
        this.LengthLaps = length;
        this.Length = length * laps;
    }

    public int Laps { get; private set; }
    public int LengthLaps { get; private set; }

    public void DecreaseDurability()
    {
        int decreaseDurability = this.Laps * this.LengthLaps * this.LengthLaps;
        foreach (var participant in this.Participants)
        {
            participant.Durability -= decreaseDurability;
        }
    }

    public override Dictionary<Car, int> GetPerformancePointsCars()
    {
        DecreaseDurability();

        Dictionary<Car, int> winnersList = new Dictionary<Car, int>();

        List<Car> carsList = this.Participants.OrderByDescending(c => c.OverallPerformance()).ToList();
        foreach (var car in carsList)
        {
            winnersList.Add(car, car.OverallPerformance());
        }

        return winnersList;
    }
}
