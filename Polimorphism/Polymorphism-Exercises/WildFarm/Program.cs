using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories;
using WildFarm.Models;
using WildFarm.Models.Foods;

namespace WildFarm
{
	public class Program
	{
		public static void Main()
		{
			string animalInfo;
			while ((animalInfo=Console.ReadLine())!="End")
			{
				var animalTokens = animalInfo.Split(new[] {'\t',' ','\n'},StringSplitOptions.RemoveEmptyEntries);
				try
				{
					Animal animal=AnimalFactory.GetAnimal(animalTokens);
					Console.WriteLine(animal.MakeSound());
					try
					{
						var foodInfo = Console.ReadLine().Split(new[] {'\t', ' ', '\n'}, StringSplitOptions.RemoveEmptyEntries);
						Food food=FoodFactory.GetFood(foodInfo);
						animal.Eat(food);
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						
					}
					
					Console.WriteLine(animal);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					
				}
			}
		}
	}
}
