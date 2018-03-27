
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

public class RaceTower
{
    private int trackLength;
    private int lapsNumber;
    private int currentLap;
    private string weather;
    private Dictionary<string, Driver> drivers;
    private Dictionary<Driver, string> falureDrivers;

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.falureDrivers = new Dictionary<Driver, string>();
        this.currentLap = 0;
        this.weather = "Sunny";
    }

    public int TrackLength { get; private set; }
    public int LapsNumber
    {
        get => this.lapsNumber;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
            }

            this.lapsNumber = value;
        }
    }



    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string type = commandArgs[0];
            string name = commandArgs[1];
            List<string> carList = commandArgs.Skip(2).Take(2).ToList();
            List<string> tyreList = commandArgs.Skip(4).ToList();
            Tyre tyre = TyreFactory.GetTyre(tyreList);
            Car car = CarFactory.GetCar(carList, tyre);
            Driver driver = DriverFactory.GetDriver(type, name, car);
            this.drivers.Add(name, driver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }



    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string resonToBox = commandArgs[0]; //ChangeTyres or Refuel
        string driverName = commandArgs[1];
        Driver driverToBox = this.drivers[driverName];
        driverToBox.TotalTime += 20;
        
        List<string> tyreOrFuelList = commandArgs.Skip(2).ToList();
        if (resonToBox == "Refuel")
        {
            double fuel = double.Parse(commandArgs[2]);
            driverToBox.Car.Refuel(fuel);
        }
        else
        {
            Tyre tyre=TyreFactory.GetTyre(tyreOrFuelList);
            driverToBox.Car.ChangeTyres(tyre);
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);
        StringBuilder result = new StringBuilder();

        try
        {
            this.LapsNumber -= numberOfLaps;
        }
        catch (Exception e)
        {
            return (e.Message);

        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            
            foreach (var driver in this.drivers.Values)
            {
                try

                {
                    driver.IncreaceTotalTime(this.TrackLength);
                    driver.ReduceFuelAmount(this.TrackLength);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (Exception e)
                {
                    this.falureDrivers.Add(driver, e.Message);
                }
            }
            this.currentLap++;

            DeleteFaluerDrivers();
            var driversForOvertaking = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

            CheckForOvertaking(result, this.currentLap, driversForOvertaking);
        }


        return result.ToString().Trim();
    }

    private void CheckForOvertaking(StringBuilder result, int currLap, List<Driver> driversForOvertaking)
    {
        for (int i = 0; i < driversForOvertaking.Count - 1; i++)
        {
            Driver firstDriver = driversForOvertaking[i];
            Driver secondDriver = driversForOvertaking[i + 1];
            int difference = 2;

            double totalDifference = Math.Abs(firstDriver.TotalTime - secondDriver.TotalTime);

            CheckForSpecialConditions(firstDriver, ref difference);

            if (totalDifference <= difference)
            {
                if (IsCrashed(firstDriver))
                {
                    this.falureDrivers.Add(firstDriver, "Crashed");
                    this.drivers.Remove(firstDriver.Name);
                    continue;
                }
                
                firstDriver.TotalTime -= difference;
                secondDriver.TotalTime += difference;
                result.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {currLap}.");
            }
        }
        
    }

    private bool IsCrashed(Driver firstDriver)
    {
        if (firstDriver.GetType().Name.Contains("Aggressive") && firstDriver.Car.Tyre.Name == "Ultrasoft" &&
            this.weather == "Foggy") return true;

        if (firstDriver.GetType().Name.Contains("Endurance") && firstDriver.Car.Tyre.Name == "Hard" &&
            this.weather == "Rainy") return true;

        return false;
    }

    private void CheckForSpecialConditions(Driver firstDriver, ref int difference)
    {

        if (firstDriver.GetType().Name.Contains("Aggressive") && firstDriver.Car.Tyre.Name == "Ultrasoft" ||
            firstDriver.GetType().Name.Contains("Endurance") && firstDriver.Car.Tyre.Name == "Hard")
        {
            difference = 3;

        }


    }


    private void DeleteFaluerDrivers()
    {
        foreach (var falureDriver in this.falureDrivers.Keys)
        {
            if (this.drivers.Keys.Any(s => s == falureDriver.Name)) this.drivers.Remove(falureDriver.Name);
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber + this.currentLap}");
        int counter = 1;
        foreach (var driver in drivers.Values.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{counter} {driver.Name} {driver.TotalTime:f3}");
            counter++;
        }

        var falureDriverForPrint = this.falureDrivers.Reverse();
        foreach (var driver in falureDriverForPrint)
        {
            sb.AppendLine($"{counter} {driver.Key.Name} {driver.Value}");
            counter++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public bool IsFinishedeRace()
    {
        return this.LapsNumber == 0;

    }

    public string GetWinner()
    {
        var winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }
}
