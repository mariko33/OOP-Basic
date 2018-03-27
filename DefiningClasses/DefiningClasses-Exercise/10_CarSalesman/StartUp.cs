using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Engine> engines = new List<Engine>();
        int engineCount = int.Parse(Console.ReadLine()); //<Model> <Power> <Displacement> <Efficiency>

        for (int i = 0; i < engineCount; i++)
        {

            var engineArr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (engineArr.Length >= 2)
            {
                Engine engine = new Engine(engineArr[0], int.Parse(engineArr[1]));
                if (engineArr.Length >= 3)
                {
                    if (int.TryParse(engineArr[2], out int displacementCurr))
                    {
                        engine.Displacement = displacementCurr;
                    }
                    else
                    {
                        engine.Efficienty = engineArr[2];
                    }

                }
                if (engineArr.Length == 4) engine.Efficienty = engineArr[3];

                engines.Add(engine);

            }


        }

        int carsCount = int.Parse(Console.ReadLine()); //<Model> <Engine> <Weight> <Color>

        List<Car> cars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            var carInput = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (carInput.Length >= 2)
            {
                Engine targetEngine = engines.FirstOrDefault(e => e.Model == carInput[1]);
                Car car = new Car(carInput[0], targetEngine);
                if (carInput.Length >= 3)
                {
                    if (int.TryParse(carInput[2], out int weightCur))
                    {
                        car.Weight = weightCur;
                    }
                    else
                    {
                        car.Color = carInput[2];
                    }

                }
                if (carInput.Length == 4) car.Color = carInput[3];
                cars.Add(car);
            }
        }

        cars.ForEach(c => Console.WriteLine(c));

    }
}

