
    using System;
    using System.Collections.Generic;
    using System.Linq;

public class Team
    {
        private string name;
        private Dictionary<string, Player> players;
        private double rating;


        public Team(string name)
        {
            this.Name = name;
            this.players=new Dictionary<string, Player>();
            this.rating = 0.0;
        }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

        public void AddPlayer(Player player)
        {

            this.rating += player.CalculateOverallSkill();
            this.players.Add(player.Name,player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.ContainsKey(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Player player = this.players[playerName];
            this.rating -= player.CalculateOverallSkill();
            this.players.Remove(player.Name);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.rating}";
        }
    }
