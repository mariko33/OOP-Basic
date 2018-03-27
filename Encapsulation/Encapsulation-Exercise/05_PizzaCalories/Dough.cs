using System;

public class Dough
{
    private const double BaseCalories=2;
    
    private string flourType;
    private string backingTechnique;
    private double weightGr;

    public Dough(string flourType, string backingTechnique, double weightGr)
    {
        this.FlourType = flourType;
        this.BackingTechnique = backingTechnique;
        this.WeightGr = weightGr;
    }


    private double WeightGr
    {
        get => this.weightGr;
        set
        {
            if (value<1||value>200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weightGr = value;
        }
    }

    private string FlourType
    {
        get => this.flourType;
        set
        {
            if (value.ToLower()!="white"&&value.ToLower()!= "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    private string BackingTechnique
    {
        get => this.backingTechnique;
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.backingTechnique = value;
        }
    }

    public double Calories { get=>this.GetCalories();}

    private double GetCalories()
    {
        double typeCalories = 0;
        double backingCalories = 0;
        switch (this.FlourType.ToLower())
        {
            case "white":
                typeCalories = 1.5;
                break;
            case "wholegrain":
                typeCalories = 1;
                break;
        }
        switch (this.BackingTechnique.ToLower())
        {
            case "crispy":
                backingCalories = 0.9;
                break;
            case "chewy":
                backingCalories = 1.1;
                break;
            case "homemade":
                backingCalories = 1;
                break;
                
        }
        return BaseCalories * this.WeightGr * typeCalories * backingCalories;
    }

    public override string ToString()
    {
        return $"{this.GetCalories():f2}";
    }
}


