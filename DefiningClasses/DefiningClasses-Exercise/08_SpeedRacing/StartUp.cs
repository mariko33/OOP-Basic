using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Car>cars=new List<Car>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
            cars.Add(car);

        }

        string inputString;
        while ((inputString=Console.ReadLine())!="End")
        {
            var input = inputString.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
                Car currentCar = cars.FirstOrDefault(c => c.Model == input[1]);
                currentCar.CarMove(int.Parse(input[2]));
            
        }
            
           cars.ForEach(c=>Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}")); 
        
    }
}

