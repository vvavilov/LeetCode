public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if(nums.Length == 0) {
            return new int[] {-1, -1};
        }
        
        return new int[] {
            FindLeft(nums, target),
            FindRight(nums, target)
        };
    }
    
    private int FindLeft(int[] nums, int target) {

        var left = 0;
        var right = nums.Length - 1;
        // 0 1 1 1 1 1 1 5
        while(left < right) {
            var mid = (right - left) / 2 + left;
            
            if(nums[mid] < target) {
                left = mid + 1;
            } else if(nums[mid] > target) {
                right = mid - 1;
            } else {
                right = mid;            
            }
        }
        
        if(left != right) {
            return -1;
        }
        
        return nums[left] == target ? left : -1;
    }
    
    private int FindRight(int[] nums, int target) {
        var left = 0;
        var right = nums.Length - 1;
        // 0 1 1 1 1 1 1 5
        while(left < right) {
            var mid = (int)Math.Ceiling((right - left) / 2f + left);
            
            if(nums[mid] < target) {
                left = mid + 1;
            } else if(nums[mid] > target) {
                right = mid - 1;
            } else {
                left = mid;            
            }
        }
        
        if(left != right) {
            return -1;
        }
        
        return nums[left] == target ? left : -1;
    }
}