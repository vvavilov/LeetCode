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
    public ListNode SortList(ListNode head) {
        return Sort(head);
    }
    
    private ListNode Merge(ListNode left, ListNode right) {
        var dummy = new ListNode();
        var current = dummy;
        
        while(left != null || right != null) {
            if(left == null || right == null) {
                current.next = right ?? left;
                right = right?.next;
                left = left?.next;
                current = current.next;
                continue;
            }
            
            if(left.val <= right.val) {
                current.next = left;
                left = left.next;
            } else {
                current.next = right;
                right = right.next;
            }
            
            current = current.next;
        }
        
        return dummy.next;
    }
    
    private ListNode Sort(ListNode node) {
        if(node == null || node.next == null) {
            return node;
        }
        
        var secondPart = Split(node);
        node = Sort(node);
        secondPart = Sort(secondPart);
        return Merge(node, secondPart);
    }
    
    private ListNode Split(ListNode node) {
        var count = 0;
        var head = node;
        
        while(node != null) {
            count++;
            node = node.next;
        }
        
        var middle = count / 2;
        node = head;
        
        while(middle > 1) {
            node = node.next;
            middle--;
        }
        
        var secondHalf = node.next;
        node.next = null;
        return secondHalf;
    }
}