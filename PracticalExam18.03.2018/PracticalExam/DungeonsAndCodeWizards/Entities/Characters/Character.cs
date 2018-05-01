using System;
using System.Linq;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints,
            Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;

            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Constants.Constants.NameCannotBeNull);
                }

                this.name = value;
            }
        }
        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            protected set
            {
                if (value > this.BaseHealth) value = this.BaseHealth;
                if (value < 0) value = 0;
                this.health = value;
            }
        }

        public double BaseArmor { get; set; }

        public double Armor
        {
            get => this.armor;
            protected set
            {
                if (value < 0) value = 0;
                if (value > this.BaseArmor) value = this.BaseArmor;
                this.armor = value;

            }
        }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public Faction Faction { get; private set; }
        public bool IsAlive { get; private set; }
        public virtual double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);

            if (this.Armor >= hitPoints) this.Armor -= hitPoints;
            else
            {
                double leftHitPoints = hitPoints - this.Armor;
                this.Armor -= hitPoints;
                this.Health -= leftHitPoints;
                if (this.Health <= 0) this.IsAlive = false;
            }
        }

        public void Rest()
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            if (!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
         
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            if (!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            character.ReceiveItem(item);
 

        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            this.Bag.AddItem(item);
        }

        public void IncreaseHealth(double points)
        {
            this.Health += points;

        }

        public void DecreaseHealth(double points)
        {
            this.Health -= points;

        }

        public void ArmorToBaseValue()
        {
            this.Armor = this.BaseArmor;
        }

        public void DeadCharacter()
        {
            this.IsAlive = false;

        }

        public override string ToString()
        {
            string status = this.IsAlive ?"Alive":"Dead";
            
            return $"{this.name} - HP: {this.health}/{this.BaseHealth}, AP: {this.armor}/{this.BaseArmor}, " +
                   $"Status: {status}";
        }
    }
}