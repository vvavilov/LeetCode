public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        for(int i = 0; i < nums.Length; i++) {
            var n = Math.Abs(nums[i]);
            nums[n - 1] = 0 - Math.Abs(nums[n - 1]);
        }
        
        var result = new List<int>();
        
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] > 0) {
                result.Add(i+1);
            }
        }
        
        return result;
    }
}