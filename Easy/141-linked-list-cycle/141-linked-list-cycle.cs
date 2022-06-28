/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 
 
 a - b - c - d - b
 1. hash set - if contains -> cycle
 2. slow+fast pointers
 
 special cases:
 1. no cycle -> limit in while cycle - 
 2. if only 1 node -> i should be handled in 1 while(head.next?.next != null)
 
 
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null) { return false; }
        
        var slow = head;
        var fast = head;
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
            
            if(fast == slow) { return true; }

        }
        
        return false;
    }
}