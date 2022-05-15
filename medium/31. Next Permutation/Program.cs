public class Solution {
    public void NextPermutation(int[] nums) {
        for(int i = nums.Length - 1; i >= 0; i--) {
            var minBigger = Int32.MaxValue;
            var biggerPos = -1;
            
            for(int j = nums.Length - 1; j > i; j--) {
                if(nums[j] > nums[i]) {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    
                    Array.Reverse(nums, i + 1, nums.Length - i - 1);
                    return;
                }
            }
        }
        
        Array.Reverse(nums);
        
    }
}