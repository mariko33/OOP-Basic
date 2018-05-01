using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();

        }
        public int Capacity { get; private set; }
        public double Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;
        
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
                throw new InvalidOperationException(Constants.Constants.FullBag);

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
                throw new InvalidOperationException(Constants.Constants.EmptyBag);

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
                throw new ArgumentException(String.Format(Constants.Constants.NoItemInBag, name));

            this.items.Remove(item);

            return item;

        }
    }
}