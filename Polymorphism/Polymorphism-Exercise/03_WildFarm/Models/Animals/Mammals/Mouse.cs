  using System;

public class Mouse:Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Vegetable"&& food.GetType().Name != "Fruit") throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        this.Weight += food.Quantity * 0.10;
        this.FoodEaten += food.Quantity;
    }
}
