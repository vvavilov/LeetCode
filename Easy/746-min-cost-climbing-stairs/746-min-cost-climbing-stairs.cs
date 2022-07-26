public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        if(cost.Length == 0) {
            return 0;
        }
        
        if(cost.Length == 1) {
            return cost[0];
        }

        var prevPrev = cost[0];
        var prev = cost[1];
        
        for(int i = 2; i < cost.Length; i++) {
            var minToReachCurrent = Math.Min(prevPrev, prev) + cost[i];
            prevPrev = prev;
            prev = minToReachCurrent;
        }
        
        return Math.Min(prev, prevPrev);
    }
}