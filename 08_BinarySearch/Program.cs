// https://leetcode.com/problems/binary-search/
// 704. Binary Search

using static System.Net.Mime.MediaTypeNames;

namespace _08_BinarySearch
{
    public class Solution
    {
        public int Search(int[] nums, int target)  // 133ms
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;
                if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
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
                    new List<int> { -1, 0, 3, 5, 9, 12 },
                    new List<int> { 9 },
                    new List<int> { 4 }
                },
                new List<List<int>>
                {
                    new List<int> { -1, 0, 3, 5, 9, 12 },
                    new List<int> { 2 },
                    new List<int> { -1 }
                },
                new List<List<int>>
                {
                    new List<int> { 5 },
                    new List<int> { 5 },
                    new List<int> { 0 }
                }
            };

            Solution s = new Solution();

            foreach (var test in tests)
            {
                int index = s.Search(test[0].ToArray(), test[1].First());

                if (index == test[2].First())
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine($"Error: Expected { test[2].First() } but got { index } for input {string.Join(", ", test[0]) }");
                }
            }

            Console.WriteLine("\nProcessing complete!");
        }
    }
}