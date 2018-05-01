using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];

            int count = Math.Min(this.GarageSlots, vehicles.Count());

            Vehicle[] vehiclesArr = vehicles.ToArray();

            for (int i = 0; i < count; i++)
            {
                this.garage[i] = vehiclesArr[i];
            }

            this.products = new List<Product>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public IReadOnlyCollection<Vehicle> Garage => this.garage;
        public IReadOnlyCollection<Product> Products => this.products;
        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
                throw new InvalidOperationException("Invalid garage slot!");

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
                throw new InvalidOperationException("No vehicle in this garage slot!");

            

            return vehicle;

        }

        public Vehicle GetVehicleWithoutRemoving(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
                throw new InvalidOperationException("Invalid garage slot!");

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
                throw new InvalidOperationException("No vehicle in this garage slot!");
            
            return vehicle;

        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            this.garage[garageSlot] = null;

            deliveryLocation.CheckFullGarageRoom();

            return deliveryLocation.FeelGarageFirstEmptySpace(vehicle);

        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
                throw new InvalidOperationException("Storage is full!");
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedCount = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloadedCount++;
            }



            return unloadedCount;
        }

        public int FeelGarageFirstEmptySpace(Vehicle vehicle)
        {
            int count = 0;
            for (int i = 0; i < this.garage.Length; i++)
            {
                if (this.garage[i] == null)
                {
                    count = i;
                    break;
                }

            }

            this.garage[count] = vehicle;
            return count;
        }

        public void CheckFullGarageRoom()
        {
            if (!this.garage.Any(g => g == null))
                throw new InvalidOperationException("No room in garage!");
        }

        public string GetStatus()
        {
            var groups = this.products
                .GroupBy(n => n.GetType().Name)
                .Select(n => new
                    {
                        name = n.Key,
                        count = n.Count()
                    }
                )
                .OrderByDescending(n => n.count)
                .ThenBy(n => n.name);


            List<string>groupString=new List<string>();
            foreach (var g in groups)
            {
                groupString.Add($"{g.name} ({g.count})");

            }

            List<string>garageInfo=new List<string>();

            foreach (var g in this.garage)
            {
                if (g == null)
                {
                    garageInfo.Add("empty");
                }
                else
                {
                    garageInfo.Add(g.GetType().Name);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Stock ({this.products.Sum(p => p.Weight)}/{this.Capacity}): [{string.Join(", ",groupString)}]");
            sb.AppendLine($"Garage: [{string.Join("|",garageInfo)}]");
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}:");
            sb.AppendLine($"Storage worth: ${this.products.Sum(p => p.Price):F2}");
            return sb.ToString().Trim();
        }
    }
}