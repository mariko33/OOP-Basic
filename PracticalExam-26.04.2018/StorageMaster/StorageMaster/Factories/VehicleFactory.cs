using System;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Semi":
                    return new Semi();
                case "Van":
                    return new Van();
                case "Truck":
                    return new Truck();
                default:throw new InvalidOperationException("Invalid vehicle type!");
            }

        }
    }
}