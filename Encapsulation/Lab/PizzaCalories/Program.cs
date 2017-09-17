using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
	public class Program
	{
		static void Main(string[] args)
		{
			string inputDough;

			while ((inputDough = Console.ReadLine()) != "END")
			{
				var doughInfo = inputDough.Split(' ');

				if (doughInfo[0] == "Dough")
				{
					try
					{
						Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
						Console.WriteLine($"{dough.GetCaloriesDough():f2}");
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);

					}
				}
				else if(doughInfo[0]== "Topping")
				{
					try
					{
						Topping topping = new Topping(doughInfo[1], double.Parse(doughInfo[2]));
						Console.WriteLine($"{topping.GetCaloriesTopping():f2}");
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);

					}
				}

				else if (doughInfo[0] == "Pizza")
					{

						//var pizzaInfo = input.Split(' ');
						

						try
						{
							Pizza pizza = new Pizza(doughInfo[1], int.Parse(doughInfo[2]));
						var doughInput = Console.ReadLine().Split(' ');
						pizza.Dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
							for (int i = 0; i < int.Parse(doughInfo[2]); i++)
							{
								var toppingInput = Console.ReadLine().Split(' ');
								Topping topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));
								pizza.AddTopping(topping);
							}

							Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							

						}
					}

				}




			}
		}
	}

