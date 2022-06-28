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
    public ListNode OddEvenList(ListNode head) {
        if(head?.next == null) {
            return head;
        }
        
        var startOdd = head;
        var lastOdd = head;
        var lastEven = head.next;
        var startEven = lastEven;

        
        head = head.next.next;
        var isOdd = true;
        
        while(head != null) {
            if(isOdd) {
                lastOdd.next = head;
                lastOdd = lastOdd.next;
            } else {
                lastEven.next = head;
                lastEven = lastEven.next;
            }
            
            isOdd = !isOdd;
            head = head.next;
        }
        
        lastEven.next = null;
        lastOdd.next = startEven;
        return startOdd;
    }
}