public class Solution {
    public void NextPermutation(int[] nums) {
        var max = nums[nums.Length - 1];
        var curPos = nums.Length - 1;
        
        while(curPos >= 0 && nums[curPos] >= max) {
            max = nums[curPos];
            curPos--;
        }
        
        if(curPos < 0) {
            Array.Reverse(nums);
            return;
        }
        
        var digitToReplace = nums[curPos];
        var biggerThanReplacable = Int32.MaxValue;
        var minPos = 0;
        
        
        for(var i = curPos + 1; i < nums.Length; i++) {
            if(nums[i] > digitToReplace && nums[i] <= biggerThanReplacable) {
                minPos = i;
                biggerThanReplacable = nums[i];
            }
        }
        
        
        
        var temp = nums[minPos];
        nums[minPos] = nums[curPos];
        nums[curPos] = temp;
        Array.Reverse(nums, curPos + 1, nums.Length - curPos - 1);
    }
}