// https://leetcode.com/problems/implement-queue-using-stacks/
// 232. Implement Queue using Stacks
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace _13_ImplementQueueUsingStacks
{
    public class MyQueue
    {
        Stack<int> stack1;
        Stack<int> stack2;
        public MyQueue()        // 119ms
        {
            stack1 = new();
            stack2 = new();
        }

        public void Push(int x)
        {
            stack1.Push(x);
        }

        public int Pop()
        {
            if (stack2.Count == 0)  // fill stack2 from stack1
                while (stack1.Count > 0)
                    stack2.Push(stack1.Pop());

            return stack2.Pop();
        }

        public int Peek()
        {
            if (stack2.Count == 0)
                while (stack1.Count > 0)
                    stack2.Push(stack1.Pop());

            return stack2.Peek();
        }

        public bool Empty()
        {
            return (stack1.Count == 0 && stack2.Count == 0);
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<List<(string, int?, object?)>>> tests = new()
            { 
                new List<List<(string, int?, object?)>>
                {
                    new List<(string, int?, object?)> { ("MyQueue", null, null) },
                    new List<(string, int?, object?)> { ("push", 1, null) },
                    new List<(string, int?, object?)> { ("push", 2, null) },
                    new List<(string, int?, object?)> { ("peek", null, 1) },
                    new List<(string, int?, object?)> { ("pop", null, 1) },
                    new List<(string, int?, object?)> { ("empty", null, false) }
                },
                new List<List<(string, int?, object?)>>
                {
                    new List<(string, int?, object?)> { ("MyQueue", null, null) },
                    new List<(string, int?, object?)> { ("push", 1, null) },
                    new List<(string, int?, object?)> { ("push", 2, null) },
                    new List<(string, int?, object?)> { ("push", 3, null) },
                    new List<(string, int?, object?)> { ("push", 4, null) },

                    new List<(string, int?, object?)> { ("pop", null, 1) },

                    new List<(string, int?, object?)> { ("push", 5, null) },

                    new List<(string, int?, object?)> { ("pop", null, 2) },
                    new List<(string, int?, object?)> { ("pop", null, 3) },
                    new List<(string, int?, object?)> { ("pop", null, 4) },
                    new List<(string, int?, object?)> { ("pop", null, 5) }
                }

            };
            
            MyQueue queue;

            for (int i = 0; i < tests.Count; i++)
            {
                var val1 = tests[i];
                var val2 = tests[i].Count;
                queue = null;
                for (int j = 0; j < tests[i].Count; j++)
                {
                    var val3 = tests[i][j];
                    var val4 = tests[i][j][0].Item1;

                    if (tests[i][j][0].Item1 == "MyQueue")
                        queue = new MyQueue();

                    if (queue != null)
                    {
                        if (tests[i][j][0].Item1 == "push")
                        {
                            queue.Push((int)tests[i][j][0].Item2);
                        }

                        if (tests[i][j][0].Item1 == "pop")
                        {
                            int result = queue.Pop();
                            if (result != (int)tests[i][j][0].Item3)
                                Console.WriteLine($"Pop Error: Expected {(int)tests[i][j][0].Item3} but got {result}");
                            else
                                Console.WriteLine($"Pop: {result}");
                        }

                        if (tests[i][j][0].Item1 == "peek")
                        {
                            int result = queue.Peek();
                            if (result != (int)tests[i][j][0].Item3)
                                Console.WriteLine($"Peek Error: Expected {(int)tests[i][j][0].Item3} but got {result}");
                            else
                                Console.WriteLine($"Peek: {result}");
                        }

                        if (tests[i][j][0].Item1 == "empty")
                        {
                            bool result = queue.Empty();
                            if (result != (bool)tests[i][j][0].Item3)
                                Console.WriteLine($"Empty Error: Expected {(bool)tests[i][j][0].Item3} but got {result}");
                            else
                                Console.WriteLine($"empty: {result}");

                        }
                    }
                    else
                        Console.WriteLine("No queue created");
                }
            }

            Console.WriteLine("\nProcessing complete!");
        }
    }
}