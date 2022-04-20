public class Solution {
    public int DP(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        var result = 0;
        
        var vals = new int[nums.Length];
        vals[0] = 1;
        
        for(int i = 1; i < nums.Length; i++) {
            vals[i] = 1;
            for (int j = 0; j < i; j++) {
                var prev = nums[j];
                var cur = nums[i];
                var prevL = vals[j];
                if(cur > prev) {
                    if(prevL + 1 > vals[i]) {
                        vals[i] = prevL + 1;
                    }
                }
            }
        }
        
        return vals.Max();
    }
}