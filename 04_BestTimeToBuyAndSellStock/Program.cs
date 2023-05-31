using static System.Net.Mime.MediaTypeNames;

namespace _04_BestTimeToBuyAndSellStock
{
    public class Solution
    {
        public int MaxProfit(int[] prices)  // 223ms
        {
            int res = 0;

            int lowest = prices[0];

            foreach (int price in prices)
            {
                if (price < lowest)
                    lowest = price;
                res = Math.Max(res, price - lowest);
            }
            return res;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<List<int>>> tests = new()
            {
                new List<List<int>>
                {
                    new List<int> { 7, 1, 5, 3, 6, 4 },
                    new List<int> { 5 }
                },
                new List<List<int>>
                {
                    new List<int> { 7, 6, 4, 3, 1 },
                    new List<int> { 0 }
                }
            };

            Solution sol = new();

            foreach (var test in tests)
            {
                //var val = test[0].ToArray();
                var output = sol.MaxProfit(test[0].ToArray());

                if (output == test[1].First())
                {
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine($"Error: expected {test[1].First() } but got { output } instead");
                }


            }

            Console.WriteLine("Processing complete!");
        }
    }
}