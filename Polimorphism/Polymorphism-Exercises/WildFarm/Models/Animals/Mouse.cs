using System;

namespace WildFarm.Models.Animals
{
	public class Mouse:Mammal
	{
		public Mouse(string animalType, string animalName, double animalWeght,  string livingRegion) : base(animalType, animalName, animalWeght,  livingRegion)
		{
		}

		public override string MakeSound()
		{
			return "SQUEEEAAAK!";
		}

		public override void Eat(Food food)
		{
			if (food.FoodType!= "Vegetable")
			{
				throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
			}
			this.FoodEaten += food.Quantity;
		}
	}
}