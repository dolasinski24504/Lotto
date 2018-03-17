using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotto_3._0
{
    class Program
    {
        static void Main()
        {
            var numbers = 2400;
            var first = 1;
            var last = 50;
            var generated = GeneratingList(numbers, first, last);
            
            var uniqeItems = generated
                .GroupBy(x => x)
                .ToDictionary(group => group.Key, group => group.Count());

            Console.WriteLine($"Number of items is: {generated.Count}\nNumber of unique items is: {uniqeItems.Count}");

            foreach (var item in uniqeItems)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            var sixToChoose = uniqeItems
                .OrderByDescending(item => item.Value)
                .Take(6);

            Console.WriteLine("\nNumbers to choose is: \n");
            foreach (var item in sixToChoose)
            {
                Console.WriteLine(item.Key);
            }

        }

        private static List<int> GeneratingList(int number, int first, int last)
        {
            var generated = new List<int>();
            var random = new Random();

            for (int i = 0; i < number; i++)
            {
                var num = random.Next(first, last);
                generated.Add(num);
            }
            return generated;
        }

    }
}