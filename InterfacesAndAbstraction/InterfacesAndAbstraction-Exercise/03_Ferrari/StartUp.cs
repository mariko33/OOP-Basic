using System;


    class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            
            ICar ferrari=new Ferrari(name);
            Console.WriteLine(ferrari.ToString());
        }
    }

