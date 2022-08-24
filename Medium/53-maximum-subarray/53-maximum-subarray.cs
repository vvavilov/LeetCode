public class Solution {
    public int MaxSubArray(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        var maxVal = nums[0];
        var sum = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            if (sum < 0) {
                // maxVal = Math.Max(maxVal, sum);
                sum = nums[i];
            } else {
                sum += nums[i];
            }
            
            maxVal = Math.Max(sum, maxVal);
        }
        
        return maxVal;
    }
}