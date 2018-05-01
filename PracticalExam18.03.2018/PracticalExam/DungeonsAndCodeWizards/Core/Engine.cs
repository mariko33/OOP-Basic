using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private bool isRunning;

        public Engine()
        {
            this.dungeonMaster=new DungeonMaster();
            this.isRunning = true;
        }

        public void Run()
        {
          
            string input;
            while (isRunning)
            {
                input = Console.ReadLine();
                
                try
                {
                    
                    ResolveCommand(input);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);

                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine("Invalid Operation: "+ie.Message);
                }

                if (this.dungeonMaster.IsGameOver()||isRunning==false)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(this.dungeonMaster.GetStats());
                    isRunning = false;
                    // Environment.Exit(0);
                }
            }

        }

        private void ResolveCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                this.isRunning = false;
                return;
            }

            string[] args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string command = args[0];

            args = args.Skip(1).ToArray();

            string result=String.Empty;
            switch (command)
            {
                case "JoinParty":
                    result= dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    result = dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    result = dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    result = dungeonMaster.UseItem(args);
                    break;
                case "UseItemOn":
                    result = dungeonMaster.UseItemOn(args);
                    break;
                case "GiveCharacterItem":
                    result = dungeonMaster.GiveCharacterItem(args);
                    break;
                case "GetStats":
                    result = dungeonMaster.GetStats();
                    break;
                case "Attack":
                    result = dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    result = dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    result = dungeonMaster.EndTurn(args);
                    break;
                
            }
            if(result!=string.Empty)
                Console.WriteLine(result);
        }
    }
}