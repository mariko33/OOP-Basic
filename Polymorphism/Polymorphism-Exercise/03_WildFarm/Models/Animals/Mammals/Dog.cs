  using System;

public class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Meat") throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        this.Weight += food.Quantity * 0.40;
        this.FoodEaten += food.Quantity;
    }
}
