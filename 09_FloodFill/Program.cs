// https://leetcode.com/problems/flood-fill/
// 733. Flood Fill

namespace _09_FloodFill
{

    public class Solution
    {
        public int[][] FloodFillBFS(int[][] image, int sr, int sc, int color)  // 151ms
        {
            int numRows = image.Length;
            int numCols = image[0].Length;

            IEnumerable<(int, int)> GetNeighbours((int, int) coord, int colour)
            {
                int row = coord.Item1;
                int col = coord.Item2;
                int[] deltaRow = { -1, 0, 1, 0 };
                int[] deltaCol = { 0, 1, 0, -1 };

                for (int i = 0; i < deltaRow.Length; i++)
                {
                    int neighbourRow = deltaRow[i] + row;
                    int neighbourCol = deltaCol[i] + col;
                    if (neighbourRow >= 0 && neighbourRow < numRows && neighbourCol >= 0 && neighbourCol < numCols)
                    {
                        if (image[neighbourRow][neighbourCol] == colour)
                            yield return (neighbourRow, neighbourCol);
                    }
                }
            }


            void BFS((int, int) root)
            {
                Queue<(int, int)> queue = new();
                queue.Enqueue(root);
                bool[][] visited = new bool[numRows][];

                for (int t = 0; t < numRows; t++)
                {
                    visited[t] = new bool[numCols];
                }

                int r = root.Item1;
                int c = root.Item2;
                int oldColour = image[r][c];  // get old colour

                image[r][c] = color;            // update root with new colour
                visited[r][c] = true;

                while (queue.Count > 0)
                {
                    (int, int) node = queue.Dequeue();
                    foreach ((int, int) neighbour in GetNeighbours(node, oldColour))
                    {
                        int neighbourRow = neighbour.Item1;
                        int neighbourCol = neighbour.Item2;
                        if (visited[neighbourRow][neighbourCol]) continue;

                        image[neighbourRow][neighbourCol] = color;
                        queue.Enqueue(neighbour);
                        visited[neighbourRow][neighbourCol] = true;
                    }
                }
            }

            BFS((sr, sc));
            return image;
        }

        public int[][] FloodFillDFS(int[][] image, int sr, int sc, int color)  // 141ms
        {
            int rows = image.Length;
            int cols = image[0].Length;

            int oldColour = image[sr][sc];
            List<(int, int)> marked = new();

            image[sr][sc] = color;

            void DFS((int, int) root)
            {
                Stack<(int, int)> stack = new();
                int root_r = root.Item1;
                int root_c = root.Item2;

                stack.Push(root);

                while (stack.Count > 0)
                {
                    (int, int) node = stack.Pop();
                    int r = node.Item1;
                    int c = node.Item2;

                    foreach ((int new_r, int new_c) in new (int, int)[] { (r - 1, c), (r + 1, c), (r, c - 1), (r, c + 1)})
                    {
                        if (new_r < 0 || new_c < 0 || new_r >= rows || new_c >= cols) continue;
                        if (image[new_r][new_c] != oldColour) continue;
                        if (!marked.Contains((new_r, new_c)))
                        {
                            image[new_r][new_c] = color;
                            stack.Push((new_r, new_c));
                            marked.Add((new_r, new_c));
                        }
                    }
                }
            }

            DFS((sr, sc));
            return image;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int[][][] tests = new int[][][]
            {
            new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } },
            new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } }
            };

            int[][][] expectedOutput = new int[][][]
            {
                // [[2, 2, 2], [2, 2, 0], [2, 0, 1]]
                new int[][] {new int[] { 2, 2, 2 }, new int[] { 2, 2, 0 }, new int[] { 2, 0, 1 } },
                new int[][] {new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } }
            };

            int[] newColors = new int[] { 2, 0 };
            int[] srValues = new int[] { 1, 0 };
            int[] scValues = new int[] { 1, 0 };

            Solution solution = new Solution();
            bool errorFound = false;
            for (int i = 0; i < tests.Length; i++)
            {
                int[][] image = (int[][])tests[i].Clone();
                //int[][] output = solution.FloodFillBFS(image, srValues[i], scValues[i], newColors[i]);
                int[][] output = solution.FloodFillDFS(image, srValues[i], scValues[i], newColors[i]);

                for (int j = 0; j < output.Length; j++)
                {
                    for (int k = 0;  k < output[j].Length; k++)
                    {
                        if (output[j][k] != expectedOutput[i][j][k])
                        {
                            Console.WriteLine($"Error.");
                            errorFound = true;
                            break;
                        }
                    }
                }
                if ( !errorFound )
                    Console.WriteLine("Successful");
            }

            Console.WriteLine("\nProcessing Complete!");
        }
    }
}