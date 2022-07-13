public class Solution {
    public int FindMin(int[] nums) {
        if(nums.Length == 0) {
            return -1;
        }
        
        
        var first = nums[0];

        if(nums.Length == 1) {
            return first; 
        }
        
        var isNotRotated = first < nums[nums.Length - 1];
        
        if(isNotRotated) {
            return first;
        }
        
        var start = 1;
        var end = nums.Length - 1;
        
        while(start < end) {
            var mid = (end - start) / 2 + start;
            
            if(nums[mid] > first) {
                // mid is a part of head
                start = mid + 1;
            } else {
                
                // mid is a part of tail
                end = mid;
            }
        }
        
        return nums[start];
    }
}