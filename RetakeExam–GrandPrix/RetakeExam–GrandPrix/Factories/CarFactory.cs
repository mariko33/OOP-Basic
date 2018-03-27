
    using System.Collections.Generic;

public class CarFactory
    {
        public static Car GetCar(List<string>arguments, Tyre tyre)
        {
            int hp = int.Parse(arguments[0]);
            double fuelAmount = double.Parse(arguments[1]);
            return new Car(hp, fuelAmount, tyre);

        }
    }
