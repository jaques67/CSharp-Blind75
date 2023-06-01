// https://leetcode.com/problems/valid-anagram/
// 242. Valid Anagram
// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
// typically using all the original letters exactly once.
using static System.Net.Mime.MediaTypeNames;

namespace _07_ValidAnagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)  // 66ms
        {
            if (s.Length != t.Length) return false;
            int alphabetLength = 26;
            int[] sLetters = new int[alphabetLength];
            int[] tLetters = new int[alphabetLength];
            int a = (int)'a';

            for (int i = 0; i < s.Length; i++)
            {
                sLetters[(int)s[i] - a]++;
                tLetters[(int)t[i] - a]++;
            }

            return sLetters.SequenceEqual(tLetters);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<object>> tests = new List<List<object>>
            {
                new List<object> { "anagram", "nagaram", true },
                new List<object> { "rat", "car", false }
            };

            Solution solution = new Solution();

            foreach (var test in tests)
            {
                var output = solution.IsAnagram(test[0].ToString(), test[1].ToString());

                if (output == (bool)test[2])
                    Console.WriteLine(output);
                else
                {
                    Console.WriteLine($"Error: Expected { (bool)test[2] } but got { output } instead for " +
                        $"{ test[0].ToString() } and { test[1].ToString() }");
                }
            }



            Console.WriteLine("\nProcessing complete!");
        }
    }
}