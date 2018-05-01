using System;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException(Constants.Constants.CharecterNeedsToBeAlive);
            //character.Health -= 20;
            character.DecreaseHealth(20);
            if (character.Health <= 0) character.DeadCharacter();

        }
    }
}