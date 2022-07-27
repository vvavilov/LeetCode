public class Solution {
    private int[][] cache;

    public int MaximumScore(int[] nums, int[] mult) {
        cache = new int[mult.Length][];

        for(int i = 0; i < mult.Length; i++) {
            cache[i] = new int[mult.Length];
        }
        
        return CalculateMaximum(nums, mult, 0, 0);
    }
    
    private int CalculateMaximum(int[] nums, int[] mult, int left, int i) {
        if(i == mult.Length) {
            return 0;
        }
        
        var right = nums.Length - 1 + left - i;

        if(cache[left][i] != 0) {
            return cache[left][i];
        }
                
        var leftMax = nums[left] * mult[i] + CalculateMaximum(nums, mult, left + 1, i + 1);
        var rightMax = nums[right] * mult[i] + CalculateMaximum(nums, mult, left, i + 1);
        cache[left][i] = Math.Max(leftMax, rightMax);
        return cache[left][i];
    }
}