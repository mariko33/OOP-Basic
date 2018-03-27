using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
{
    static void Main()
    {
        var people = new List<Person>();
        var storePeople = new List<string>();

        var person = Console.ReadLine();

        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var info = input.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (info.Length == 1)
            {
                var tokens = input.Split();
                var name = tokens[0] + " " + tokens[1];
                var birthday = tokens[2];

                var newPerson = new Person();
                newPerson.FullName = name;
                newPerson.Birthday = birthday;
                people.Add(newPerson);
            }
            else
            {
                storePeople.Add(input);
            }

            input = Console.ReadLine();
        }

        foreach (var storePerson in storePeople)
        {
            var parent = new Person();
            var child = new Person();

            var info = storePerson.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (info[0].Contains('/') && info[1].Contains('/'))
            {
                var parentBirhtday = info[0];
                var childBirthday = info[1];

                parent = people.First(p => p.Birthday.Equals(parentBirhtday));
                child = people.First(p => p.Birthday.Equals(childBirthday));
            }
            else if (info[0].Contains('/') && !info[1].Contains('/'))
            {
                var parentBirday = info[0];
                var childName = info[1];

                parent = people.First(p => p.Birthday.Equals(parentBirday));
                child = people.First(p => p.FullName.Equals(childName));
            }
            else if (!info[0].Contains('/') && info[1].Contains('/'))
            {
                var parentName = info[0];
                var childBirthday = info[1];

                child = people.First(p => p.Birthday.Equals(childBirthday));
                parent = people.First(p => p.FullName.Equals(parentName));
            }
            else
            {
                var parentName = info[0];
                var childName = info[1];

                parent = people.First(p => p.FullName.Equals(parentName));
                child = people.First(p => p.FullName.Equals(childName));
            }

            if (!parent.Children.Contains(child)) parent.Children.Add(child);

            if (!child.Parents.Contains(parent)) child.Parents.Add(parent);
        }

        var wantedPerson = new Person();

        if (person.Contains('/')) wantedPerson = people.First(p => p.Birthday.Equals(person));
        else wantedPerson = people.First(p => p.FullName.Equals(person));

        Console.WriteLine(wantedPerson);
        Console.WriteLine("Parents:");
        wantedPerson.Parents.ForEach(p => Console.WriteLine(p));
        Console.WriteLine("Children:");
        wantedPerson.Children.ForEach(p => Console.WriteLine(p));
    }
}


