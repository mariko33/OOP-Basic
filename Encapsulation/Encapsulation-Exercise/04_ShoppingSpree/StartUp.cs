using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        PeopleList(people);
        ProductList(products);
        BuyProducts(people, products);

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }

    private static void BuyProducts(List<Person> people, List<Product> products)
    {
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var currInput = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string personName = currInput[0];
            string productName = currInput[1];
            var currPerson = people.FirstOrDefault(p => p.Name == personName);
            var currProduct = products.FirstOrDefault(p => p.Name == productName);
            if (currPerson.Money>=currProduct.Cost)
            {
                currPerson.AddProduct(currProduct);
                currPerson.Buy(currProduct);
                Console.WriteLine($"{personName} bought {productName}");
            }
            else
            {
                Console.WriteLine($"{personName} can't afford {productName}");
            }
        }
    }

    private static void ProductList(List<Product> products)
    {
        var inputProducts = Console.ReadLine().Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < inputProducts.Length - 1; i++)
        {
            try
            {
                Product currProduct = new Product(inputProducts[i], decimal.Parse(inputProducts[i + 1]));
                products.Add(currProduct);
                i++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }


    }

    private static void PeopleList(List<Person> people)
    {
        var inputPeople = Console.ReadLine().Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < inputPeople.Length - 1; i++)
        {
            try
            {
                Person person = new Person(inputPeople[i], decimal.Parse(inputPeople[i + 1]));
                people.Add(person);
                i++;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

        }

    }
}

