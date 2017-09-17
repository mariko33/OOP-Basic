namespace WildFarm.Models.Foods
{
	public class FoodFactory
	{
		public static Food GetFood(string[]tokens)
		{
			string foodType = tokens[0];
			int quantity = int.Parse(tokens[1]);
			switch (foodType)
			{
				case "Meat":
					return new Meat(foodType,quantity);
					break;
				case "Vegetable":
					return new Vegetable(foodType,quantity);
					break;
				default: return null;
			}
		}
	}
}