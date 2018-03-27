
    using System;

public class DateModifier
    {
        private string dateFirst;
        private string dateSecond;

        public DateModifier(string dateFirst, string dateSecond)
        {
            this.dateFirst = dateFirst;
            this.dateSecond = dateSecond;
        }

        public double CalculateDifference()
        {
            DateTime first=DateTime.ParseExact(this.dateFirst,"yyyy MM dd",System.Globalization.CultureInfo.InvariantCulture);
            DateTime second=DateTime.ParseExact(this.dateSecond,"yyyy MM dd",System.Globalization.CultureInfo.InvariantCulture);
            return Math.Abs((first - second).TotalDays);
        }

    }
