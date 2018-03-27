
using System.Collections.Generic;
using System.Linq;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override Dictionary<Car, int> GetPerformancePointsCars()
    {
        Dictionary<Car, int> winnersList = new Dictionary<Car, int>();

        List<Car> carsList = this.Participants.OrderByDescending(c => c.EnginePerformance()).ToList();
        foreach (var car in carsList)
        {
            winnersList.Add(car, car.EnginePerformance());
        }

        return winnersList;
    }
}
