public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var dp = new int[target + 1];
        dp[0] = 1;
        
        for (int i = 1; i <= target; i++) {
            for(int j = 0; j < nums.Length; j++) {
                if(i - nums[j] >= 0) {
                    dp[i] += dp[i - nums[j]];
                }
            }
        }
        
        return dp[dp.Length - 1];
    }
    
    
    
    
    private int TopDown(int[] nums, int target, Dictionary<int, int> dp) {
        if(dp.ContainsKey(target)) {
            return dp[target];
        }
        
        if(target == 0) {
            return 1;
        }
        
        if (target < 0) {
            return 0;
        }
        
        var count = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            count += TopDown(nums, target - nums[i], dp);
        }
        
        dp[target] = count;
        return count;
    }
}