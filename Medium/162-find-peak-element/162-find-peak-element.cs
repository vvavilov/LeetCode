public class Solution {
    public int FindPeakElement(int[] nums) {
        if(nums.Length == 0) {
            return -1;
        }

        var left = 0;
        var right = nums.Length - 1;
        
        while(left < right) {
            var mid = (right - left) / 2 + left;
            
            if(nums[mid] > nums[mid+1]) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
}