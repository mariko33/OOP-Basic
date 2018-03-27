using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        string input;
        var animals = new List<Animal>();
        while (!(input = Console.ReadLine()).Equals("Beast!"))
            try
            {
                var animalInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var animal = CreateAnimal(
                    input.ToLower(),
                    animalInfo[0],
                    int.Parse(animalInfo[1]),
                    animalInfo[2]);

                animals.Add(animal);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            animal.ProduceSound();
        }
    }

    private static Animal CreateAnimal(string kind, string name, int age, string gender)
    {
        if (kind.Equals("frog"))
            return new Frog(name, age, gender);
        if (kind.Equals("dog"))
            return new Dog(name, age, gender);
        if (kind.Equals("cat"))
            return new Cat(name, age, gender);
        if (kind.Equals("kitten"))
            return new Kitten(name, age);
        if (kind.Equals("tomcat"))
            return new Tomcat(name, age);
        throw new ArgumentException("Invalid input!");
    }
}


