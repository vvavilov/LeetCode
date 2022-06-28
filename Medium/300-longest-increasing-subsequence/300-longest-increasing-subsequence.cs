
public class Solution {
    public int LengthOfLIS(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }

        var length = new int[nums.Length];
        length[0] = 1;
                
        for(int i = 1; i < nums.Length; i++) {
            var max = 1;

            for(int j = 0; j < i; j++) {
                if(nums[j] < nums[i]) {
                    max = Math.Max(length[j] + 1, max);
                }
            }

            length[i] = max;
        }
        
        return length.Max();
    }
}