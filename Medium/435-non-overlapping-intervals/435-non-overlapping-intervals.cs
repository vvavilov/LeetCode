public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        intervals = intervals.OrderBy(x => x[0]).ToArray();
        
        if(intervals.Length == 0) {
            return 0;
        }
        
        var count = 0;
        var prevEnd = intervals[0][1];
        
        for(int i = 1; i < intervals.Length; i++) {
            var cur = intervals[i];
            var areOverlaps = cur[0] < prevEnd;
            
            if(areOverlaps) {
                count++;
                prevEnd = Math.Min(prevEnd, cur[1]);
            } else {
                prevEnd = cur[1];
            }
            
        }
        
        return count;
        
    }
}