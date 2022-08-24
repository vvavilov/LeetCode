public class Solution {
    public int MaxSubArray(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        var maxVal = nums[0];
        var sum = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            sum = sum < 0 ? 0 : sum;
            sum += nums[i];
            maxVal = Math.Max(sum, maxVal);
        }
        
        return maxVal;
    }
}