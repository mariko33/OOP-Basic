using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
   public class DateModifier
   {
       private DateTime smallerDate;
       private DateTime biggerDate;

       public DateModifier(DateTime smallerDate, DateTime biggerDate)
       {
           this.SmallerDate = smallerDate;
           this.BiggerDate = biggerDate;
       }
       public DateTime SmallerDate
        { get { return this.smallerDate; }
            set { this.smallerDate = value; }
        }
       public DateTime BiggerDate
        { get { return this.biggerDate; }
            set { this.biggerDate = value; } }

       public double GetDiferenceBetweenTwoDates()
       {
           return (this.BiggerDate - this.SmallerDate).TotalDays;
       }
   }
}
