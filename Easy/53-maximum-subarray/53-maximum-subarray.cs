public class Solution {
    public int MaxSubArray(int[] nums) {
     /*
        for 0 -> n with i:
            calc max
            if val > max, max -> val
     
     */
        var max = Int32.MinValue;
        var currentMax = Int32.MinValue;

        for(int i = 0; i < nums.Length; i++) {
            if(currentMax < 0) {
                currentMax = nums[i];
            } else {
                currentMax += nums[i];
            }
            max = Math.Max(max, currentMax);
            
        }
        
        return max;
    }
}