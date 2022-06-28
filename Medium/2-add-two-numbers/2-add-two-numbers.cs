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
        var result = new ListNode();
        var currentSumNode = result;
        var carry = 0;
        
        while(l1 != null || l2 != null) {
            var firstVal = l1 == null ? 0 : l1.val;
            var secondVal = l2 == null ? 0 : l2.val;
            
            var sum = firstVal + secondVal + carry;
            currentSumNode.next = new ListNode(sum % 10);
            carry = sum >= 10 ? 1 : 0;
            currentSumNode = currentSumNode.next;
            l1 = l1?.next ?? null;
            l2 = l2?.next ?? null;
        }
        
        if(carry == 1) {
            currentSumNode.next = new ListNode(1);
        }
        
        return result.next;
    }
}