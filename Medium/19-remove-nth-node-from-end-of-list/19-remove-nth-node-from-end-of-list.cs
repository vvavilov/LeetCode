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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // 1 -> 2 -> 3 -> 4 -> 5  -> nil
        // d -> 1 -> 2
        
        var dumb = new ListNode();
        dumb.next = head;

        var rightNode = dumb;
        var leftNode = dumb;
        
        while(n-- >= 0) {
            rightNode = rightNode.next;
        }
        
        while(rightNode != null) {
            leftNode = leftNode.next;
            rightNode = rightNode.next;
        }
        
        leftNode.next = leftNode.next.next;
        return dumb.next;
    }
}