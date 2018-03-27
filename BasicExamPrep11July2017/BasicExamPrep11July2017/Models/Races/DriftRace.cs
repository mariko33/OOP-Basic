
using System.Collections.Generic;
using System.Linq;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override Dictionary<Car, int> GetPerformancePointsCars()
    {

        Dictionary<Car, int> winnersList = new Dictionary<Car, int>();

        List<Car> carsList = this.Participants.OrderByDescending(c => c.SuspensionPerformance()).ToList();
        foreach (var car in carsList)
        {
            winnersList.Add(car, car.SuspensionPerformance());
        }

        return winnersList;
    }
}
