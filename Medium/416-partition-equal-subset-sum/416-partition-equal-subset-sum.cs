public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        
        if(sum % 2 != 0) {
            return false;
        }
        
        var dp = new bool?[nums.Length][];
    
        for(int i = 0; i < dp.Length; i++) {
            dp[i] = new bool?[sum / 2 + 1];
        }
        
        return DP(nums, 0, sum / 2, dp);
    }
    
    private bool DP(int[] nums, int pos, int target, bool?[][] dp) {
        if(target < 0) {
            return false;
        }
        
        if(target == 0) {
            return true;
        }
        
        if(pos == nums.Length) {
            return false;
        }
        
        if(dp[pos][target] is bool calculated) {
            return calculated;
        }
        
        var val = nums[pos];
        
        dp[pos][target] = DP(nums, pos + 1, target - val, dp) || DP(nums, pos + 1, target, dp);
        return (bool)dp[pos][target];
    }
}