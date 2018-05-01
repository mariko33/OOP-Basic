﻿using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Entities.Products;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private Stack<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk=new Stack<Product>();
        }

        public int Capacity { get; private set; }
        public IReadOnlyCollection<Product> Trunk => this.trunk;
        public bool IsFull => this.Trunk.Sum(t => t.Weight) >= this.Capacity;
        public bool IsEmpty => this.Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if(this.IsFull)
                throw new InvalidOperationException("Vehicle is full!");
            this.trunk.Push(product);

        }

        public Product Unload()
        {
            if(this.IsEmpty)
                throw new InvalidOperationException("No products left in vehicle!");

            Product product = this.trunk.Pop();

            return product;
        }
    }
}