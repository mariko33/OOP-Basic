using System;
using System.Reflection;

namespace Problem1
{
    public class SturtUp
    {
        public static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }

}