using System;

public class Animal
{
    private int age;

    private string gender;

    private string name;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (value < 0 || string.IsNullOrEmpty(value.ToString())) throw new ArgumentException("Invalid input!");
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (!value.ToLower().Equals("male") && !value.ToLower().Equals("female"))
                throw new ArgumentException("Invalid input!");
            this.gender = value;
        }
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid input!");
            this.name = value;
        }
    }

    public virtual void ProduceSound()
    {
    }
}