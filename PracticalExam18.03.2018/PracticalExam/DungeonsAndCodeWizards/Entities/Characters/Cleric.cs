using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric:Character,IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            if (!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);

            if(this.Faction!=character.Faction)
                throw new InvalidOperationException(Constants.Constants.DifferentFactionHealing);
            
            character.IncreaseHealth(this.AbilityPoints);
        }
    }
}