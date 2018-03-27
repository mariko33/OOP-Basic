using System;
using System.Collections.Generic;


class StartUp
    {
        static void Main()
        {
            List<Animal>animals=new List<Animal>();
            string input=String.Empty;

            try
            {
              GetAnimal(input,animals);
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }


        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }


    }

        private static void GetAnimal(string input, List<Animal>animals)
        {
        while ((input = Console.ReadLine()) != "Beast!")
        {
            string animalType = input.ToLower();
            var tokens = Console.ReadLine().Split(new []{" "},StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (animalType)
                {
                    case "dog":
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(dog);
                        break;
                    case "frog":
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(frog);
                        break;
                    case "cat":
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(cat);
                        break;
                    case "kitten":
                        Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        animals.Add(kitten);
                        break;
                    case "tomcat":
                        Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        animals.Add(tomcat);
                        break;
                    default:throw new ArgumentException("Invalid input!");
                            
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
           

        }
    }
    }

