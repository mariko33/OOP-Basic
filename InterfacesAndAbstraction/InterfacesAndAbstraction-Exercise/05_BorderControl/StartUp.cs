using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;


class StartUp
    {
        static void Main()
        {
            //ex.7
            IList<IBuyer>members=new List<IBuyer>();
            
            int numbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers; i++)
            {
                var info = Console.ReadLine().Split();
                if (info.Length == 4) AddCitizen(info, members);
                else AddRebel(info, members);

            }

            string input;
            while ((input=Console.ReadLine())!="End")
            {
                if(members.Any(m=>(m as INameable).NameOrModel == input))
                {
                    IBuyer member = members.FirstOrDefault(m => (m as INameable).NameOrModel == input);
                    if(member!=null)member.BuyFood();
                }
            }

            Console.WriteLine(members.Sum(m=>m.Food));


            //ex.6
            //IList<IBirthdate>members=new List<IBirthdate>();


            //string input;
            //while ((input=Console.ReadLine())!="End")
            //{
            //    var inputInfo = input.Split();
            //    string command = inputInfo[0];
            //    if (command.ToLower()== "citizen") AddCitizen(inputInfo, members);
            //  //  else if(command.ToLower()== "robot") AddRobots(inputInfo, members);
            //    else if (command.ToLower() == "pet") AddPet(inputInfo, members);


            //}
            //ex. 5
            //string fakeId = Console.ReadLine();
            //members
            //    .Where(m=>m.Id.EndsWith(fakeId))
            //    .ToList()
            //    .ForEach(m=>Console.WriteLine(m.Id));

            //ex.6

            //string year = Console.ReadLine();
            //members
            //    .Where(m=>m.Birthdate.EndsWith(year))
            //    .ToList()
            //    .ForEach(m=>Console.WriteLine(m.Birthdate));
        }

        private static void AddRebel(string[] info, IList<IBuyer> members)
        {
            IBuyer rebel=new Rebel(info[0],int.Parse(info[1]),info[2]);
            members.Add(rebel);
        }

        private static void AddCitizen(string[] info, IList<IBuyer> members)
        {
            IBuyer citizen=new Citizen(info[0],int.Parse(info[1]),info[2],info[3]);
            members.Add(citizen);
        }

        //private static void AddPet(string[] inputInfo, IList<IBirthdate> members)
        //{
        //    string name = inputInfo[1];
        //    string birthdate = inputInfo[2];
        //    IBirthdate pet=new Pet(name,birthdate);
        //    members.Add(pet);
        //}

        //private static void AddCitizen (string[] inputInfo, IList<IBirthdate> members)
        //{
        //    string name = inputInfo[1];
        //    int age = int.Parse(inputInfo[2]);
        //    string id = inputInfo[3];
        //    string birthdate = inputInfo[4];
        //    IBirthdate citizen=new Citizen(name,age,id,birthdate);
        //    members.Add(citizen);
        //}

        //private static void AddRobots(string[] inputInfo, IList<ISociety> members)
        //{
        //    string model = inputInfo[1];
        //    string id = inputInfo[2];
        //    ISociety robot=new Robot(model,id);
        //    members.Add(robot);
        //}
    }

