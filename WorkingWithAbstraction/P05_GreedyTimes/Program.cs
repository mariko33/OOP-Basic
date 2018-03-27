using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, Dictionary<string, long>>();
            items.Add("Gold", new Dictionary<string, long>());
            items.Add("Gem", new Dictionary<string, long>());
            items.Add("Cash", new Dictionary<string, long>());

            long total = 0;
            var maxCapacity = long.Parse(Console.ReadLine());
            var sequenceOfItemPairs = Console.ReadLine().Split(
                " ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < sequenceOfItemPairs.Length; i += 2)
            {
                var item = sequenceOfItemPairs[i].ToLower();
                var amount = long.Parse(sequenceOfItemPairs[i + 1]);
                if (item.Length == 3)
                {
                    if (total + amount <= maxCapacity
                        && items["Cash"].Values.Sum() + amount <= items["Gem"].Values.Sum())
                    {
                        if (!items["Cash"].ContainsKey(sequenceOfItemPairs[i]))
                            items["Cash"].Add(sequenceOfItemPairs[i], 0);
                        items["Cash"][sequenceOfItemPairs[i]] += amount;
                        total += amount;
                    }
                }
                else if (item.EndsWith("gem"))
                {
                    if (total + amount <= maxCapacity
                        && items["Gem"].Values.Sum() + amount <= items["Gold"].Values.Sum())
                    {
                        if (!items["Gem"].ContainsKey(sequenceOfItemPairs[i]))
                            items["Gem"].Add(sequenceOfItemPairs[i], 0);
                        items["Gem"][sequenceOfItemPairs[i]] += amount;
                        total += amount;
                    }
                }
                else if (item.Equals("gold"))
                {
                    if (total + amount <= maxCapacity)
                    {
                        if (!items["Gold"].ContainsKey(sequenceOfItemPairs[i]))
                            items["Gold"].Add(sequenceOfItemPairs[i], 0);
                        items["Gold"][sequenceOfItemPairs[i]] += amount;
                        total += amount;
                    }
                }
            }

            PrintResults(items);
        }

        private static void PrintResults(Dictionary<string, Dictionary<string, long>> items)
        {
            foreach (var item in items.Where(x => x.Value.Keys.Count > 0).OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var keyValuePair in item.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    Console.WriteLine($"##{keyValuePair.Key} - {keyValuePair.Value}");
            }
        }
    }
}