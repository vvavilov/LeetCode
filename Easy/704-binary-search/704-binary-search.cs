public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;
        
        while(l <= r) {
            var mid = (r - l) / 2 + l;
            if(nums[mid] == target) {
                return mid;
            }
            if(nums[mid] > target) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        
        return -1;
    }
}