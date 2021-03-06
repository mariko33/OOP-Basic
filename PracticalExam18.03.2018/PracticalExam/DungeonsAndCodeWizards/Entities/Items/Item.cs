﻿using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        protected Item(int weight)
        {
           this. Weight = weight;
        }

        public int Weight { get;private set; }

        public abstract void AffectCharacter(Character character);

    }
}