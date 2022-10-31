public class Solution {
    public int TriangularSum(int[] nums) {
        while(nums.Length > 1) {
            var reduced = new int[nums.Length - 1];
            for(int i = 0; i < reduced.Length; i++) {
                reduced[i] = (nums[i] + nums[i + 1]) % 10;
            }
            
            nums = reduced;
        }
        
        return nums[0];
    }
}