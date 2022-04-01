public class Solution {
    public bool IsPalindrome(ListNode head) {
        if(head == null || head.next == null) { return true;}
        var secondHead = FindSecondHalf(head);
        var secondRev = RevertList(secondHead);
        while(secondRev != null) {
            if (head.val != secondRev.val) {
                return false;
            }
            secondRev = secondRev.next;
            head = head.next;
            
        }
        return true;
    }
    
    private ListNode FindSecondHalf(ListNode head) {
        var slow = head;
        var fast = head;
        while(fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return slow;
    }
    
    private ListNode RevertList(ListNode list) {
        ListNode prev = null;
        while(list != null) {
            var next = list.next;
            list.next = prev;
            prev = list;
            list = next;
        }
        
        return prev;
    }
}