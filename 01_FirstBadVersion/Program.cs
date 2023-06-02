// https://leetcode.com/problems/first-bad-version/
// 278. First Bad Version
// Binary Search
using static System.Net.Mime.MediaTypeNames;

namespace _01_FirstBadVersion
{
    internal class Program
    {
        /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

        public class Solution // : VersionControl
        {
            int badVersion;
            public Solution(int n) { badVersion = n; }

            public int FirstBadVersion(int n)       // 29ms
            {
                int low = 0;
                int high = n;
                int first = -1;

                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    bool result = this.IsBadVersion(mid);

                    if (result)
                    {
                        first = mid;
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                return first;
            }

            bool IsBadVersion(int version)
            {
                return version == badVersion;
            }
        }

        static void Main(string[] args)
        {
            List<List<int>> tests = new()
            {
                new List<int> {5, 4, 4},
                new List<int> {1, 1, 1 }
            };

            Solution s;

            foreach (var test in tests)
            {
                s = new Solution(test[1]);
                var output = s.FirstBadVersion(test[0]);

                if (output == test[2])
                    Console.WriteLine(output);
                else
                    Console.WriteLine($"Error: Expected { test[2] } but got { output } instead");
            }

            Console.WriteLine("\nProcessing complete!");
        }
    }
}