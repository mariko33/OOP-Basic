
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
                
                
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public void AddProduct(Product product)
    {
        this.bagOfProducts.Add(product);

    }

    public void Buy(decimal price)
    {
        this.Money -= price;
    }

    public override string ToString()
    {
        if (this.bagOfProducts.Count > 0) return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p=>p.Name))}";
        return $"{this.Name} – Nothing bought";
    }
}
