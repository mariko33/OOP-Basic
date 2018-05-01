using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;

namespace StorageMaster.Controller
{
    public class StorageMaster
    {
        private List<Storage> storageRegistry;
        private Dictionary<string,Stack<Product>> productsPool;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;  

        public StorageMaster()
        {
            this.storageRegistry=new List<Storage>();
            this.productsPool=new Dictionary<string, Stack<Product>>();
            this.productFactory=new ProductFactory();
            this.storageFactory=new StorageFactory();
        
            
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            string nameProduct = product.GetType().Name;
            if (!this.productsPool.ContainsKey(nameProduct))
            {
                this.productsPool[nameProduct]=new Stack<Product>();
            }

            this.productsPool[nameProduct].Push(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            if(storage==null)
                throw new InvalidOperationException();
            
            this.currentVehicle = storage.GetVehicle(garageSlot);
            
            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductCount = 0;
            foreach (var name in productNames)
            {
                if (this.currentVehicle.IsFull)
                    break;

                if (!this.productsPool.ContainsKey(name)||!this.productsPool[name].Any())
                    throw new InvalidOperationException($"{name} is out of stock!");

                Product product = this.productsPool[name].Pop();
                this.currentVehicle.LoadProduct(product);

                loadedProductCount++;

            }
            
            
            return $"Loaded {loadedProductCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            if(sourceStorage==null)
                throw new InvalidOperationException("Invalid source storage!");

            Storage destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);
            if(destinationStorage==null)
                throw new InvalidOperationException("Invalid destination storage!");

            string vehicleType = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            if(storage==null)
                throw new InvalidOperationException();

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;

            int unloadedProductsCount= storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            if (storage == null)
                throw new InvalidOperationException();
            

            return storage.GetStatus();
        }

        public string GetSummary()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var storage in this.storageRegistry.OrderByDescending(s=>s.Products.Sum(p=>p.Price)))
            {
                sb.AppendLine(storage.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}