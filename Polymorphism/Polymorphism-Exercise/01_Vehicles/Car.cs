  public class Car:Vehicle
    {
        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm,tankCapacity)
        {
        }

        public override double LitersPerKm => base.LitersPerKm + 0.9;
       

    }
