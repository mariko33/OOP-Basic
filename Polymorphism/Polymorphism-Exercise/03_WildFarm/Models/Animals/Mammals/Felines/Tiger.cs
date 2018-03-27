 using System;

public class Tiger:Feline
    {
        public Tiger(string name, double weight,  string livingRegion,string breed) 
            : base(name, weight, livingRegion,breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Meat") throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        this.Weight += food.Quantity * 1.00;
        this.FoodEaten += food.Quantity;
    }
}
