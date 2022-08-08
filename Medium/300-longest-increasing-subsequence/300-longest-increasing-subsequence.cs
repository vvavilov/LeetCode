public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        int maxLength = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            maxLength = Math.Max(maxLength, TopDown(nums, i, dp));
        }
        
        return maxLength;
    }
    
    public int TopDown(int[] nums, int n, int[] dp) {
        var maxLength = 1;
        
        if(dp[n] != 0) {
            return dp[n];
        }
        
        for(int i = n - 1; i >= 0; i--) {
            if(nums[i] >= nums[n]) {
                continue;
            }
            
            maxLength = Math.Max(maxLength, 1 + TopDown(nums, i, dp));
        }
        
        dp[n] = maxLength;
        return dp[n];
    }
}