public class Solution {
    public int Search(int[] nums, int target) {
        // 0 1 2 3 4 5 6 7
        // 7 0 1 2 3 4 5 6
        // (5 6 7) (0 1 2 3)
        //    t       h
        
        // [1]
        // [1 1 1]
        
        // handle not rotated
        // handle single
        // handle duplicates
        
        var left = 0;
        var right = nums.Length - 1;
        var tailStartsWith = nums[0];
        var targetIsInTail = target >= nums[0];
        
        while(left <= right) {
            var mid = (right - left) / 2 + left;
        
            if(nums[mid] == target) {
                return mid;
            }
            
            var isTail = nums[mid] >= tailStartsWith;
            
            if(target > nums[mid]) {
                if(isTail || !targetIsInTail) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            } else {
                if(!isTail || targetIsInTail) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }
        }
        
        return -1;
    }
}