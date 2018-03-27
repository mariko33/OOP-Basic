using System;
using System.Linq;

public class Engine
{
    private NationsBuilder builder;
    private bool isRunning;

    public Engine()
    {
        this.builder = new NationsBuilder();
        this.isRunning = true;
    }

    public void Run()
    {
        string input;
        while (isRunning)
        {
            input = Console.ReadLine();
            var inputArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputArgs[0];
            inputArgs.Remove(inputArgs[0]);
            switch (command)
            {
                case "Bender":
                    this.builder.AssignBender(inputArgs);
                    break;
                case "Monument":
                    this.builder.AssignMonument(inputArgs);
                    break;
                case "Status":
                    Console.WriteLine(this.builder.GetStatus(inputArgs[0]));
                    break;
                case "War":
                    this.builder.IssueWar(inputArgs[0]);
                    break;
                case "Quit":
                    Console.WriteLine(this.builder.GetWarsRecord());
                    this.isRunning = false;
                    break;
                default: throw new ArgumentException();

            }

        }

    }
}
