using System.Reflection.Emit;

namespace WildFarm.Models
{
	public abstract class Animal
	{
		public Animal(string animalType, string animalName, double animalWeght)
		{
			this.AnimalType = animalType;
			this.AnimalName = animalName;
			this.AnimalWeight = animalWeght;
			
		}

		protected string AnimalType { get; set; }
		protected string AnimalName { get; set; }
		protected double AnimalWeight { get; set; }
		protected int FoodEaten { get; set; }

		public abstract string MakeSound();

		public virtual void Eat(Food food)
		{
			this.FoodEaten += food.Quantity;
		}


	}
}