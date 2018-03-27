using System;

public class Program
{
    static void Main()
    {
        //Family family = new Family();

        //int countOfPeople = int.Parse(Console.ReadLine());
        // ex.3
        //for (int i = 0; i < countOfPeople; i++)
        //{
        //    var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        //    Person person=new Person(int.Parse(input[1]),input[0]);
        //    family.AddMember(person);
        //}

        //Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");


        //ex.4
        //for (int i = 0; i < countOfPeople; i++)
        //{
        //    var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //    Person person = new Person(int.Parse(input[1]), input[0]);
        //    family.AddMember(person);
        //}

        //family.GetPersonByAge().ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        
        //ex.5

        string first = Console.ReadLine();
        string second = Console.ReadLine();
        DateModifier mod=new DateModifier(first,second);
           
        Console.WriteLine(mod.CalculateDifference());
    }
}

