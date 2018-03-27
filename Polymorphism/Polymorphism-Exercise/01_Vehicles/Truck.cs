using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }

    public override double LitersPerKm => base.LitersPerKm + 1.6;

    public override void Refueling(double fuel)
    {
        if (fuel <= 0) throw new ArgumentException("Fuel must be a positive number");
        
        if (fuel > (this.TankCapacity - this.FuelQuantity))
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }

        this.FuelQuantity += fuel * 0.95;

    }
}
