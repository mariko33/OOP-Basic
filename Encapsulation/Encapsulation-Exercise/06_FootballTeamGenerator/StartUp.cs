using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static List<Team> teams = new List<Team>();
    static void Main()
    {


        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var inputInfo = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputInfo[0];
            switch (command)
            {
                case "Team":
                    AddNewTeam(inputInfo[1]);
                    break;
                case "Add": //<TeamName>;<PlayerName>;<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>

                    string teamName = inputInfo[1];
                    string playerName = inputInfo[2];
                    int enduranse = int.Parse(inputInfo[3]);
                    int sprint = int.Parse(inputInfo[4]);
                    int drible = int.Parse(inputInfo[5]);
                    int passing = int.Parse(inputInfo[6]);
                    int shooting = int.Parse(inputInfo[7]);
                    AddPlayerToTeam(teamName, playerName, enduranse, sprint, drible, passing, shooting);
                    break;

                case "Remove"://<TeamName>;<PlayerName>
                    RemovePlayer(inputInfo[1], inputInfo[2]);
                    break;
                case "Rating":
                    PrintTeamRating(inputInfo[1]);
                    break;

            }

        }
    }

    private static void PrintTeamRating(string teamName)
    {
        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            
        }
        else
        {
            Console.WriteLine($"{teamName} - {teams.FirstOrDefault(t => t.Name == teamName).Rating()}");
        }
        
    }

    private static void RemovePlayer(string teamName, string playerName)
    {
        if (!teams.Any(t=>t.Name==teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }
        else
        {
            Team currTeam = teams.FirstOrDefault(t => t.Name == teamName);
            try
            {
                currTeam.RemovePlayer(playerName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }


    }

    private static void AddPlayerToTeam(string teamName, string playerName, int enduranse, int sprint, int drible, int passing, int shooting)
    {
        List<Stat> stats = new List<Stat>();
        Stat[]statsN=new Stat[5];
        try
        {
            Stat enduranseStat = new Endurance(enduranse);
            stats.Add(enduranseStat);
            Stat sprintStat = new Sprint(sprint);
            stats.Add(sprintStat);
            Stat dribleStat = new Dribble(drible);
            stats.Add(dribleStat);
            Stat passingStat = new Passing(passing);
            stats.Add(passingStat);
            Stat shootingStat = new Shooting(shooting);
            stats.Add(shootingStat);

            for (int i = 0; i < statsN.Length; i++)
            {
                statsN[i] = stats[i];
            }
            
                try
                {
                    Player currPlayer = new Player(playerName, statsN);

                    if (!teams.Any(t => t.Name == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");

                    }
                    else
                    {
                        teams.FirstOrDefault(t => t.Name == teamName).AddPlayer(currPlayer);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            
            

        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
           
        }
    }

    private static void AddNewTeam(string teamName)
    {
        if (!teams.Any(t => t.Name == teamName))
        {
            teams.Add(new Team(teamName));
        }
    }
}

