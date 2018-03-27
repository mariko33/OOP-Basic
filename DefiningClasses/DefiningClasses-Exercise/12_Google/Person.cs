
using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Child> children;
    private List<Pokemon> pokemons;

    public Person(string name)
    {
        this.Name = name;
        this.parents = new List<Parent>();
        this.children = new List<Child>();
        this.pokemons = new List<Pokemon>();
    }

    public string Name { get => this.name; set => this.name = value; }
    public Company Company { get => this.company; set => this.company = value; }
    public Car Car { get => this.car; set => this.car = value; }
    public List<Parent> Parents { get => this.parents; set => this.parents = value; }
    public List<Child> Children { get => this.children; set => this.children = value; }
    public List<Pokemon> Pokemons { get => this.pokemons; set => this.pokemons = value; }


    public void AddInfo(string[] inputArr)
    {
        switch (inputArr[1])
        {
            case "company":Company companyCurr=new Company(inputArr[2],inputArr[3],decimal.Parse(inputArr[4]));
                this.company = companyCurr;
                break;
            case "car":Car carCurr=new Car(inputArr[2],int.Parse(inputArr[3]));
                this.car = carCurr;
                break;
            case "pokemon": this.pokemons.Add(new Pokemon(inputArr[2],inputArr[3]));
                break;
            case "parents":this.parents.Add(new Parent(inputArr[2],inputArr[3]));
                break;
            case "children":this.children.Add(new Child(inputArr[2],inputArr[3]));
                break;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.Name}");
        builder.AppendLine($"Company:");
        if(this.company!=null) builder.AppendLine($"{this.company}");

        builder.AppendLine("Car:");
        if(this.car!=null)builder.AppendLine($"{this.car}");
        builder.AppendLine("Pokemon:");
        if(this.pokemons.Count!=0)this.pokemons
            .ForEach(p => builder.AppendLine(p.ToString()));
        builder.AppendLine("Parents:");
        if(this.parents.Count!=0)this.parents
            .ForEach(p => builder.AppendLine(p.ToString()));
        builder.AppendLine("Children:");
        if(this.children.Count!=0)this.children
            .ForEach(c => builder.AppendLine(c.ToString()));

        return builder.ToString();
    }


}
