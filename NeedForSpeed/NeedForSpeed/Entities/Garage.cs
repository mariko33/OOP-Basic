using System.Collections.Generic;

public class Garage
{
    private Dictionary<int,Car> parkedCars;

    public Garage()
    {
        this.parkedCars=new Dictionary<int, Car>();
    }

    public bool IsParkedCar(int id)
    {
        return this.parkedCars.ContainsKey(id);
    }

    public Dictionary<int, Car> GetParkedCars()
    {
        return this.parkedCars;
    }

    public void ParkCar(int id, Car car)
    {
        if (!this.parkedCars.ContainsKey(id))
        {
            this.parkedCars.Add(id, car);
        }
        
    }
    public bool IsParked(int id)
    {
        return this.parkedCars.ContainsKey(id);
    }

    public void UnParkCar(int id)
    {
        this.parkedCars.Remove(id);
    }
}
