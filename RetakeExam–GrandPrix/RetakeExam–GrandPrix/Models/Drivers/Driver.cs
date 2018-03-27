public abstract class Driver
{
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
        
    }
    
    public string Name { get; private set; }
    public double TotalTime { get; set; }
    public Car Car { get; private set; }
    public double FuelConsumptionPerKm { get; protected set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void IncreaceTotalTime(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void ReduceFuelAmount(int trackLength)
    {
        this.Car.FuelAmount -= (trackLength * this.FuelConsumptionPerKm);
    }

   
}
