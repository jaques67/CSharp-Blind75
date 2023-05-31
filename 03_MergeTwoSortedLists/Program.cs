// https://leetcode.com/problems/merge-two-sorted-lists/
// 21. Merge Two Sorted Lists
// Merge two sorted link-lists

using Blind75Lib;
using Blind75Lib.Models;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace _03_MergeTwoSortedLists
{

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)  // 90ms
        {
            if (list1 == null && list2 == null)
                return null;
            if (list1 == null || list2 == null)
                return list1 ?? list2;

            ListNode dummy = new ListNode();
            ListNode tail = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                    tail = tail.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                    tail = tail.next;
                }

            }

            if (list1 != null || list2 != null)
                tail.next = list1 ?? list2;

            return dummy.next;
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
                    new List<int> { 1, 2, 4 },
                    new List<int> { 1, 3, 4 },
                    new List<int> { 1, 1, 2, 3, 4, 4 }
                },
                new List<List<int>>
                {
                    new List<int>(),
                    new List<int>(),
                    new List<int>()
                },
                new List<List<int>>
                {
                    new List<int>(),
                    new List<int> { 0 },
                    new List<int> { 0 }
                }
            };

            Solution sol = new Solution();

            foreach (var test in tests)
            {
                var val = test[0];
                ListNode list1 = BuildLinkedList.BuildList(test[0]);
                ListNode list2 = BuildLinkedList.BuildList(test[1]);
                ListNode combinedLists = sol.MergeTwoLists(list1, list2);
                int[] output = BuildLinkedList.ConvertToArray(combinedLists);

                if (output.SequenceEqual(test[2].ToArray()))
                {
                    Console.WriteLine("Equal");
                }
                else
                {
                    Console.Write("Error: Expected { ");
                    foreach (var c in test[2])
                    {
                        Console.Write($"{c} ");
                    }
                    Console.Write("} but got { ");
                    foreach (var c in output)
                    {
                        Console.Write($"{c} ");
                    }
                    Console.Write("} instead for { ");
                    foreach (var c in test[0])
                    {
                        Console.Write($"{c} ");
                    }
                    Console.Write("} and { ");
                    foreach (var c in test[1])
                    {
                        Console.Write($"{c} ");
                    }
                    Console.WriteLine("}");

                }
               }

            Console.WriteLine("Processing complete!");
        }
    }
}