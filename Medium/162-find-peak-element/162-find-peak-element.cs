public class Solution {
    public int FindPeakElement(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;
        
        while(left <= right) {
            var mid = (right - left) / 2 + left;
            
            var isIncreasing = mid == 0 || nums[mid] > nums[mid - 1];
            
            if(isIncreasing && (mid == nums.Length - 1 || nums[mid] > nums[mid + 1])) {
                return mid;
            }
            
            if(isIncreasing) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return -1;
    }
    
}