public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        if(nums.Length == 1) {
            return nums[0];
        }
        
        var takeFirst = Maximize(nums, 0, nums.Length - 2);
        var skipFirst = Maximize(nums, 1, nums.Length - 1);
        return Math.Max(takeFirst, skipFirst);
    }
    
    private int Maximize(int[] nums, int start, int end) {
        var lastTakenAcc = nums[start];
        var lastSkippedAcc = 0;
        
        for(int i = start + 1; i <= end; i++) {
            var currentTakenAcc = lastSkippedAcc + nums[i];
            lastSkippedAcc = Math.Max(lastSkippedAcc, lastTakenAcc);
            lastTakenAcc = currentTakenAcc;
        }
        
        return Math.Max(lastTakenAcc, lastSkippedAcc);
    }
}