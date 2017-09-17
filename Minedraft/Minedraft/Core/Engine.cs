using System;
using System.ComponentModel;
using System.Linq;

public class Engine
{
    private DraftManager manager;
    private bool isRunning;

    public Engine()
    {
        this.manager = new DraftManager();
        this.isRunning = true;
    }

    public void Run()
    {
        string input;
        while (isRunning)
        {
            input = Console.ReadLine();
            var inputArgs = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputArgs[0];
            inputArgs.Remove(inputArgs[0]);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.manager.RegisterHarvester(inputArgs));
                    
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.manager.RegisterProvider(inputArgs));
                    break;
                case "Day":
                    Console.WriteLine(this.manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.manager.Mode(inputArgs));
                    break;
                case "Check":
                    Console.WriteLine(this.manager.Check(inputArgs));
                    break;
                case "Shutdown":
                    Console.WriteLine(this.manager.ShutDown());
                    this.isRunning = false;
                    break;

            }

        }

    }
}