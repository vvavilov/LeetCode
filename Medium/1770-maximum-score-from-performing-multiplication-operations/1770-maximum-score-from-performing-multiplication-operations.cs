public class Solution {
    private int[][] cache;

    public int MaximumScore(int[] nums, int[] mult) {
        cache = new int[mult.Length][];

        for(int i = 0; i < mult.Length; i++) {
            cache[i] = new int[mult.Length];
        }
        
        for(int left = 0; left < mult.Length; left++) {
            var right = nums.Length - 1 + left - mult.Length + 1;
            cache[mult.Length - 1][left] = Math.Max(nums[left] * mult[mult.Length - 1], nums[right] * mult[mult.Length - 1]);
        }  
        
        for(int i = mult.Length - 2; i >= 0; i--) {
            for(int left = i; left >= 0; left--) {
                var right = nums.Length - 1 + left - i;
                var leftMax = nums[left] * mult[i] + cache[i+1][left+1];
                var rightMax = nums[right] * mult[i] + cache[i+1][left];
                
                cache[i][left] = Math.Max(leftMax, rightMax);
                
            }
        }
        
        return cache[0][0];
    }
}

