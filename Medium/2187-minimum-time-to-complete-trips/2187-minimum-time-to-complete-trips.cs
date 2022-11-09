public class Solution {
    public long MinimumTime(int[] time, int totalTrips) {
        if(time.Length == 0) {
            return 0;
        }
        
        var left = 0L;
        long right = (long)time[0] * totalTrips;
        
        while(left < right) {
            var trips = 0L;
            var mid = (right - left) / 2 + left;
            
            foreach(var tripTime in time) {
                trips += mid / tripTime;
            }
            
            if(trips >= totalTrips) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return right;   
    }
}
//              1 2 3
// left    0 2 2
// right   5 5 3
// mid     2 3
// trips   3 5