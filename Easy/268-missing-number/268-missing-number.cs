public class Solution {
    public int MissingNumber(int[] nums) {
        Array.Sort(nums);
        var left = 0;
        var right = nums.Length - 1;
        while(left <= right) {
            var mid = (right - left) / 2 + left;
            if(nums[mid] != mid) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        
        return left; 
    }
    public int MissingNumberSum(int[] nums) {
        var expectedSum = nums.Length;
        for(int i = 0; i < nums.Length; i++) {
            expectedSum += i;
            expectedSum -= nums[i];
        }
        
        return expectedSum;
    }
    
    public int MissingNumberXor(int[] nums) {
        var result = nums.Length;
        for(int i = 0; i < nums.Length; i++) {
            result ^= i;
            result ^= nums[i];
        }
        
        return result;
    }
}