// https://leetcode.com/problems/two-sum/
// 1. TwoSum

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] output = new int[2];
        Dictionary<int, int> previousValue = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (previousValue.ContainsKey(diff))
            {
                output[0] = previousValue[diff];
                output[1] = i;
                return output;
            }
            else
            {
                previousValue[nums[i]] = i;
            }
        }
        return output;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<int[][]> tests = new List<int[][]>
            {
                new int[][] { new int[] { 2, 7, 11, 15 }, new int[] { 9 }, new int[] { 0, 1 } },
                new int[][] { new int[] { 3, 2, 4 }, new int[] { 6 }, new int[] { 1, 2 } },
                new int[][] { new int[] { 3, 3 }, new int[] { 6 }, new int[] { 0, 1 } }
            };

        Solution sol = new();
        for (int i = 0; i < tests.Count; i++)
        {
            //var num = tests[i][1][0];
            int[] output = sol.TwoSum(tests[i][0], tests[i][1][0]);
            if (output.SequenceEqual(tests[i][2]))
            {
                foreach (var value in output)
                    Console.Write($"{value} ");
                Console.WriteLine();
            }
            else
            {
                Console.Write($"Error: Expected [");
                foreach (var value in tests[i][2])
                {
                    Console.Write($"{value} ");
                }
                Console.Write("] but got [");
                foreach (var value in output)
                {
                    Console.Write($"{value} ");
                }
                Console.Write("] instead for [");
                foreach (var value in tests[i][0])
                {
                    Console.Write($"{value} ");
                }
                Console.WriteLine("]");
            }
        }
        Console.WriteLine("Processing complete!");
    }
}


