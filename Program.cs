using System.Text;

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
                    case "-insertion":
                        InsertionSort(numbers);
                        break;
                    default:
                        Console.WriteLine("Invalid sort type provided");
                        break;
                };
            }
            
        }
        private static void BubbleSort(List<int> numbers)
        {
            Console.SetCursorPosition(Width/2, 0);
            Console.WriteLine("Bubble Sort");
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
                    VerticalRenderOnConsole(numbers, false);
                }
                if (madeSwap == false)
                {
                    break;
                }
            }
            VerticalRenderOnConsole(numbers, true);
        }
        private static void InsertionSort(List<int> numbers)
        {
            Console.SetCursorPosition(Width/2, 0);
            Console.WriteLine("Insert Sort");
            int length = numbers.Count - 1;
            for(int i = 1; i <= length; i++)
            {
                for (int j = i; j > 0 && numbers[j - 1] > numbers[j]; j--)
                {
                    (numbers[j],numbers[j-1]) = (numbers[j-1], numbers[j]);
                    VerticalRenderOnConsole(numbers, false);
                }
            }
            VerticalRenderOnConsole(numbers, true);
        }
        private static void HorizontalRenderOnConsole(List<int> numbers)
        {
            int startingX = Width/2 - Height+2;
            int startingY = Height-2;
        }
        private static void VerticalRenderOnConsole(List<int> numbers, bool completed)
        {
            Console.SetCursorPosition(0, 1);
            
            for (int i = 0; i < numbers.Count; i++)
            {
                ClearCurrentLine();
                Console.Write($"{numbers[i],3} ");
                if (completed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"{new string('⏣', numbers[i])} \n");
                Console.ResetColor();
            }
            Thread.Sleep(100);
        }
        private static void ClearCurrentLine()
        {
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, currentLine);
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