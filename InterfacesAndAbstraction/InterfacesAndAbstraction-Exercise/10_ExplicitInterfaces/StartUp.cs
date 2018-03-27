using System;


class StartUp
{
    static void Main()
    {
        string input;
        while ((input=Console.ReadLine())!="End")
        {
            var inputInfo = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string name = inputInfo[0];
            string country = inputInfo[1];
            int age = int.Parse(inputInfo[2]);
            Citizen citizen=new Citizen(name,country,age);
            IPerson person = citizen;
            IResident resident = citizen;
            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());

        }

    }
}

