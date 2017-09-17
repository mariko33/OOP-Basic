using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
	class SturtUp
	{
	public static void Main(string[] args)
	{
		int num = int.Parse(Console.ReadLine());
			List<Car>cars=new List<Car>();
		for (int i = 0; i < num; i++)
		{
			var input = Console.ReadLine().Split(' ');
				var car=new Car(input[0]);
			int speed = int.Parse(input[1]);
			int power = int.Parse(input[2]);
				var engine=new Engine(speed,power);
				var cargo=new Cargo(int.Parse(input[3]), input[4]);
				var tires=new Tire[]
				{
					new Tire(double.Parse(input[5]),int.Parse(input[6])),
					new Tire(double.Parse(input[7]),int.Parse(input[8])),
					new Tire(double.Parse(input[9]),int.Parse(input[10])),
					new Tire(double.Parse(input[11]),int.Parse(input[12]))
				};
			car.Engine = engine;
			car.Tires = tires;
			car.Cargo = cargo;
				cars.Add(car);
		}
		string cargoType = Console.ReadLine();
		if (cargoType == "fragile")
		{
			var output = cars.Where(c => c.Cargo.Type == "fragile").Where(car=>car.Tires.Any(t=>t.Pressure<1));
			foreach (var car in output)
			{
				Console.WriteLine(car.Model);
			}
		}
		else if(cargoType== "flamable")
		{
			var output = cars.Where(c => c.Cargo.Type == "flamable"&&c.Engine.Power>250);
			foreach (var car in output)
			{
				Console.WriteLine(car.Model);
			}
			}

		//cars.ForEach(car=>Console.WriteLine($"{car.Model}, EngineSpeed: {car.Engine.Speed}, CargoWeight {car.Cargo.Weight}"));
	}
	}
}
