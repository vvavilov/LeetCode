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
    public void ReorderList(ListNode head) {
        if(head == null || head.next == null) {
            return;
        }
        
        var mid = SplitList(head);
        var right = Reverse(mid);
        
        var left = head;
        var current = new ListNode(0, head);
        
    
        while(left != null) {
            var nextLeft = left.next;
            var nextRight = right?.next;
            current.next = left;
            current.next.next = right;
            
            left = nextLeft;
            right = nextRight;
            current = current.next.next;
        }
    }
    
    private ListNode Reverse(ListNode head) {
        ListNode prev = null;
        
        while(head != null) {
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        
        return prev;
    }
    
    
    private ListNode SplitList(ListNode head) {
        var dummy = new ListNode(0, head);
        
        var fast = dummy;
        var slow = dummy;
        
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
        
        var secondHalf = slow.next;
        slow.next = null;
        
        return secondHalf;
    }
}