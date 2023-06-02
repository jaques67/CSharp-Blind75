using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blind75Lib.Models;

namespace Blind75Lib
{

    public class BuildTree
    {
        public static TreeNode BuildTreeNodeTree(List<int?> items)
        {
            int n = items.Count;

            if (n == 0 || items == null) return null; // new TreeNode();

            TreeNode Inner(int index = 0)
            {
                if (n <= index || items[index] == null) return null;

                TreeNode node = new TreeNode((int)items[index]);
                node.left = Inner(2 * index + 1);
                node.right = Inner(2 * index + 2);

                return node;
            }
            return Inner();
        }


        public static List<TreeNode> BuildList(TreeNode root)
        {
            List<TreeNode> res = new List<TreeNode>();
            if (root == null || root.val == null)
                return res;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    var node = queue.Dequeue();
                    res.Add(node);

                    foreach (var child in new TreeNode[] { node.left, node.right })
                    {
                        if (child != null)
                            queue.Enqueue(child);
                    }
                }
            }

            return res;
        }

        public static List<int> BuildArrayListBFS(TreeNode list)
        {
            List<int> res = new();
            if (list == null) return res;

            Queue<TreeNode> queue = new();
            queue.Enqueue(list);

            while (queue.Count > 0)
            {
                int n = queue.Count;
                List<TreeNode> newLevel = new List<TreeNode>();
                for (int i = 0; i<n; i++)
                {
                    TreeNode node = queue.Dequeue();
                    res.Add(node.val);
                    // enqueue non-null children
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return res;
        }
    }
}
