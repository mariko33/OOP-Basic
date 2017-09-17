using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
   public class SturtUp
    {
        static void Main(string[] args)
        {
            //System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            //customCulture.NumberFormat.NumberDecimalSeparator = ".";

            var num = int.Parse(Console.ReadLine());
            var carInfo=new List<Car>();
            for (int i = 0; i < num; i++)
            {
                var cmdArg = Console.ReadLine().Split(' ');
                var car=new Car(cmdArg[0],int.Parse(cmdArg[1]),double.Parse(cmdArg[2]));
                carInfo.Add(car);
            }

            
            while (Console.ReadLine()!= "End")
            {

                var distanceInfo = Console.ReadLine().Split(' ');
                if (distanceInfo.Length==2)
                {
                    var carWanted = carInfo.FirstOrDefault(car => car.Model == distanceInfo[1]);
                    if (carWanted.CanCarMoveDistance(double.Parse(distanceInfo[2])))
                    {
                        carWanted.DistanceTraveled += double.Parse(distanceInfo[2]);
                        carWanted.FuelAmount -= (carWanted.FuelConsumptionFor1km * double.Parse(distanceInfo[2]));
                    }       
                    
                }
                else
                {
                    break;
                }
                
            }
            
            carInfo
                .ForEach(c=>Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}"));
        }
    }
}
