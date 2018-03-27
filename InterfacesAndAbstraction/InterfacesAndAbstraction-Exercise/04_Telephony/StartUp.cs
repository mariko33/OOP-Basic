using System;


    class StartUp
    {
        static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();
            
            Smartphone phone=new Smartphone();

            PrintNumbers(phoneNumbers, phone);
            PrintSites(sites, phone);


        }

        private static void PrintSites(string[] sites, Smartphone phone)
        {
            foreach (var site in sites)
            {
                Console.WriteLine(phone.Browse(site));
            }
        }

        private static void PrintNumbers(string[] phoneNumbers, Smartphone phone)
        {
            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(phone.Call(number));
            }
        }
    }

