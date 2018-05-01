using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factories;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characterParty;
        private Stack<Item> itemsPool;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRound;

        public DungeonMaster()
        {
            this.characterParty=new List<Character>();
            this.itemsPool=new Stack<Item>();
            this.characterFactory=new CharacterFactory();
            this.itemFactory=new ItemFactory();
            this.lastSurvivorRound = 0;
        }

        public string JoinParty(string[] args)
        {
            Character character = this.characterFactory.CreateCharacter(args[0],args[1],args[2]);
            this.characterParty.Add(character);
            return string.Format(Constants.Constants.AddCharacterToParty, character.Name);
        }

        public string AddItemToPool(string[] args)
        {
            Item item = this.itemFactory.CreateItem(args[0]);
            this.itemsPool.Push(item);
            return string.Format(Constants.Constants.AddItem, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if(character==null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, characterName));

            if(this.itemsPool.Count==0)
                throw new InvalidOperationException(Constants.Constants.EmptyPool);

            Item item = this.itemsPool.Pop();
            character.ReceiveItem(item);

            return string.Format(Constants.Constants.PickUpCommand, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);

            if(character==null)
                throw new ArgumentException(Constants.Constants.CharacterNotFound,characterName);
            
            Item item = character.Bag.GetItem(itemName);
                
            character.UseItem(item);

            return string.Format(Constants.Constants.UseItemCommand,characterName,itemName);
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giverCharacter = this.characterParty.FirstOrDefault(c => c.Name == giverName);
            if (giverCharacter == null)
                throw new ArgumentException(Constants.Constants.CharacterNotFound, giverName);

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, receiverName));

            Item item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.UseItemOn(item,receiverCharacter);

            return string.Format(Constants.Constants.UseItemOnCommand,giverName,itemName,receiverName);
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giverCharacter = this.characterParty.FirstOrDefault(c => c.Name == giverName);
            if (giverCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, giverName));

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, receiverName));

            Item item = giverCharacter.Bag.GetItem(itemName);
            
            giverCharacter.GiveCharacterItem(item,receiverCharacter);
            
            return string.Format(Constants.Constants.GiveCharacterItemCommand,giverName,receiverName,itemName);
        }

        public string GetStats()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var character in this.characterParty.OrderByDescending(c=>c.IsAlive).ThenByDescending(c=>c.Health))
            {
                sb.AppendLine(character.ToString().Trim());
            }
            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCharacter = this.characterParty.FirstOrDefault(c => c.Name == attackerName);
            if (attackerCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, attackerName));

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, receiverName));

            if(!(attackerCharacter is IAttackable))
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotAttack,attackerName));

            var attack = attackerCharacter as IAttackable;
            attack.Attack(receiverCharacter);

            StringBuilder sb=new StringBuilder();
            sb.Append($"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! ");
            sb.AppendLine(
                $"{receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!");
            if (receiverCharacter.IsAlive == false)
                sb.AppendLine($"{receiverName} is dead!");

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healerCharacter = this.characterParty.FirstOrDefault(c => c.Name == healerName);
            if (healerCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, healerName));

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
                throw new ArgumentException(string.Format(Constants.Constants.CharacterNotFound, receiverName));

            if (!(healerCharacter is IHealable))
                throw new ArgumentException(string.Format(Constants.Constants.CharackterNotHeal, healerName));

            var heal = healerCharacter as IHealable;
            heal.Heal(receiverCharacter);

            StringBuilder sb=new StringBuilder();
            
            return $"{healerName} heals {receiverName} for {healerCharacter.AbilityPoints}!" +
                   $" {receiverName} has {receiverCharacter.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb=new StringBuilder();
            foreach (var character in this.characterParty)
            {
                if (character.IsAlive == true)
                {
                    double healthBeforeRest = character.Health;
                    character.Rest();
                    sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
                }
                
            }

            int aliveCount = this.characterParty.Where(c => c.IsAlive == true).Count();
            if (aliveCount <= 1)
                this.lastSurvivorRound++;

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorRound > 1&&this.characterParty.Count(c=>c.IsAlive==true)<=1;
        }

    }
}