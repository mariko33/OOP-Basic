
using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        
        this.raceTower.SetTrackInfo(lapsNumber,trackLength);

        while (true)
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string command = input[0];

            var arguments = input.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(arguments);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                   string result= this.raceTower.CompleteLaps(arguments);
                    if(result!=string.Empty)Console.WriteLine(result);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(arguments);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(arguments);
                    break;
            }


            if (this.raceTower.IsFinishedeRace())
            {
                Console.WriteLine(this.raceTower.GetWinner());
                Environment.Exit(0);
            }
        }
    }




}
