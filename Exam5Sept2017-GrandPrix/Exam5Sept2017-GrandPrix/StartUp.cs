using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main()
    {
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Start();
    }
}

