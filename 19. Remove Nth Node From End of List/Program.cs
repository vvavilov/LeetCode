static ListNode RemoveNthFromEnd(ListNode head, int n) {
    var dummy = new ListNode { val = -1 };
    dummy.next = head;
    var slow = dummy;
    var fast = dummy;
    
    for(int i = 0; i < n + 1; i++) {
        fast = fast.next;
    }
    
    while(fast != null) {
        fast = fast.next;
        slow = slow.next;
    }
    
    slow.next = slow.next.next;
    return dummy.next;
}