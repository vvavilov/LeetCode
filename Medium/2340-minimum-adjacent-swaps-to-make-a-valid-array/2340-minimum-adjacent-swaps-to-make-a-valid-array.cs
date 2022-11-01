public class Solution {
    public int MinimumSwaps(int[] nums) {
        var minPos = 0;
        var min = Int32.MaxValue;
        var maxPos = 0;
        var max = Int32.MinValue;
        
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] < min) {
                min = nums[i];
                minPos = i;
            }
            
            if(nums[i] >= max) {
                max = nums[i];
                maxPos = i;
            }
        }
        
        var crossModifier = minPos > maxPos ? 1 : 0;
        var maxMovements = nums.Length - maxPos - 1;
        var minMovements = minPos;
        return maxMovements + minMovements - crossModifier;
        
    }
}