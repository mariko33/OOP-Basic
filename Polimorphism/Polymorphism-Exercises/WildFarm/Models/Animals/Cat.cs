namespace WildFarm.Models.Animals
{
	public class Cat:Felime
	{
		public Cat(string animalType, string animalName, double animalWeght, string livingRegion,string breed) : base(animalType, animalName, animalWeght,livingRegion)
		{
			this.Breed = breed;
		}

		private string Breed { get; set; }

		public override string MakeSound()
		{
			return "Meowwww";
		}

		public override string ToString()
		{
			return $"{this.AnimalType}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}