using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }

    public override void Feed(Food food)
    {
        this.Weight += food.Quantity * 0.35;
        this.FoodEaten += food.Quantity;
    }
}
