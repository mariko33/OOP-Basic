
    using System;

public class Cat:Feline
    {
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat") throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        this.Weight += food.Quantity * 0.30;
        this.FoodEaten += food.Quantity;
    }

       
    }
