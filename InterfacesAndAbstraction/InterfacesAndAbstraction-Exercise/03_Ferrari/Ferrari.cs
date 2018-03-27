 public class Ferrari:ICar
    {
        public Ferrari(string driversName)
        {
            this.DriversName = driversName;
            this.CarModel = "488-Spider";
        }
        
        public string DriversName { get;private set; }
        public string CarModel { get; private set; }
        
        public string UseBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.CarModel}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.DriversName}";
        }
    }
