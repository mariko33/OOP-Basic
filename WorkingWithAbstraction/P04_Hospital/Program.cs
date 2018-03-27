using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<string[]>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Output")
            {
                var tokens = inputLine.Split(' ');
                var department = tokens[0];
                var doctor = string.Join(" ", tokens.Skip(1).Take(tokens.Length - 2).ToArray());
                var patient = tokens.Last();

                if (!departments.ContainsKey(department))
                    departments[department] = new List<string[]>();

                if (departments[department].Count < 60)
                    departments[department].Add(new[] { doctor, patient });
            }

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(' ');
                int room;
                if (tokens.Length == 1)
                    PrintPatientsInDepartment(departments, tokens[0]);
                else if (int.TryParse(tokens[1], out room))
                    PrintDepartmentRoom(departments, tokens[0], room);
                else
                    PrintDoctor(departments, string.Join(" ", tokens));
            }
        }

        private static void PrintDepartmentRoom(
            Dictionary<string, List<string[]>> departments,
            string departmentName,
            int room)
        {
            var roomPatients = departments[departmentName].Skip((room - 1) * 3).Take(3);
            foreach (var docPatient in roomPatients.OrderBy(pt => pt[1]))
                Console.WriteLine(docPatient[1]);
        }

        private static void PrintDoctor(Dictionary<string, List<string[]>> departments, string doctorName)
        {
            var resultPatients = new List<string>();
            foreach (var depart in departments)
                depart.Value.GroupBy(doc => doc[0]).Where(gr => gr.Key == doctorName).ToList()
                    .ForEach(r => r.ToList().ForEach(pt => resultPatients.Add(pt[1])));

            Console.WriteLine(string.Join(Environment.NewLine, resultPatients.OrderBy(x => x)));
        }

        private static void PrintPatientsInDepartment(
            Dictionary<string, List<string[]>> departments,
            string departmentName)
        {
            foreach (var patientList in departments[departmentName])
                Console.WriteLine(patientList[1]);
        }
    }
        }
    

