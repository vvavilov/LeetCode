public class Solution {
    public void Rotate(int[] nums, int k) {
        if(nums.Length <=1) { return; }
        k = k % nums.Length;
        Inverse(nums, 0, nums.Length - 1);
        Inverse(nums, 0, k-1);
        Inverse(nums, k, nums.Length - 1);

    }
    
    private void Inverse(int[] nums, int start, int end) {
        while(start < end) {
            var temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            
            start++;
            end--;
        }
    }
}