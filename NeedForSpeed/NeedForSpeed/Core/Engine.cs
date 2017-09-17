using System;

public class Engine
{
    private CarManager manager;
    

    public Engine()
    {
        this.manager = new CarManager();
        
    }

    public void Run()
    {
        string input;
        
        while ((input=Console.ReadLine())!= "Cops Are Here")
        {
           // input = Console.ReadLine();
            var inputArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int id;
            string type;
            switch (inputArgs[0])
            {
                case "register":
                    //register {id} {type} {brand} {model} {year} {horsepower} {acceleration} {suspension} {durability}
                    //int id, string type, string brand, string model, int yearOfProduction, int horsepower,
                    //int acceleration, int suspension, int durability
                    id = int.Parse(inputArgs[1]);
                    type = inputArgs[2];
                    string brand = inputArgs[3];
                    string model = inputArgs[4];
                    int year = int.Parse(inputArgs[5]);
                    int horsepower = int.Parse(inputArgs[6]);
                    int acceleration = int.Parse(inputArgs[7]);
                    int suspension = int.Parse(inputArgs[8]);
                    int durability = int.Parse(inputArgs[9]);
                    this.manager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    id = int.Parse(inputArgs[1]);
                    Console.WriteLine(this.manager.Check(id));
                    break;
                case "open":
                    id = int.Parse(inputArgs[1]);
                    type = inputArgs[2];
                    int length = int.Parse(inputArgs[3]);
                    string route = inputArgs[4];
                    int prizePool = int.Parse(inputArgs[5]);
                    this.manager.Open(id, type, length, route, prizePool);
                    break;
                case "participate":
                    int carId = int.Parse(inputArgs[1]);
                    int raceId = int.Parse(inputArgs[2]);
                    this.manager.Participate(carId,raceId);
                    break;
                case "start":
                    raceId = int.Parse(inputArgs[1]);
                    Console.WriteLine(this.manager.Start(raceId));
                    
                    break;
                case "park":
                    carId = int.Parse(inputArgs[1]);
                    this.manager.Park(carId);
                    break;
                case "unpark":
                    carId = int.Parse(inputArgs[1]);
                    this.manager.Unpark(carId);
                    break;
                case "tune":
                    int tuneInsex = int.Parse(inputArgs[1]);
                    string tuneAddOn = inputArgs[2];
                    this.manager.Tune(tuneInsex,tuneAddOn);
                    break;
                
            }
        }
    }

}
