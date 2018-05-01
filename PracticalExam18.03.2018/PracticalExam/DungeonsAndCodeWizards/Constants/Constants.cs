using System;

namespace DungeonsAndCodeWizards.Constants
{
    public static class Constants
    {
        public const string CharecterNeedsToBeAlive = "Must be alive to perform this action!";
        public const string FullBag = "Bag is full!";
        public const string EmptyBag = "Bag is empty!";
        public const string NoItemInBag = "No item with name {0} in bag!";
        public const string NameCannotBeNull = "Name cannot be null or whitespace!";
        public const string AttackSelf = "Cannot attack self!";
        public const string SameFaction = "Friendly fire! Both characters are from {0} faction!";
        public const string DifferentFactionHealing = "Cannot heal enemy character!";
        public const string InvalidCharacter = "Invalid character type {0}!";
        public const string AddCharacterToParty = "{0} joined the party!";
        public const string InvalidFaction = "Invalid faction {0}!";
        public const string InvalidItem = "Invalid item type {0}!";
        public const string AddItem = "{0} added to pool.";
        public const string CharacterNotFound = "Character {0} not found!";
        public const string EmptyPool = "No items left in pool!";
        public const string PickUpCommand = "{0} picked up {1}!";
        public const string UseItemCommand = "{0} used {1}.";
        public const string UseItemOnCommand = "{0} used {1} on {2}.";
        public const string GiveCharacterItemCommand = "{0} gave {1} {2}.";
        public const string CharacterNotAttack = "{0} cannot attack!";
        public const string CharackterNotHeal = "{0} cannot heal!";
    }
}