
using System;
using System.Text;

public class Animal:IProduceSound
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (value<0||string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentException("Invalid input!");
            }
            
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (!value.ToLower().Equals("male")&&!value.ToLower().Equals("female"))
            {
                throw new ArgumentException("Invalid input!");
            }
            
            this.gender = value;
        }
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .Append(ProduceSound());
        return sb.ToString();
    }

    public virtual string ProduceSound()
    {
        return "";
    }
}
