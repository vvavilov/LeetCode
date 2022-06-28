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
 
 1 - 3 - 5 - 7
 2 - 3 - 6
 */
public class Solution {
    
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null) {
            return list2;
        }
        
        if(list2 == null) {
            return list1;
        }
        
        if(list1.val < list2.val) {
            var node = list1;
            node.next = MergeTwoLists(list1.next, list2);
            return node;
        } else {
            var node = list2;
            node.next = MergeTwoLists(list1, list2.next);
            return node;
        }
        
    }
}