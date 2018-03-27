using System;

public class Topping
{
    private const double BaseCalories = 2;
    
    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {
        get => this.toppingType;
         set
        {
            if (value.ToLower()!= "meat"&&value.ToLower()!= "veggies"&&value.ToLower()!= "cheese"&&value.ToLower()!= "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingType = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value<1||value>50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public double Calories { get=>this.GetCalories();}
    private double GetCalories()
    {
        double calories=0;
        switch (this.ToppingType.ToLower())
        {
            case "meat":
                calories = 1.2;
                break;
            case "veggies":
                calories = 0.8;
                break;
            case "cheese":
                calories = 1.1;
                break;
            case "sauce":
                calories = 0.9;
                break;
        }
        return this.Weight * BaseCalories * calories;
    }

    public override string ToString()
    {
        return $"{this.GetCalories():f2}";
    }
}