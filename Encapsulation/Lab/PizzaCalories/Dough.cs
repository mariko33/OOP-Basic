using System;

namespace PizzaCalories
{
	public class Dough
	{
		private string flourType;
		private string bakingTechnique;
		private double weight;

		public Dough(string flourType, string bakingTechnique, double weight)
		{
			this.FlourType = flourType.ToLower();
			this.BakingTechnique = bakingTechnique.ToLower();
			this.Weight = weight;
		}

		public string FlourType
		{ get { return this.flourType; }
			set
			{

				if (value!="white"&&value!="wholegrain")
				{
					throw new ArgumentException("Invalid type of dough.");
				}

				
					this.flourType = value;
			

				
				
			}
		}
		public string BakingTechnique
		{ get { return this.bakingTechnique; }
			set
			{
				if (value!="crispy"&&value!= "chewy"&&value!= "homemade")
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				this.bakingTechnique = value;
			}
		}
		public double Weight
		{ get { return this.weight; }
			set
			{
				if (value<1||value>200)
				{
					throw new ArgumentException("Dough weight should be in the range [1..200].");
				}
				this.weight = value;
			}
		}

		public double GetCaloriesDough()
		{
			double typeModifier=0;
			double bakingTechniqueModifier=0;
			switch (this.FlourType)
			{
				case "white":
					typeModifier += 1.5;
					break;
				case "wholegrain": typeModifier += 1.0;
					break;
			}
			switch (this.BakingTechnique)
			{
				case "crispy": bakingTechniqueModifier += 0.9;
					break;
				case "chewy": bakingTechniqueModifier += 1.1;
					break;
				case "homemade": bakingTechniqueModifier += 1.0;
					break;
			}

			double allCalories = 2 * this.Weight * typeModifier * bakingTechniqueModifier;
			return allCalories;
		}
	}
}
