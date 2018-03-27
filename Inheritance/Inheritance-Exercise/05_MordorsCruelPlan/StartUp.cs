using System;

namespace _05_MordorsCruelPlan
{
    class StartUp
    {
        static void Main()
        {
            var foodsList = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            int GandalfPoint = 0;
            for (int i = 0; i < foodsList.Length; i++)
            {
                GandalfPoint += FoodFactory.GetFood(foodsList[i]).PointOfHappines;
            }

            Console.WriteLine(GandalfPoint);
            Console.WriteLine(MoodFactory.GetMood(GandalfPoint).ToString());
        }
    }
}
