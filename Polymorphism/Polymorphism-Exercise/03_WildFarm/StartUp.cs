using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var inputInfo = input.Split();
            string animalType = inputInfo[0];
            var animalInfo = inputInfo.Skip(1).ToArray();

            Animal animal = null;

            try
            {
                switch (animalType)
                {
                    case "Mouse":
                    case "Dog":
                        if (animalType == "Dog") animal = new Dog(animalInfo[0], double.Parse(animalInfo[1]), animalInfo[2]);
                        else animal = new Mouse(animalInfo[0], double.Parse(animalInfo[1]), animalInfo[2]);
                        break;
                    case "Hen":
                    case "Owl":
                        if (animalType == "Hen")
                            animal = new Hen(animalInfo[0], double.Parse(animalInfo[1]), double.Parse(animalInfo[2]));
                        else animal=new Owl(animalInfo[0], double.Parse(animalInfo[1]), double.Parse(animalInfo[2]));
                        break;
                    case "Cat":
                    case "Tiger":
                        if(animalType=="Cat")animal=new Cat(animalInfo[0],double.Parse(animalInfo[1]), animalInfo[2], animalInfo[3]);
                        else animal=new Tiger(animalInfo[0], double.Parse(animalInfo[1]), animalInfo[2], animalInfo[3]);
                        break;
                        default:
                            break;
                }

                animals.Add(animal);
                
                var foodInfo = Console.ReadLine().Split();

                string footType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                Food food = GetFood(footType,quantity);

                animal.ProduceSound();
                animal.Feed(food);
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
            
        }
        
        animals.ForEach(a=>Console.WriteLine(a));
    }

    private static Food GetFood(string footType, int quantity)
    {
        switch (footType)
        {
            case "Fruit":return new Fruit(quantity);
            case "Meat":return new Meat(quantity);
            case "Seeds":return new Seeds(quantity);
            default:return new Vegetable(quantity);
                
        }
    }
}

