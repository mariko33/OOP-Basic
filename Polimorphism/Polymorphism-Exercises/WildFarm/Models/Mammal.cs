namespace WildFarm.Models
{
	public abstract class Mammal:Animal
	{
		public Mammal(string animalType, string animalName, double animalWeght,
			string livingRegion) : base(animalType, animalName, animalWeght)
		{
			this.LivingRegion = livingRegion;
		}

		protected string LivingRegion { get; set; }

		public override string ToString()
		{
			return $"{this.AnimalType}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}