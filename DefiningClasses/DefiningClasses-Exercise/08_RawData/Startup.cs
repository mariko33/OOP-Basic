using System;
using System.Collections.Generic;
using System.Linq;


class Startup
    {
        static void Main()
        {
            List<Car> cars=new List<Car>();

            int numbersOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfCars; i++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                Engine engine=new Engine(int.Parse(input[1]),int.Parse(input[2]));
                Cargo cargo=new Cargo(input[4],int.Parse(input[3]));
                List<Tire>tires=new List<Tire>()
                {
                    new Tire(double.Parse(input[5]), int.Parse(input[6])),
                    new Tire(double.Parse(input[7]), int.Parse(input[8])),
                    new Tire(double.Parse(input[9]), int.Parse(input[10])),
                    new Tire(double.Parse(input[11]), int.Parse(input[12]))
                };
                
                Car car=new Car(input[0],engine,cargo,tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command== "fragile")
            {
                cars.Where(c=>c.Cargo.Type== "fragile"&&c.Tires.Any(t=>t.Pressure<1))
                    .ToList()
                    .ForEach(c=>Console.WriteLine(c.Model));
            }
            else
            {
                cars.Where(c=>c.Cargo.Type== "flamable"&&c.Engine.Power>250)
                    .ToList()
                    .ForEach(c=>Console.WriteLine(c.Model));
            }

        }
    }

