using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
{
    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            var inputArr = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Pokemon pokemon = new Pokemon(inputArr[1], inputArr[2], int.Parse(inputArr[3]));
            if (trainers.Any(t => t.Name == inputArr[0]))
            {
                trainers.FirstOrDefault(t => t.Name == inputArr[0]).AddPokemon(pokemon);
            }
            else
            {
                Trainer trainer = new Trainer(inputArr[0]);
                trainer.AddPokemon(pokemon);
                trainers.Add(trainer);
            }

        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            trainers.ForEach(t => t.CheckAddingBadge(command));
        }

        trainers.OrderByDescending(t => t.NumberOfBudges)
            .ToList()
            .ForEach(t => Console.WriteLine(t));
    }
}

