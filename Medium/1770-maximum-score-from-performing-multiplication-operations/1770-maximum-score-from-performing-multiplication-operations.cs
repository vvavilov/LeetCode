public class Solution {
    private Dictionary<(int left, int i), int> dict = new();

    public int MaximumScore(int[] nums, int[] mult) {
        return CalculateMaximum(nums, mult, 0, 0);
    }
    
    private int CalculateMaximum(int[] nums, int[] mult, int left, int i) {
        var right = nums.Length - 1 + left - i;
        var key = (left, i);
        
        if(dict.ContainsKey(key)) {
            return dict[key];
        }
        
        if(i == mult.Length) {
            return 0;
        }
        
        var leftMax = nums[left] * mult[i] + CalculateMaximum(nums, mult, left + 1, i + 1);
        var rightMax = nums[right] * mult[i] + CalculateMaximum(nums, mult, left, i + 1);
        dict[key] = Math.Max(leftMax, rightMax);
        return dict[key];
    }
}