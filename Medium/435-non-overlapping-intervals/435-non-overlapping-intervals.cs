public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length == 0) {
            return 0;
        }
        
        var sorted = intervals.OrderBy(x => x[0]);
        var count = 0;
        var prevEnd = sorted.First()[1];
        
        foreach(var cur in sorted.Skip(1)) {
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