public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        if(nums.Length == 1) {
            return nums[0];
        }
        
        var prevPrev = nums[0];
        var prev = Math.Max(nums[0], nums[1]);
        
        foreach(var x in nums.Skip(2)) {
            var bestSoFar = Math.Max(prevPrev + x, prev);
            prevPrev = prev;
            prev = bestSoFar;
        }
        
        return Math.Max(prevPrev, prev);
        
    }
}