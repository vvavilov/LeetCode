public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        return TopDown(nums, target, new Dictionary<int, int>());
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