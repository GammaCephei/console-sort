using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace ConsoleSort
{
    public class ConsoleSort
    {
        private static readonly int Width = Console.WindowWidth;
        private static readonly int Height = Console.WindowHeight;
        
        public static void Main(string[] args)
        {
            Console.Clear();
            
            List<int> numbers = Enumerable.Range(1, Height-2).ToList();
            numbers = Shuffle(numbers);

            Console.WriteLine($"Starting Order: {ListToString(numbers)}");
            
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]) )
            {
                var sortType = args.FirstOrDefault();
                switch (sortType)
                {
                    case "-bubble":
                        BubbleSort(numbers);
                        break;
                    default:
                        Console.WriteLine("Invalid sort type provided");
                        break;
                };
                Console.SetCursorPosition(Width/2, 1);
                Console.WriteLine("Bubbling");
            }
            
        }
        private static void BubbleSort(List<int> numbers)
        {
            int length = numbers.Count - 1;
            for(int i = 0; i < length; i++)
            {
                bool madeSwap = false;
                for (int j = 0; j < length - i; j++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        (numbers[j],numbers[j+1]) = (numbers[j+1], numbers[j]);
                        madeSwap = true;
                    }
                }
                if (madeSwap == false)
                {
                    break;
                }
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Current Order: {ListToString(numbers)}");
            }
        }

        private static void RenderOnConsole(List<int> numbers)
        {
            int startingX = Width / 3;
            int startingY = Height;

        }
        private static List<int> Shuffle(List<int> numbers)
        {
            Random random = new Random();
            int length = numbers.Count - 1;
            for (int i = length; i >= 1; i--)
            {
                int j = random.Next(0, i + 1);
                (numbers[i],numbers[j]) = (numbers[j], numbers[i]);
            }

            return numbers;
        }

        private static string ListToString(List<int> numbers)
        {
            return string.Join(",", numbers);
        }
    }
}