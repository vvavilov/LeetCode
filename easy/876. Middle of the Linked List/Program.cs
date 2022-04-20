static ListNode MiddleNode2Pointers(ListNode head) {
    var current = head;
    while(head != null && head.next != null) {
        head=head.next.next;
        current = current.next;
    }
    return current;
    
}

static ListNode MiddleNodeCount(ListNode head) {
    var counter = 1;
    var current = head;
    
    while(current.next != null) {
        current = current.next;
        counter++;
    }
    
    var middle = counter / 2;
    
    current = head;
    
    while(middle > 0) {
        current = current.next;
        middle--;
    }
    
    return current;
}
