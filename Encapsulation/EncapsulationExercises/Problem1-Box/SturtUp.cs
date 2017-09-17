using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Box
{
	class SturtUp
	{
		static void Main(string[] args)
		{
			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());
			Box box=new Box(length,width,height);
			Console.WriteLine(3);
			Console.WriteLine($"Surface Area - {box.SurfaceArea(length,width,height):f2}");
			Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(length,width,height):f2}");
			Console.WriteLine($"Volume - {box.Volume(length,width,height):f2}");


		}
	}
}
