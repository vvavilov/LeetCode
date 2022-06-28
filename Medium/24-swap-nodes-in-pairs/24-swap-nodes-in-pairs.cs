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

public class SolutionRecursive {
    public ListNode SwapPairs(ListNode head) {
        if(head == null) {
            return null;
        }
        
        if(head.next == null) {
            return head;
        }
        
        var rest = head.next.next;
        var swapped = head.next;
        swapped.next = head;
        swapped.next.next = SwapPairs(rest);
        return swapped;
    }
}



public class Solution {
    public ListNode SwapPairs(ListNode head) {        
        var dummy = new ListNode(0, head);
        var prev = dummy;
        
        while(head?.next != null) {
            prev.next = head.next;
            head.next = head.next.next;
            prev.next.next = head;
            prev = head;
            head = head.next;
        }
        
        return dummy.next;
    }
}