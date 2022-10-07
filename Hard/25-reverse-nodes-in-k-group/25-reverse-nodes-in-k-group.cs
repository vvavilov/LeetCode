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
    private int k;
    private int processed = 0;
    
    public ListNode ReverseKGroup(ListNode head, int k) {
        this.k = k;
        var reversed = Reverse(head, head, null, k);
        var toMoveBack = processed % k;
        var correctCount = processed - toMoveBack;
        
        if(toMoveBack == 0) {
            return reversed;
        }
        
        var lastCorrect = reversed;
        while(correctCount-- > 1) {
            lastCorrect = lastCorrect.next;
        }
        
        lastCorrect.next = Reverse(lastCorrect.next, lastCorrect.next, null, toMoveBack);
        return reversed;
        
        
    }
    
    private ListNode Reverse(ListNode head, ListNode node, ListNode prev, int remain) {
        if(node == null) {
            return prev;
        }
        
        processed++;        
        var next = node.next;
        node.next = prev;
        
        if(remain != 1) {
            return Reverse(head, next, node, remain - 1);
        }
        
        head.next = Reverse(next, next, null, k);
        return node;
    }
}