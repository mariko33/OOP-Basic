using System;
using System.Linq;
using System.Xml.Schema;

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
        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var inputArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputArgs[0];
            var arguments = inputArgs.Skip(1).ToList();
            switch (command)
            {
                case "register":
                    {
                        int id = int.Parse(arguments[0]);
                        string type = arguments[1];
                        string brand = arguments[2];
                        string model = arguments[3];
                        int yearOfProduction = int.Parse(arguments[4]);
                        int horsepower = int.Parse(arguments[5]);
                        int acceleration = int.Parse(arguments[6]);
                        int suspension = int.Parse(arguments[7]);
                        int durability = int.Parse(arguments[8]);
                        manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                        break;
                    }
                case "check":
                    {
                        int id = int.Parse(arguments[0]);
                        Console.WriteLine(manager.Check(id));
                        break;
                    }
                case "open":
                    {
                        int id = int.Parse(arguments[0]);
                        string type = arguments[1];
                        int length = int.Parse(arguments[2]);
                        string route = arguments[3];
                        int prizePool = int.Parse(arguments[4]);
                        if (arguments.Count > 4)
                        {
                            int extraParam = int.Parse(arguments[5]);
                            manager.Open(id, type, length, route, prizePool,extraParam);
                        }
                        else
                        {
                            manager.Open(id, type, length, route, prizePool);
                        }

                        break;
                    }
                case "participate":
                    {
                        int cardId = int.Parse(arguments[0]);
                        int raceId = int.Parse(arguments[1]);
                        manager.Participate(cardId, raceId);
                        break;
                    }
                case "start":
                    {
                        Console.WriteLine(manager.Start(int.Parse(arguments[0])));
                        break;
                    }
                case "park":
                    {
                        manager.Park(int.Parse(arguments[0]));
                        break;
                    }
                case "unpark":
                    {
                        manager.Unpark(int.Parse(arguments[0]));
                        break;
                    }
                case "tune":
                    {
                        //int tuneIndex, string addOn
                        int tuneIndx = int.Parse(arguments[0]);
                        string addOn = arguments[1];
                        manager.Tune(tuneIndx, addOn);
                        break;
                    }

            }
        }
    }
}
