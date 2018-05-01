using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior: Character,IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
            
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            if (!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);

            if(this==character)
                throw new InvalidOperationException(Constants.Constants.AttackSelf);

            if(this.Faction==character.Faction)
                throw new ArgumentException(string.Format(Constants.Constants.SameFaction,this.Faction.ToString()));

            character.TakeDamage(this.AbilityPoints);
        }
    }
}