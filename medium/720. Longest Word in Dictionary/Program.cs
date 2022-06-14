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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbers(l1, l2, 0);
        
    }
    
    private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry) {
        if(l1 == null && l2 == null) {
            return carry == 0
                ? null
                : new ListNode(1);
        }
        
        var val = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
        carry = 0;
        
        if(val >= 10) {
            val -= 10;
            carry = 1;
        }
        
        var node = l1 ?? l2;
        node.val = val;
        node.next = AddTwoNumbers(l1?.next, l2?.next, carry);
        return node;
    }
}