
    public class Bus:Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public void IncreaseConsumption()
        {
            this.LitersPerKm += 1.4;
        }
        
        
    }
