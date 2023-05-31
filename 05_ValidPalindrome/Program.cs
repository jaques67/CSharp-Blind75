// https://leetcode.com/problems/valid-palindrome/
// 125. Valid Palindrome
// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and
// removing all non-alphanumeric characters, it reads the same forward and backward.
// Alphanumeric characters include letters and numbers.

using static System.Net.Mime.MediaTypeNames;

namespace _05_ValidPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)  // 79ms
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (Char.ToLower(s[left]) != Char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<List<object>>> tests = new()
            {
                new List<List<object>>  // test[0]
                {
                    new List<object> { "A man, a plan, a canal: Panama" },  // test[0][0]
                    new List<object> { true }
                },
                new List<List<object>>
                {
                    new List<object> { "race a car" },
                    new List<object> { false }
                }
            };

            Solution sol = new();

            foreach (var test in tests)
            {
                var output = sol.IsPalindrome(test[0][0].ToString());
                if (output == (bool)test[1].First())
                {
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine($"Error: Expected {test[1][0].ToString()} but got {output} instead.");
                }
            }


            Console.WriteLine("\nProcessing complete!");
        }
    }
}