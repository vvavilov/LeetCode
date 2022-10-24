public class Solution {
    public bool CanPartition(int[] nums) {
        if(nums.Sum() % 2 != 0) {
            return false;
        }
        
        var dp = new bool[nums.Length][];
        var target = nums.Sum() / 2;
        
        for(int i = 0; i < dp.Length; i++) {
            dp[i] = new bool[target + 1];
        }
        
        if(nums[0] <= target) {
            dp[0][nums[0]] = true;
        }
        
        
        for(int i = 1; i < dp.Length; i++) {
            if(nums[i] <= target) {
                dp[i][nums[i]] = true;

            }
            
            for(int j = 0; j <= target; j++) {
                if(dp[i - 1][j]) {
                    dp[i][j] = dp[i - 1][j];
                    var sum = j + nums[i];

                    if(sum <= target) {
                        dp[i][sum] = true; 
                    }
                }
                
            }
        }
        
        return dp.Any(x => x[target]);
    }
}