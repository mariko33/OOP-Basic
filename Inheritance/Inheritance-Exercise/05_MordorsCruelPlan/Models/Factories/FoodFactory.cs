
public static class FoodFactory
{
    public static Food GetFood(string food)
    {
        string input = food.ToLower();

        if (input.Equals("cram")) return new Cram(2);
        if (input.Equals("lembas")) return new Lembas(3);
        if (input.Equals("apple")) return new Apple(1);
        if (input.Equals("melon")) return new Melon(1);
        if (input.Equals("honeycake")) return new HoneyCake(5);
        if (input.Equals("mushrooms")) return new Mushrooms(-10);
        return new Food(-1);

    }
}
