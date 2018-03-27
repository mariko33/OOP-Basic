
using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    protected Vehicle(double fuelQuantity, double litersPerKm,double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        if (this.FuelQuantity > this.TankCapacity)
            this.fuelQuantity = 0;
        this.LitersPerKm = litersPerKm;
        
    }

    public virtual double FuelQuantity
    {
        get => this.fuelQuantity;
        set
        { 
            this.fuelQuantity = value;
        }
        
    }
    public virtual double LitersPerKm { get; set; }
    public double TankCapacity { get; set; }

    public string Drive(double distance, double increase)
    {

        if (this.FuelQuantity >= distance * (this.LitersPerKm+increase))
        {
            this.FuelQuantity -= distance * (this.LitersPerKm+increase);
            return $"{this.GetType().Name} travelled {distance} km";
        }
        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refueling(double fuel)
    {
        if(fuel<=0)throw new ArgumentException("Fuel must be a positive number");
        
        if (fuel > (this.TankCapacity - this.FuelQuantity))
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }
        
            this.FuelQuantity += fuel;
        
        
    }



    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
