
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        this.cars.Add(id, CarFactory.GetCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
       races.Add(id, RaceFactory.GetRace(type, length, route, prizePool));
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extraParam)
    {
        switch (type)
        {
            case "TimeLimit":
                this.races.Add(id, new TimeLimitRace(length, route,prizePool, extraParam));
                break;
            case "Circuit":
                this.races.Add(id, new CircuitRace(length, route, prizePool, extraParam));
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        Car car = this.cars[carId];
        Race race = this.races[raceId];
        if (race.GetType().Name.Contains("TimeLimit"))
        {
            if (race.Participants.Count == 0 && !car.IsParked && !race.IsClosed)
            {
                car.IsInRace = true;
                this.races[raceId].Participants.Add(car);
            }
        }
        if (!car.IsParked && !races[raceId].IsClosed)
        {
            car.IsInRace = true;
            this.races[raceId].Participants.Add(car);
        }

    }

    public string Start(int id)
    {
        Race race = this.races[id];
        StringBuilder sb = new StringBuilder();

        if (race.Participants.Count == 0) return "Cannot start the race with zero participants.";
        if (race.GetType().Name.Contains("TimeLimit")) return race.ToString();

        int priceFirstPlace = (race.PrizePool * 50) / 100;
        int priceSecondPlace = (race.PrizePool * 30) / 100;
        int priceThirdPlace = (race.PrizePool * 20) / 100;
        int priceForthPlace = race.PrizePool * 10 / 100;
        List<int> prices = new List<int>()
            {
                priceFirstPlace,
                priceSecondPlace,
                priceThirdPlace,
                priceForthPlace
            };

        Dictionary<Car, int> participants = race.GetPerformancePointsCars();
        sb.AppendLine($"{race.Route} - {race.Length}");

        int count = 0;
        var winners = participants.Take(3);
        if (race.GetType().Name.Contains("Circuit"))
        {
            winners = participants.Take(4);
            prices[0] = race.PrizePool * 40 / 100;

        }
        
       // var winners = participants.Take(3);
        foreach (var winer in winners)
        {
            sb.AppendLine($"{count + 1}. {winer.Key.Brand} {winer.Key.Model} {winer.Value}PP - ${prices[count]}");
            count++;
        }

        race.IsClosed = true;
        race.Participants.ForEach(p => p.IsInRace = false);
        this.races.Remove(id);

        return sb.ToString().Trim();


    }

    public void Park(int id)
    {
        Car car = this.cars[id];
        foreach (var race in races)
        {
            if (race.Value.Participants.Contains(car))
            {
                return;
            }
            
        }

        this.garage.ParkedCars.Add(car);
        car.IsParked = true;
        
  
    }

    public void Unpark(int id)
    {
        Car car = this.cars[id];
        if (car.IsParked)
        {
            this.garage.ParkedCars.Remove(car);
            car.IsParked = false;
        }
        
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (this.garage.ParkedCars.Count > 0) this.garage.ParkedCars.ForEach(c => c.TuneCar(tuneIndex, addOn));

    }

    
}
