/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        var pq = new PriorityQueue<int, int>();

        for(int i = 0; i < lists.Length; i++) {
            if(lists[i] == null) {
                continue;
            }
            pq.Enqueue(i, lists[i].val);
        }

        var dummy = new ListNode();
        var cur = dummy;

        while(pq.Count > 0) {
            var listN = pq.Dequeue();
            cur.next = new ListNode(lists[listN].val);
            lists[listN] = lists[listN].next;
            cur = cur.next;

            if(lists[listN] != null) {
                pq.Enqueue(listN, lists[listN].val);
            }
        }

        return dummy.next;
    }
}

public class SolutionBruteForse {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Length == 0) {
            return null;            
        }

        var result = new ListNode();
        var current = result;
        
        var hasNodes = true;
        
        while(true) {
            var minNodeN = -1;
                
            for(int i = 0; i < lists.Length; i++) {
                var list = lists[i];
                
                if(list == null) {
                    continue;
                }
                
                hasNodes = true;
                
                if(minNodeN < 0 || list.val < lists[minNodeN].val) {
                    minNodeN = i;
                }
            }
                           
            if(minNodeN < 0) {
                break;
            }
            
            current.next = lists[minNodeN];
            current = current.next;
            lists[minNodeN] = lists[minNodeN].next;
        }
        
        
        return result.next;
    }
}

