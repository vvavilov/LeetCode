public class SolutionTopDown {
    public int Jump(int[] nums) {
        return DP(nums, 0, new Dictionary<int, int>());
    }
    
    private int DP(int[] nums, int pos, Dictionary<int, int> dp) {
        if(pos == nums.Length - 1) {
            return 0;
        }
        
        if(dp.ContainsKey(pos)) {
            return dp[pos];
        }
        
        dp[pos] = Int32.MaxValue;
        
        for(int i = 1; i <= nums[pos]; i++) {
            var next = pos + i;
            
            if(next >= nums.Length) {
                break;
            }
            
            var nextBest = DP(nums, next, dp);
            
            if(nextBest != Int32.MaxValue) {
                dp[pos] = Math.Min(dp[pos], 1 + nextBest);
            }
        }
        
        return dp[pos];
    }
}

public class Solution {
    public int Jump(int[] nums) {
        Dictionary<int, int> dp = new();
        dp[nums.Length - 1] = 0;
        
        for(int i = nums.Length - 2; i >= 0; i--) {
            dp[i] = Int32.MaxValue;
            
            for(int jumpLength = 1; jumpLength <= nums[i]; jumpLength++) {
                if(i + jumpLength >= nums.Length) {
                    break;
                }
                
                var nextJumpsCount = dp[i + jumpLength];
                
                if(nextJumpsCount != Int32.MaxValue) {
                    dp[i] = Math.Min(dp[i], 1 + nextJumpsCount);
                }
            }
        }
        
        return dp[0];
    }
}