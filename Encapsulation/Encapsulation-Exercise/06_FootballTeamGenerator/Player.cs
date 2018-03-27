
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private Stat[] stats;
    private int[] statNumbers;

    public Player(string name, Stat[] stats)
    {
        this.Name = name;
        this.Stats = stats;
        this.statNumbers=new int[5];
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

    public Stat[] Stats
    {
        get=>this.stats;
        set
        {

            this.stats = new Stat[5];
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].StatNumber < 0 || value[i].StatNumber > 100)
                    throw new ArgumentException($"{value[i].GetType().Name} should be between 0 and 100.");
                this.stats[i] = value[i];
            }
        }
    }
}
