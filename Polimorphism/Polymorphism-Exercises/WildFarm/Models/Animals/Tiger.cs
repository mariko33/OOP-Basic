using System;

namespace WildFarm.Models.Animals
{
	public class Tiger:Felime
	{
		public Tiger(string animalType, string animalName, double animalWeght, string livingRegion) : base(animalType, animalName, animalWeght, livingRegion)
		{
		}

		public override void Eat(Food food)
		{
			if (food.FoodType != "Meat")
			{
				throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
			}
			this.FoodEaten += food.Quantity;
		}

		public override string MakeSound()
		{
			return "ROAAR!!!";
		}
	}
}