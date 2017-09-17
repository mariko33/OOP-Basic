﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
	{
		static void Main(string[] args)
		{

		//System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
		//customCulture.NumberFormat.NumberDecimalSeparator = ".";

		var lines = int.Parse(Console.ReadLine());
			var persons = new List<Person>();
			for (int i = 0; i < lines; i++)
			{
				var cmdArgs = Console.ReadLine().Split();
				var person = new Person(cmdArgs[0],
					cmdArgs[1],
					int.Parse(cmdArgs[2]),
					double.Parse(cmdArgs[3]));

				persons.Add(person);
			}

			var bonus = double.Parse(Console.ReadLine());
		    persons.ForEach(p=>p.IncreaseSalary(bonus));
			persons.ForEach(p => Console.WriteLine(p.ToString()));

	}
}

