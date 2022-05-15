public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new();
        
        Backtrack(nums, new List<int>(), result);
        
        return result;
    }
    
    private void Backtrack(int[] nums, List<int> used, List<IList<int>> result) {
        if(used.Count == nums.Length) {
            result.Add(new List<int>(used));
        }
        
        for(int i = 0; i < nums.Length; i++) {
            if(used.Contains(nums[i])) {
                continue;
            }
            used.Add(nums[i]);
            Backtrack(nums, used, result);
            used.Remove(nums[i]);
        }
    }
}