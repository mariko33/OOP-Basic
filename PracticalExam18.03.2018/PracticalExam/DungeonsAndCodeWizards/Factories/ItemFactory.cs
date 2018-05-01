using System;
using System.Linq;
using System.Reflection;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            Item item;
            switch (name)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            return item;
        }

        //public Item CreateItem(string[] args)
        //{
        //    string itemType = args[0];

        //    Type type = Assembly
        //        .GetCallingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name == itemType);

        //    if (type == null)
        //        throw new ArgumentException(String.Format(Constants.Constants.InvalidItem, itemType));

        //    ConstructorInfo ctorInfo = type.GetConstructors().First();

        //    Item item = (Item)ctorInfo.Invoke(null);

        //    return item;
        //}
    }
}