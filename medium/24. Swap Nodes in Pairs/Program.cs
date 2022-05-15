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
    public ListNode SwapPairs(ListNode head) {
        if(head == null) {
            return null;
        }
        if(head.next == null) {
            return head;
        }
        
        var nextToSwap = head.next.next;
        var swapped = head.next;
        swapped.next = head;
        swapped.next.next = SwapPairs(nextToSwap);
        
        return swapped;
    }
}