using System;
using System.Collections.Generic;


class Program
{
    public static Dictionary<string, Team> teams=new Dictionary<string, Team>();
    static void Main()
    {
        string line;

        while ((line = Console.ReadLine()) != "END")
        {
            var tokens = line.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            try
            {
                ProccessCommand(command, tokens);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

    }

    private static void ProccessCommand(string command, string[] tokens)
    {
        switch (command)
        {
            case "Team":
                CreateTeam(tokens[1]);
                break;
            case "Add":
                AddPlayerTeam(tokens[1],
                    tokens[2],
                    int.Parse(tokens[3]),
                    int.Parse(tokens[4]),
                    int.Parse(tokens[5]),
                    int.Parse(tokens[6]),
                    int.Parse(tokens[7]));
                break;
            case "Remove":
                RemovePlayerFromTeam(tokens[1], tokens[2]);
                break;
            case "Rating":
                GetRating(tokens[1]);
                break;
        }
    }

    private static void GetRating(string teamName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
        }

        Team team = teams[teamName];
        Console.WriteLine(team);

    }

    private static void RemovePlayerFromTeam(string teamName, string playerName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
        }
        Team team = teams[teamName];
        team.RemovePlayer(playerName);
    }

    private static void AddPlayerTeam(string teamName, string playerName, int enduranse, int sprint,
        int dribble, int passing, int shooting)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
        }
        
        Player player=new Player(playerName, 
            new Stat("Endurance",enduranse),
            new Stat("Sprint", sprint),
            new Stat("Dribble", dribble),
            new Stat("Passing", passing),
            new Stat("Shoting", shooting));

        Team team = teams[teamName];
        team.AddPlayer(player);
    }

    private static void CreateTeam(string teamName)
    {
        Team team=new Team(teamName);
        teams.Add(teamName,team);
    }
}

