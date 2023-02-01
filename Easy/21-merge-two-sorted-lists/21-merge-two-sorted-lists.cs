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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var dummyResult = new ListNode();
        var currentResult = dummyResult;
        
        while(list1 != null && list2 != null) {
            if(list1.val < list2.val) {
                currentResult.next = list1;
                list1 = list1.next;
            } else {
                currentResult.next = list2;
                list2 = list2.next;
            }
            
            currentResult = currentResult.next;
        }
        
        var rest = list1 ?? list2;
        
        while(rest != null) {
            currentResult.next = rest;
            rest = rest.next;
            currentResult = currentResult.next;
        }
        
        return dummyResult.next;
    }
}