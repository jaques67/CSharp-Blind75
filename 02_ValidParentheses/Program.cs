// https://leetcode.com/problems/valid-parentheses/
// 20. Valid Parentheses

namespace _02_ValidParentheses
{

    public class Solution
    {
        public bool IsValid(string s)
        {
            char[] openings = new char[] { '(', '[', '{' };
            char[] closeings = new char[] { ')', ']', '}' };

            var brackets = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            Stack<char> stack = new();

            foreach (char c in s)
            {
                if (openings.Contains(c))
                    stack.Push(c);

                if (closeings.Contains(c))
                {
                    if (stack.Count == 0)
                        return false;

                    char opening = stack.Pop();
                    if (opening != brackets[c]) return false;

                }
            }

            return stack.Count == 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<object[]> tests = new List<object[]>
            {
                new object[] { "()", true },
                new object[] { "()[]{}", true },
                new object[] { "(]", false }
            };

            Solution sol = new();
            foreach (var test in tests)
            {
                string test_value = (string)test[0];
                bool result_value = (bool)test[1];

                bool result = sol.IsValid(test_value);

                if (result == result_value)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"Error: Expected { result_value } but got { result } instead for input { test_value}");
                }
            }

            Console.WriteLine("Processing complete!");
        }
    }
}