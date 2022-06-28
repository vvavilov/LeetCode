/* The isBadVersion API is defined in the parent class VersionControl.
1 - 2 - 3 - 4 - 5 - 6

      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        var left = 1;
        var right = n;
        
        while(left < right) {
            var mid = (right - left) / 2 + left;
            if(IsBadVersion(mid)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
}