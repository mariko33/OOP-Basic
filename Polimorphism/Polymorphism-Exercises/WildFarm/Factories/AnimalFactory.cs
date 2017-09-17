using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
	public class AnimalFactory
	{
		public static Animal GetAnimal(string[] tokens)
		{
			string animalType = tokens[0];
			string animalName = tokens[1];
			double animalWeight = double.Parse(tokens[2]);
			string livingRegion = tokens[3];

			switch (animalType)
			{
				case "Zebra":
					return new Zebra(animalType,animalName,animalWeight,livingRegion);
					break;
				case "Tiger":
					return new Tiger(animalType, animalName, animalWeight, livingRegion);
					break;
				case "Mouse":
					return new Mouse(animalType, animalName, animalWeight, livingRegion);
					break;
				case "Cat":
					return new Cat(animalType, animalName, animalWeight, livingRegion,tokens[4]);
				default: return null;
			}
		}
	}
}