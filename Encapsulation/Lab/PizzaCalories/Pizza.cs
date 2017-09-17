using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PizzaCalories
{
	public class Pizza
	{
		//name, dough and toppings
		private string name;

		private Dough dough;
		private int numberOfToppings;
		private List<Topping> toppings;
		

		public Pizza(string name, int numnberOfToppings)
		{
			this.Name = name;
			this.toppings = new List<Topping>();
			this.NumberOfToppings = numnberOfToppings;
		}

		public string Name { get { return this.name; }
			set
			{
				if (string.IsNullOrEmpty(value)||value.Length>15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				this.name = value;
			} }
		public int NumberOfToppings
		{ get { return this.numberOfToppings; }
			set
			{
				if (value<0||value>10)
				{
					throw new ArgumentException("Number of toppings should be in range [0..10].");
				}
				this.numberOfToppings = value;
			} }
		
		public Dough Dough { get { return this.dough; } set { this.dough = value; } }

		public void AddTopping(Topping topping)
		{
			
				this.toppings.Add(topping);

			
		}

		public double TotalCalories()
		{

			double toppingCalories = this.toppings.Sum(t => t.GetCaloriesTopping());
			return toppingCalories + this.Dough.GetCaloriesDough();

		}
	}
}