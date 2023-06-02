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

        public static ListNode BuildList(List<int> list, int loopBackPos)
        {
            ListNode tmp = new ListNode(null);
            ListNode dummy = tmp;
            ListNode? loopPos = null;

            for (int i = 0; i < list.Count; i++)
            {
                tmp.next = new ListNode(list[i]);
                tmp = tmp.next;
                if (i == loopBackPos)
                    loopPos = tmp;
            }

            if (loopBackPos >= 0) tmp.next = loopPos;

            return dummy.next;
        }

        public static int[] ConvertToArray(ListNode list)
        {
            List<int> result = new();
            while (list != null)
            {
                result.Add((int)list.val);
                list = list.next;
            }

            return result.ToArray();
        }
    }
}
