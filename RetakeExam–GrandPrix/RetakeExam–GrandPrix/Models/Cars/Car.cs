
using System;

public class Car
{
    private const double TankMaximumCapacity = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }
    public double FuelAmount
    {
        get => this.fuelAmount;
        set
        {
            if (value > TankMaximumCapacity)
            {
                value = TankMaximumCapacity;
            }
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = value;
        }

    }
    public Tyre Tyre { get; private set; }


    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}
