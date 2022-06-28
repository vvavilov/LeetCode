public class Solution {
    public void MoveZeroes(int[] nums) {
        var nextPos = 0;
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] != 0) {
                var val = nums[i];
                nums[i] = 0;
                nums[nextPos] = val;

                nextPos++;
            }
        }
    }
}