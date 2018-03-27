
    using System;

public class Owl:Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight,  wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Feed(Food food)
        {
            if(food.GetType().Name!="Meat")throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            this.Weight += food.Quantity * 0.25;
            this.FoodEaten += food.Quantity;
        }
    }
