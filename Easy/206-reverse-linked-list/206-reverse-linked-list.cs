public class Solution {
    public ListNode ReverseList(ListNode head) {
        /*
          iterate over items
          next = current.next
          current.next = prev;
          prev = current;       
        */
        
        ListNode prev = null;
        while(head != null) {
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        
        return prev;
    }
}