using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            List<Rectangle>rectangles=new List<Rectangle>();

            for (int i = 0; i < arr[0]; i++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                Rectangle rec=new Rectangle(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4]));
                rectangles.Add(rec);
            }

            for (int i = 0; i < arr[1]; i++)
            {
                var inputId = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                Rectangle first = rectangles.FirstOrDefault(r => r.Id == inputId[0]);
                Rectangle second = rectangles.FirstOrDefault(r => r.Id == inputId[1]);
                Console.WriteLine(first.IsHaveIntersetion(second).ToString().ToLower());
            }
        }
    }

