using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
   public class SturtUp
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine().Replace(" ","-");
            string input2 = Console.ReadLine().Replace(" ", "-");
            DateTime fDate=DateTime.ParseExact(input1, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime sDate=DateTime.ParseExact(input2, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime biggerDate;
            DateTime smallerDate;
            if (fDate > sDate)
            {
                biggerDate = fDate;
                smallerDate = sDate;
            }
            else
            {
                biggerDate = sDate;
                smallerDate = fDate;
            }

            DateModifier difference=new DateModifier(smallerDate,biggerDate);
            Console.WriteLine(difference.GetDiferenceBetweenTwoDates());




        }
    }
}
