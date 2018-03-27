using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
    {
        static void Main()
        {
            List<Cat>cats=new List<Cat>();

            string input;
            while ((input=Console.ReadLine())!="End")
            {
                var inputArr = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                string breed = inputArr[0];
                switch (breed)
                {
                    case "Siamese":
                    {
                        var cat=new Siamese(inputArr[1],int.Parse(inputArr[2]));
                        cats.Add(cat);
                        break;
                    }
                    case "Cymric":
                    {
                        var cat=new Cymric(inputArr[1],double.Parse(inputArr[2]));
                        cats.Add(cat);
                        break;
                    }
                    case "StreetExtraordinaire":
                    {
                        var cat=new StreetExtraordinaire(inputArr[1],int.Parse(inputArr[2]));
                        cats.Add(cat);
                        break;
                    }
                }
            }

            string targetCat = Console.ReadLine();
            Console.WriteLine(cats.FirstOrDefault(c=>c.Name==targetCat));
        }
    }

