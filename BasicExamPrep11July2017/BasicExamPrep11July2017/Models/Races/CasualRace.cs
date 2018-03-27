
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

public class CasualRace:Race
    {
        public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
        {
        }


        public override Dictionary<Car, int> GetPerformancePointsCars()
        {
            Dictionary<Car,int>winnersList=new Dictionary<Car, int>();
            
            List<Car>carsList= this.Participants.OrderByDescending(c => c.OverallPerformance()).ToList();
            foreach (var car in carsList)
            {
                winnersList.Add(car, car.OverallPerformance());
            }
            
            return winnersList;
        }

        
    }
