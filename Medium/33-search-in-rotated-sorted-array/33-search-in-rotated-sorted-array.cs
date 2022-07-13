public class Solution {
    public int Search(int[] nums, int target) {
        if(nums.Length == 0) {
            return -1;
        }
      
        var left = 0;
        var right = nums.Length - 1;
        var first = nums[0];
        
        while(left < right) {
            var mid = (right - left) / 2 + left;
            if(nums[mid] >= first) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        var splitPoint = left;
        
        left = 0;
        right = nums.Length - 1;
       
        if(target >= first) {
            right = splitPoint;
        } else {
            left = splitPoint;
        }
        
        return BinarySearch(nums, target, left, right);
    }
    
    private int BinarySearch(int[] nums, int target, int left, int right) {
        
        while(left <= right) {
            var mid = (right - left) / 2 + left;
            
            if(nums[mid] == target) {
                return mid;
            }
            
            if(target > nums[mid]) {
                left = mid + 1;
            } else {
                right = mid - 1 ;
            }
        }
        
        return -1;
    }
}