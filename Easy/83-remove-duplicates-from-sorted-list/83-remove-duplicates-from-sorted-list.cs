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
    public ListNode DeleteDuplicates(ListNode head) {
//      set prev
//        iterate, if prev = cur -> prev.next = cur.next, else prev = cur;
//         initiate prev with dummy
        
        var dummy = new ListNode(-101);
        dummy.next = head;
        var prev = dummy;
        
        while(head != null) {
            if(prev.val == head.val) {
                prev.next = head.next;
            } else {
                prev = head;
            }
            head = head.next;
        }
        return dummy.next;
    }
}