

public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        var dummy = new ListNode(0, head);
        
        var i = 1;
        var prev = dummy;
        
        while(i < left) {
            prev = prev.next;
            i++;
        }
        
        var cur = prev.next;
        var next = cur.next;
        var startReverse = cur;
        
        while(i < right) {
            var rest = next?.next;
            next.next = cur;
            cur = next;
            next = rest;
            i++;
        }
        
        
        prev.next = cur;
        startReverse.next = next;
        
        return dummy.next;
    }
}

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
public class SolutionStack {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        var stack = new Stack<ListNode>();
        var dummy = new ListNode(0, head);
        
        var prev = dummy;
        var i = 1;
        
        while(i < left) {
            prev = prev.next;
            i++;
        }
        
        var cur = prev.next;
        
        while(i <= right) {
            stack.Push(cur);
            cur = cur.next;
            i++;
        }
        
        while(stack.Count > 0) {
            prev.next = stack.Pop();
            prev = prev.next;
        }
        
        prev.next = cur;
        
        return dummy.next;
    }
}