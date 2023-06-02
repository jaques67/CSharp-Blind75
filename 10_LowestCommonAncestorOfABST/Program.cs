// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
// 235. Lowest Common Ancestor of a Binary Search Tree

using Blind75Lib;
using Blind75Lib.Models;

namespace _10_LowestCommonAncestorOfABST
{
    internal class Program
    {

        public class Solution
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)  // 105ms
            {
                if (root.val < p.val && root.val < q.val)
                {
                    return LowestCommonAncestor(root.right, p, q);
                }

                if (root.val > p.val && root.val > q.val)
                    return LowestCommonAncestor(root.left, p, q);

                return root;
            }
        }
        static void Main(string[] args)
        {
            var tests = new List<List<List<int?>>>
            {
                new List<List<int?>>
                {
                    new List<int?> { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 },
                    new List<int?> { 2 },
                    new List<int?> { 8 },
                    new List<int?> { 6 }
                },
                new List<List<int?>>
                {
                    new List<int?> { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 },
                    new List<int?> { 2 },
                    new List<int?> { 4 },
                    new List<int?> { 2 }
                },
                new List<List<int?>>
                {
                    new List<int?> { 2, 1 },
                    new List<int?> { 2 },
                    new List<int?> { 1 },
                    new List<int?> { 2 }
                }
            };

            Solution solution = new Solution();

            foreach (var test in tests)
            {
                var tree = BuildTree.BuildTreeNodeTree(test[0]);
                var p = BuildTree.BuildTreeNodeTree(test[1]);
                var q = BuildTree.BuildTreeNodeTree(test[2]);
                var ans = BuildTree.BuildTreeNodeTree(test[3]);

                var output = solution.LowestCommonAncestor(tree, p, q);

                if (output.val == ans.val)
                {
                    Console.WriteLine(output.val);
                }
                else
                {
                    Console.WriteLine($"Error: Expected { ans.val } but got { output.val } instead for { string.Join(", ", test[0]) }");
                }
            }

            Console.WriteLine("\nProcessing complete!");
        }
    }
}