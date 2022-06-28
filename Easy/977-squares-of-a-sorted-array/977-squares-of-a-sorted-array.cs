// -4 -2 -1 0 2 3
// -4 -2 -1 2 3
// 2 3
// -4 -2 -1

public class Solution {
    public int[] SortedSquares(int[] nums) {
        var result = new int[nums.Length];
        var first = 0;
        var last = nums.Length - 1;
        var index = nums.Length - 1;
        
        while(first <= last) {
            if(Math.Abs(nums[first]) > Math.Abs(nums[last])) {
                result[index] = nums[first] * nums[first];
                first++;
            } else {
                result[index] = nums[last] * nums[last];
                last--;
            }
            index--;
        }
        
        return result;
    }
}