using Blind75Lib.Models;

namespace Blind75Lib
{
    public class BuildLinkedList
    {
        public static ListNode BuildList(List<int> list)
        {
            ListNode val = new ListNode();
            ListNode tmp = val;

            foreach (var ll in list)
            {
                tmp.next = new ListNode(ll);
                tmp = tmp.next;
            }

            return val.next;
        }

        public static int[] ConvertToArray(ListNode list)
        {
            List<int> result = new();
            while (list != null)
            {
                result.Add(list.val);
                list = list.next;
            }

            return result.ToArray();
        }
    }
}
