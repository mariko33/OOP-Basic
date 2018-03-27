
    using System.Collections.Generic;

public abstract class Race
    {
        protected Race(int length, string route, int prizePool)
        {
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.Participants = new List<Car>();
            this.IsClosed = false;
        }
        
        public int Length { get; protected set; }
        public string Route { get; private set; }
        public int PrizePool { get; private set; }
        public List<Car> Participants { get; private set; }
        public bool IsClosed { get; set; }

       public abstract Dictionary<Car,int> GetPerformancePointsCars();

       



    }
