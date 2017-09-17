using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class Engine
{
	private bool isRunning;
	private NationsBuilder builder;
	public Engine()
	{
		this.isRunning = true;
		this.builder=new NationsBuilder();
	}

	public void Run()
	{
		string input;
		while (isRunning)
		{
			input = Console.ReadLine();
			var inputArgs = input.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
			string command = inputArgs[0];
			inputArgs.Remove(inputArgs[0]);
			switch (command)
			{
				case "Bender":
					builder.AssignBender(inputArgs);
					break;
			}
		}
	}
}
