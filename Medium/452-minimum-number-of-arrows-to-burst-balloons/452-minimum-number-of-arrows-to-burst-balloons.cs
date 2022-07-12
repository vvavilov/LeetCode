public class Solution {
    public int FindMinArrowShots(int[][] points) {
        var sorted = points.OrderBy(x => x[0]);
        
        var intersectionMin = Int32.MinValue;
        var intersectionMax = Int32.MaxValue;
        var count = 1; // fist shot initiation
        
        foreach(var x in sorted) {
            var min = x[0];
            var max = x[1];
            
            if(min >= intersectionMin && min <= intersectionMax) {
                intersectionMin = min;
                intersectionMax = Math.Min(intersectionMax, max);
            } else {
                count++;
                intersectionMin = min;
                intersectionMax = max;
            }
        }

        return count;
    }
}