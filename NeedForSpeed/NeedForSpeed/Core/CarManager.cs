using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int,Car> cars;
    private Dictionary<int,Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars=new Dictionary<int, Car>();
        this.races=new Dictionary<int, Race>();
        this.garage=new Garage();
    }
    
    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    { 
        cars[id]= CarFactory.GetCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    }


    public string Check(int id)
    {
       
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {

        races[id] = RaceFactory.GetRace(type, length, route, prizePool);
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.IsParkedCar(carId))
        {
            races[raceId].AddParticipants(cars[carId]);
            this.cars[carId].IsInRace = true;
            
        }
        
    }

    public string Start(int id)
    {
        string result=String.Empty;
        var race = this.races[id];
        
        if (race.GetParticipants().Count==0)
        {
            result= "Cannot start the race with zero participants.";
        }
        else
        {
            race.GetParticipants().ForEach(c => c.IsInRace = false);
            //Console.WriteLine(race.ToString());
            //return race.ToString();
             this.races.Remove(id);
            result = race.ToString();
        }
        return result;
    }

    public void Park(int id)
    {
        var car = this.cars[id];
        if (!IsRacer(id))
        {
            this.garage.ParkCar(id, car);
        }
    }

    public void Unpark(int id)
    {
        
        if (this.garage.IsParkedCar(id))
        {
            this.garage.UnParkCar(id);
        }
        
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.garage.GetParkedCars().Values)
        {
            car.TuneCar(tuneIndex,addOn);
        }
    }

    private bool IsRacer(int id)
    {
        Car car = this.cars[id];
        return this.races.Values.Any(r => r.GetParticipants().Any(c => c == car));
        
    }

    private bool IsParked(int id)
    {
        return this.garage.IsParked(id);
    }

}
