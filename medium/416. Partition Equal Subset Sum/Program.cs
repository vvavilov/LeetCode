public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        if(sum % 2 == 1) {
            return false;
        }
        
        var expectedSize = sum / 2;
        
        var result = new bool[nums.Length][];
        for(int i = 0; i < nums.Length; i++) {
            result[i] = new bool[sum + 1];
        }
        
        result[0][nums[0]] = true;
        
        for(int i = 1; i < nums.Length; i++) {
            var prevStep = result[i-1];
            var curStep = result[i];

            for(int j = 0; j <= expectedSize; j++) {
                curStep[nums[i]] = true;                
                if(prevStep[j]) {
                    curStep[j] = true;
                    curStep[j + nums[i]] = true;
                }
            }
        }
        
        return result.Any(step => step[expectedSize]);
    }
}