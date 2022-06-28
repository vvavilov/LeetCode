public class Solution {
    public int FindPeakElement(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;
        
        while(left < right) {
            var mid = (int)Math.Ceiling((right - left) / 2d + left);
            var isIncreasing = nums[mid] > nums[mid - 1];
            
            if(isIncreasing) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        
        return left;
    }
    
}