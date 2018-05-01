using System;
using System.Linq;
using System.Reflection;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory  //CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }

        //public Character CreateCharacter(string[] args) //an ArgumentException with a message “Invalid character type "{type}"!”.
        //{

        // Faction faction = Enum.Parse<Faction>(args[0]);
        // string characterType = args[1];
        // string name = args[2];
        // if (faction==null)
        //    throw new ArgumentException($"Invalid faction \"{faction}\"!");



        // Type type = Assembly
        //     .GetCallingAssembly()
        //     .GetTypes()
        //     .FirstOrDefault(t => t.Name.Equals(characterType));

        // if (type == null)
        //     throw new ArgumentException("Invalid character type \"{characterType}\"!");

        // ConstructorInfo ctorInfo = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).First();

        //object[] ctorParams=new object[]
        //{
        //    name,
        //    faction
        //};

        // Character character = (Character)ctorInfo.Invoke(ctorParams);

        // return character;

        // }
    }
}