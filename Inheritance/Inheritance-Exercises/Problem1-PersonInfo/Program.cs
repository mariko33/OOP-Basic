using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_PersonInfo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());

			try
			{
				Child child = new Child(name, age);
				Console.WriteLine(child);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
				
				
			}

		}
	}
}
