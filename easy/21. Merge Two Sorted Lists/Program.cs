public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) {
            return list2;
        }
        if(list2 == null) {
            return list1;
        }
        
        if (list1.val <= list2.val) {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        } else {
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
    
    public ListNode MergeTwoListsIterative(ListNode list1, ListNode list2) {
        if (list1 == null && list2 == null) {
            return null;
        }
        
        var dummy = new ListNode();
        var current = dummy;
        
        while(list1 != null && list2 != null) {
            if (list1.val >= list2.val) {
                current.next = list2;        
                list2 = list2.next;

            } else {
                current.next = list1;
                list1 = list1.next;
            }
            current = current.next;
        }
        if(list1 != null) {
            current.next = list1;
        } else {
            current.next = list2;
        }
        return dummy.next;
        
    }
}