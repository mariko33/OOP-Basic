using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
    {
        static void Main()
        {
            List<Person>people=new List<Person>();

            string input;
            while ((input=Console.ReadLine())!="End")
            {
                var inputArr = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                if(!people.Any(p=>p.Name==inputArr[0]))people.Add(new Person(inputArr[0]));

                Person targetPerson = people.FirstOrDefault(p => p.Name == inputArr[0]);
                targetPerson.AddInfo(inputArr);

            }

            string resultPerson = Console.ReadLine();

            Console.Write(people.FirstOrDefault(p=>p.Name==resultPerson));

        }
        
    }

