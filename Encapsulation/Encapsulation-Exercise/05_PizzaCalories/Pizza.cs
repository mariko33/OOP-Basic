using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
        this.NumberOfToppings = 0;
    }

    public Pizza()
    {
        this.toppings=new List<Topping>();
        this.NumberOfToppings = 0;
    }

   
    


    public int NumberOfToppings
    {
        get => this.numberOfToppings;
        set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.numberOfToppings = value;
        }
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value)||value.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public List<Topping> Toppings
    {
        get => this.toppings;
        
    }

    public double TotalCalories=> this.GetTotalCalories();
   

    public Dough Dough
    {
        get => this.dough;
        set { this.dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    private double GetTotalCalories()
    {
        return this.Dough.Calories + this.toppings.Sum(t => t.Calories);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
    }
}

