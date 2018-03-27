using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


class StartUp
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        var info = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        vehicles.Add(CreateVehicle(info));
        var info1 = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        vehicles.Add(CreateVehicle(info1));
        var info2 = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        vehicles.Add(CreateVehicle(info2));

        Vehicle car = vehicles.FirstOrDefault(c => c.GetType().Name == "Car");
        Vehicle truck = vehicles.FirstOrDefault(c => c.GetType().Name == "Truck");
        Vehicle bus = vehicles.FirstOrDefault(c => c.GetType().Name == "Bus");

        int nLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < nLines; i++)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = input[0];
            string vehicle = input[1];

            double distance = double.Parse(input[2]);

            try
            {
                GetValue(command, vehicle, car, distance, truck, bus, input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);


    }

    private static void GetValue(string command, string vehicle, Vehicle car, double distance, Vehicle truck, Vehicle bus,
        string[] input)
    {
        switch (command)
        {
            case "Drive":
                if (vehicle == "Car")
                {
                    Console.WriteLine(car.Drive(distance, 0));
                }
                else if (vehicle == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance, 0));
                }
                else
                {
                    Console.WriteLine(bus.Drive(distance, 1.4));
                }
                break;
            case "Refuel":
                if (vehicle == "Car")
                {
                    car.Refueling(double.Parse(input[2]));
                }
                else if (vehicle == "Truck")
                {
                    truck.Refueling(double.Parse(input[2]));
                }
                else
                {

                    bus.Refueling(double.Parse(input[2]));
                }
                break;
            case "DriveEmpty":
                Console.WriteLine(bus.Drive(double.Parse(input[2]), 0));
                break;
        }
    }

    private static Vehicle CreateVehicle(string[] info)
    {
        string type = info[0];
        double fuelQuantity = double.Parse(info[1]);
        double litersPerKm = double.Parse(info[2]);
        double tankCapacity = double.Parse(info[3]);
        switch (type)
        {
            case "Car":
                return new Car(fuelQuantity, litersPerKm, tankCapacity);

            case "Truck":
                return new Truck(fuelQuantity, litersPerKm, tankCapacity);

            default:
                return new Bus(fuelQuantity, litersPerKm, tankCapacity);


        }
    }
}

