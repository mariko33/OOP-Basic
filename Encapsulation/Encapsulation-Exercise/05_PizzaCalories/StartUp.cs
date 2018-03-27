using System;
using System.Collections.Generic;


class StartUp
{
    public static Pizza pizza = new Pizza();

    public static void Main()
    {
        string info;
        while (!(info = Console.ReadLine()).Equals("END"))
        {

            var input = info.Split();
            if (input[0].ToLower().Equals("pizza")) TryMakePizza(input);
            else if (input[0].ToLower().Equals("dough"))
                TryMakeDough(input);
            else if (input[0].ToLower().Equals("topping"))
                ReadToppings(input);
            try
            {
                pizza.NumberOfToppings++;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        PrintResults();
    }

    private static void PrintResults()
    {
        if (pizza.Name == null)
        {
            Console.WriteLine(pizza.Dough.ToString());
            pizza.Toppings.ForEach(t => Console.WriteLine(t.ToString()));
        }
        else
        {
            Console.WriteLine(pizza.ToString());
        }
    }

    private static void ReadToppings(string[] input)
    {
        try
        {
            pizza.AddTopping(new Topping(input[1], double.Parse(input[2])));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }

    private static void TryMakeDough(string[] input)
    {
        try
        {
            pizza.Dough = new Dough(input[1], input[2], double.Parse(input[3]));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }

    private static void TryMakePizza(string[] input)
    {
        try
        {
            pizza = new Pizza(input[1]);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }
}


