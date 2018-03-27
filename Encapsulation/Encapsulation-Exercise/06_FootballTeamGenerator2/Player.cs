
using System;

public class Player
{
    private string name;
    private double overallSkill;

    public Player(string name,Stat endurance, Stat spring, Stat dribble, Stat passing, Stat shooting)
    {
        this.Name = name;
        Endurance = endurance;
        Spring = spring;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }
    
    public Stat Endurance { get; set; }
    public Stat Spring { get; set; }
    public Stat Dribble { get; set; }
    public Stat Passing { get; set; }
    public Stat Shooting { get; set; }

    public double OverAllSkll { get; set; }

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

    public double CalculateOverallSkill()
    {
        double sum = (this.Dribble.Level + this.Endurance.Level + this.Shooting.Level + this.Passing.Level +
                   this.Spring.Level);
        this.OverAllSkll = Math.Round(sum/5,0);
        return this.OverAllSkll;
    }

}
