using System;
using System.Linq;

namespace StorageMaster.Controller
{
    public class Engine
    {
        private StorageMaster master;

        public Engine()
        {

            this.master=new StorageMaster();
        }
        
        public void Run()
        {
            string input;
            while ((input=Console.ReadLine())!="END")
            {
                var args = input.Split();
                string command = args[0];
                args = args.Skip(1).ToArray();
                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            Console.WriteLine(this.master.AddProduct(args[0], double.Parse(args[1])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(this.master.RegisterStorage(args[0],args[1]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(this.master.SelectVehicle(args[0],int.Parse(args[1])));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(this.master.LoadVehicle(args));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(this.master.SendVehicleTo(args[0],int.Parse(args[1]),args[2]));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(this.master.UnloadVehicle(args[0],int.Parse(args[1])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(this.master.GetStorageStatus(args[0]));
                            break;


                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Error: "+e.Message);
                   
                }
            }

            Console.WriteLine(this.master.GetSummary());
            
        }
    }
}