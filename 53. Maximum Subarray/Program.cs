﻿public class Solution {
    public int MaxSubArray(int[] nums) {
        if(nums.Length == 0) { return 0; }
        
        var mem = new int[nums.Length];
        mem[0] = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            mem[i] = mem[i-1] > 0
                ? nums[i] + mem[i-1]
                : nums[i];
        }
        
        return mem.Max();
    }
    
    public int MaxSubArrayBruteForce(int[] nums) {
        if(nums.Length == 0) { return 0; }
        
        var result = Int32.MinValue;
        for (int i = 0; i < nums.Length; i++) {
            var value = 0;
            for(int j = i; j < nums.Length; j++) {
                value += nums[j];
                
                if(value > result) {
                    result = value;
                }
            }
        }
        
        return result;
    }
}