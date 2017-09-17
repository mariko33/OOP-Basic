using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
   public class SturtUp
    {
       public static void Main(string[] args)
       {
            var family = new Family();
            var numb = Console.ReadLine();

            for (int i = 0; i < int.Parse(numb); i++)
            {
                var cmdArgs = Console.ReadLine().Split(' ');

                var person = new Person()
                {
                    Name = cmdArgs[0],
                    Age = int.Parse(cmdArgs[1])

                };

                family.AddMember(person);

            }
           var peopleOverThirty = family.People.Where(p => p.Age > 30).OrderBy(p => p.Name);
           foreach (var person in peopleOverThirty)
           {
               Console.WriteLine($"{person.Name} - {person.Age}");
           }
            
        }
    }
}
