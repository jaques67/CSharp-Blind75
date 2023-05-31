// https://leetcode.com/problems/invert-binary-tree/
// 226. Invert Binary Tree

using System.Collections.Generic;
using System.Xml.Linq;
using System;
using Blind75Lib;
using static System.Net.Mime.MediaTypeNames;
using Blind75Lib.Models;

namespace _06_InvertBinaryTree
{
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree(root.left);
            InvertTree(root.right);


            return root;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tests = new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int> { 4, 2, 7, 1, 3, 6, 9 },
                    new List<int> { 4, 7, 2, 9, 6, 3, 1 }
                },
                new List<List<int>>
                {
                    new List<int> { 2, 1, 3 },
                    new List<int> { 2, 3, 1 }
                },
                new List<List<int>>
                {
                    new List<int>(),
                    new List<int>()
                }
            };

            Solution sol = new();

            foreach (var test in tests)
            {
                TreeNode tree = BuildTree.BuildTreeNodeTree(test[0]);
                var output = sol.InvertTree(tree);
                var converted_output = BuildTree.BuildArrayListBFS(output);

                if (converted_output.SequenceEqual(test[1]))
                {
                    Console.WriteLine("Swapped");
                }
                else
                {
                    Console.WriteLine($"Error: Expected [{string.Join(", ", test[1])}] but got " +
                        $"[{string.Join(", ", converted_output)}] instead for input " +
                        $"[{string.Join(", ", test[0])}]");
                }
            }

            Console.WriteLine("\nProcessing complete!");
        }
    }
}