public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null) { return false; }
        
        var slow = head;
        var fast = head;
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
            
            if(fast == slow) { return true; }

        }
        
        return false;
    }
}