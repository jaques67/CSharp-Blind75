// https://leetcode.com/problems/balanced-binary-tree/
// 110. Balanced Binary Tree

using Blind75Lib;
using Blind75Lib.Models;
using static System.Net.Mime.MediaTypeNames;

namespace _11_BalancedBinaryTree
{
    internal class Program
    {
        public class Solution
        {
            public bool IsBalanced(TreeNode root)  // 110ms
            {
                int TreeHeight(TreeNode node)
                {
                    if (node == null) return 0;

                    var leftHeight = TreeHeight(node.left);
                    var rightHeight = TreeHeight(node.right);

                    if (leftHeight == -1 || rightHeight == -1) return -1;
                    if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

                    return Math.Max(leftHeight, rightHeight) + 1;
                }

                return TreeHeight(root) != -1;
            }
        }

        static void Main(string[] args)
        {
            var tests = new List<List<int?>>
            {
                new List<int?> { 3, 9, 20, null, null, 15, 7 },
                new List<int?> { 1, 2, 2, 3, 3, null, null, 4, 4 },
                new List<int?>(),
            };
            var results = new List<List<bool>>
            {
                new List<bool> { true },
                new List<bool> { false },
                new List<bool> { true }
            };

            Solution s = new Solution();

            for (int i = 0; i < tests.Count; i++)
            {
                var result = results[i][0];
                var input = BuildTree.BuildTreeNodeTree(tests[i]);

                var output = s.IsBalanced(input);

                if (output == result)
                    Console.WriteLine(output);
                else
                {
                    Console.WriteLine($"Error: Expected { result } but got { output } for input { string.Join(", ", tests[i]) }");
                }
            }
            Console.WriteLine("\nProcessing complete!");
        }
    }
}