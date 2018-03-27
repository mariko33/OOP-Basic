using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
    {
        
        public static void Main()

        {

            var team = new Team("Team 1");
            var numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                var args = Console.ReadLine().Split();
                var person = new Person(args[0], args[1], int.Parse(args[2]), decimal.Parse(args[3]));
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());

    }
    
    }

