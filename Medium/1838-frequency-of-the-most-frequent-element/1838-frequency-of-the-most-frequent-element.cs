public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        Array.Sort(nums);
        var prefixSum = CalculatePrefixSum(nums);
        var maxLength = 1;
        var left = 0;
    
        for(var right = 1; right < nums.Length; right++) {
            var elementsNumber = right - left;
            var requiredSumToReachRight = nums[right] * elementsNumber;
            var currentSum = prefixSum[right - 1] - (left == 0 ? 0 : prefixSum[left - 1]);
            
            while(requiredSumToReachRight - currentSum > k) {
                left++;
                elementsNumber = right - left;
                requiredSumToReachRight = nums[right] * elementsNumber;
                currentSum = prefixSum[right - 1] - (left == 0 ? 0 : prefixSum[left - 1]);
            }
            
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
    
    private int[] CalculatePrefixSum(int[] nums) {
        var prefixSum = new int[nums.Length]; 
        var prev = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            prefixSum[i] = prev + nums[i];
            prev = prefixSum[i];
        }
        
        return prefixSum;
    }
}