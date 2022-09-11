public class Solution {
    public int MinMoves(int[] nums) {
        if(nums.Length < 2) {
            return 0;
        }
        
        Array.Sort(nums);
        var count = 0;
        var smallest = nums[0];
        var biggestPos = nums.Length - 1;
        
        while(nums[biggestPos] + count != smallest) {
            var diff = nums[biggestPos] + count - smallest;
            smallest = nums[biggestPos] + count;
            count += diff;
            biggestPos--;
        }
        
        return count;   
    }
}