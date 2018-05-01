using System;
using DungeonsAndCodeWizards.Entities.Characters;


namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion:Item
    {
        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if(!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
           // character.Health += 20; TODO
            character.IncreaseHealth(20);
        }
    }
}