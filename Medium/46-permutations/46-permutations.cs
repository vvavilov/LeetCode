public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        
        Permute(nums, result, new HashSet<int>());
        
        return result;
    }
    
    private void Permute(int[] nums, List<IList<int>> result, HashSet<int> acc) {
        if(acc.Count == nums.Length) {
            result.Add(new List<int>(acc));
            return;
        }
        
        for(int i = 0; i < nums.Length; i++) {
            if(acc.Contains(nums[i])) {
                continue;
            }

            acc.Add(nums[i]);
            Permute(nums, result, acc);
            acc.Remove(nums[i]);
        }
    }
}