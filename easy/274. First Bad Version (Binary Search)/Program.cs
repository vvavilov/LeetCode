static int FirstBadVersion(int n) {
    if (!IsBadVersion(n)) { return -1;}
    
    int start = 0;
    int end = n;
    
    while(start < end) {
        var mid = (end - start) / 2 + start;
        if (IsBadVersion(mid)) {
            end = mid;
        } else {
            start = mid + 1;
        }
    }
    
    return start;
}