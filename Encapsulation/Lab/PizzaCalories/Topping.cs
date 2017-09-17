﻿using System;
using System.Net.Http.Headers;

namespace PizzaCalories
{
	public class Topping
	{
		private string toppingType;
		private double weight;

		public Topping(string toppingType, double weight)
		{
			this.ToppingType = toppingType;
			this.Weight = weight;
		}

		public string ToppingType
		{ get { return this.toppingType; }
			set
			{
				if (value.ToLower() != "meat"&&value.ToLower() != "veggies"&&value.ToLower() != "cheese"&&value.ToLower() != "sauce")
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}
				this.toppingType = value;
			} }
		public double Weight { get { return this.weight; }
			set
			{
				if (value<1||value>50)
				{
				   throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
				}
				this.weight = value;
			}
		}

		public double GetCaloriesTopping()
		{

			double typeModifier = 0;
			switch (this.ToppingType.ToLower())
			{
				case "meat": typeModifier += 1.2;
					break;
				case "veggies": typeModifier += 0.8;
					break;
				case "cheese": typeModifier += 1.1;
					break;
				case "sauce": typeModifier += 0.9;
					break;
			}
			double allToppingCalories = 2 * this.Weight * typeModifier;
			return allToppingCalories;
		}
		
	}
}