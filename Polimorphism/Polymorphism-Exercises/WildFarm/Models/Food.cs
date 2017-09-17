namespace WildFarm.Models
{
	public abstract class Food
	{
		public Food(string foodType, int quantity)
		{
			this.FoodType = foodType;
			this.Quantity = quantity;

		}

		public int Quantity { get; set; }
		public string FoodType { get; set; }
	}
}