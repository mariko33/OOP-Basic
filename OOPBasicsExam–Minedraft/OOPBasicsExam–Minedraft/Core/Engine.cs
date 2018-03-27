
    using System;
    using System.Linq;

public class Engine
    {
        private DraftManager manager;
        private bool isRunning;

        public Engine()
        {
            this.manager=new DraftManager();
            this.isRunning = true;
        }

        public void Ran()
        {
            while (isRunning)
            {
                var input = Console.ReadLine().Split(new []{" "},StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                var arguments = input.Skip(1).ToList();

                switch (command)
                {
                case "RegisterHarvester": Console.WriteLine(manager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider": Console.WriteLine(manager.RegisterProvider(arguments));
                    break;
                case "Day": Console.WriteLine(manager.Day());
                    break;
                case "Mode": Console.WriteLine(manager.Mode(arguments));
                    break;
                case "Check": Console.WriteLine(manager.Check(arguments));
                    break;
                case "Shutdown": Console.WriteLine(manager.ShutDown());
                    isRunning = false;
                    break;
                }
            }

        }
    }
