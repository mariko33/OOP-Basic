using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;


class StartUp
{

    private static IList<ISoldier> army;

    public static void Main()
    {
        army = new List<ISoldier>();
        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var args = input.Split();
            var soldierType = args[0];
            var id = int.Parse(args[1]);
            var firstName = args[2];
            var lastName = args[3];

            switch (soldierType)
            {
                case "Private":

                    army.Add(new Private(id, firstName, lastName, double.Parse(args[4])));
                    break;

                case "LeutenantGeneral":

                    var privates = GetPrivates(args.Skip(5).ToList());
                    army.Add(new LeutenantGeneral(id, firstName, lastName, double.Parse(args[4]), privates));
                    break;

                case "Engineer":

                    var corpse = args[5];
                    if (!IsCorpseValid(corpse)) break;

                    var repairs = GetRepairs(args.Skip(6).ToList());
                    army.Add(new Engineer(id, firstName, lastName, double.Parse(args[4]), corpse, repairs));
                    break;

                case "Commando":

                    corpse = args[5];
                    if (!IsCorpseValid(corpse)) break;

                    var missions = GetMissions(args.Skip(6).ToList());
                    army.Add(new Commando(id, firstName, lastName, double.Parse(args[4]), corpse, missions));
                    break;

                case "Spy":

                    army.Add(new Spy(id, firstName, lastName, int.Parse(args[4])));
                    break;
            }

            input = Console.ReadLine();
        }

        foreach (var soldier in army) Console.WriteLine(soldier);
    }

    private static List<IMission> GetMissions(List<string> missionsInfo)
    {
        List<IMission> missions = new List<IMission>();

        for (var i = 0; i < missionsInfo.Count - 1; i += 2)
        {
            var name = missionsInfo[i];
            var state = missionsInfo[i + 1];

            if (!state.Equals("inProgress") && !state.Equals("Finished")) continue;

            missions.Add(new Mission(name, state));
        }

        return missions;
    }

    private static List<IPrivate> GetPrivates(List<string> privatesIDs)
    {
        List<IPrivate> privates = new List<IPrivate>();

        foreach (var id in privatesIDs) privates.Add((IPrivate) army.FirstOrDefault(s => s.Id.Equals(int.Parse(id))));

        return privates;
    }

    private static List<IRepair> GetRepairs(List<string> repairsInfo)
    {
        List<IRepair> repairs = new List<IRepair>();

        for (var i = 0; i < repairsInfo.Count - 1; i += 2)
        {
            var repairedPart = repairsInfo[i];
            var hours = int.Parse(repairsInfo[i + 1]);

            IRepair currentRepair = new Repair(repairedPart, hours);
            repairs.Add(currentRepair);
        }

        return repairs;
    }

    private static bool IsCorpseValid(string corpse)
    {
        string[] validCorpses = { "Airforces", "Marines" };
        return validCorpses.Contains(corpse);
    }
}
    
    
    
    
    
    
    
    //public static IList<ISoldier> soldiers = new List<ISoldier>();
    //static void Main()
    //{
    //    string input;
    //    while ((input = Console.ReadLine()) != "End")
    //    {
    //        var inputInfo = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    //        string command = inputInfo[0];
    //        AddSoldier(command, inputInfo);
    //    }
        
    //    foreach (var soldier in soldiers)
    //    {
    //        Console.WriteLine(soldier.ToString());
    //    }
    //}

    //private static void AddSoldier(string command, string[] inputInfo)
    //{
    //    switch (command)
    //    {
    //        case "Private":
    //            {
    //                int id = int.Parse(inputInfo[1]);
    //                string fName = inputInfo[2];
    //                string lName = inputInfo[3];
    //                double salary = double.Parse(inputInfo[4]);
    //                soldiers.Add(new Private(id, fName, lName, salary));
    //                break;
    //            }
    //        case "LeutenantGeneral":
    //            {
    //                int id = int.Parse(inputInfo[1]);
    //                string fName = inputInfo[2];
    //                string lName = inputInfo[3];
    //                double salary = double.Parse(inputInfo[4]);
    //                List<IPrivate>privateList=new List<IPrivate>();
    //                for (int i = 4; i < inputInfo.Length; i++)
    //                {
    //                    int idPrivate = int.Parse(inputInfo[i]);
    //                    if (soldiers.Any(s => s.Id == idPrivate))
    //                    {
    //                        IPrivate currPrivate = (IPrivate)soldiers.FirstOrDefault(s => s.Id == idPrivate);
    //                        privateList.Add(currPrivate);
    //                    }
                        
                        
    //                }
    //                LeutenantGeneral lg=new LeutenantGeneral(id,fName,lName,salary,privateList);
    //                soldiers.Add(lg);
    //                break;
    //            }
    //        case "Engineer":
    //        {
    //            try
    //            {
    //                int id = int.Parse(inputInfo[1]);
    //                string fName = inputInfo[2];
    //                string lName = inputInfo[3];
    //                double salary = double.Parse(inputInfo[4]);
    //                string corps = inputInfo[5];
    //                List<IRepair>repairs=new List<IRepair>();
    //                for (int i = 6; i < inputInfo.Length; i++)
    //                {
    //                    IRepair currRepair=new Repair(inputInfo[i],int.Parse(inputInfo[i+1]));
    //                    repairs.Add(currRepair);
    //                    i++;

    //                }
                    
    //                Engineer eng=new Engineer(id,fName,lName,salary,corps,repairs);
    //                soldiers.Add(eng);

    //            }
    //                catch (Exception e)
    //                {

    //                }
    //                break;
    //        }
    //        case "Commando":
    //        {
    //            int id = int.Parse(inputInfo[1]);
    //            string fName = inputInfo[2];
    //            string lName = inputInfo[3];
    //            double salary = double.Parse(inputInfo[4]);
    //            string corps = inputInfo[5];
    //                IList<IMission>missions=new List<IMission>();
                
    //                for (int i = 6; i < inputInfo.Length; i++)
    //            {
    //                if (inputInfo[i+1]== "inProgress"||inputInfo[i+1]== "Finished")
    //                {
    //                    Mission currMission=new Mission(inputInfo[i],inputInfo[i+1]);
    //                    missions.Add(currMission);
    //                    //commando.AddMission(currMission);
                        
    //                }
                    
    //                i++;
    //            }

    //                Commando commando = new Commando(id, fName, lName, salary, corps, missions);

    //                soldiers.Add(commando);
    //            break;
    //            }
    //        case "Spy":
    //        {
    //            int id = int.Parse(inputInfo[1]);
    //            string fName = inputInfo[2];
    //            string lName = inputInfo[3];
    //            int codeNumber = int.Parse(inputInfo[4]);
    //            Spy spy=new Spy(id,fName,lName,codeNumber);
    //            soldiers.Add(spy);
    //            break;
    //        }



    //    }
    //}


