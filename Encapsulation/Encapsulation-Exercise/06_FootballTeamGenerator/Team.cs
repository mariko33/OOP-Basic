
using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players=new List<Player>();
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value))
            {
               throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.players.Any(p=>p.Name==playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        Player currPlayer = this.players.FirstOrDefault(p => p.Name == playerName);
        this.players.Remove(currPlayer);
    }

    public int Rating()
    {
        if (this.players.Count == 0) return 0;
 
        var sumAvSkillLevels = this.players.Sum(p => p.Stats.Average(s=>s.StatNumber));
        return (int)Math.Round(sumAvSkillLevels / this.players.Count);
    }
}