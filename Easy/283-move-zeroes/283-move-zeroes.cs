public class Solution {
    public void MoveZeroes(int[] nums) {
        var nextValidPos = 0;
        var curPos = 0;
        
        while(curPos < nums.Length) {
            if(nums[curPos] == 0) {
                curPos++;
                continue;
            }
            
            nums[nextValidPos] = nums[curPos];
            nextValidPos++;
            curPos++;
        }
        
        while(nextValidPos < nums.Length) {
            nums[nextValidPos] = 0;
            nextValidPos++;
        }
    }
}