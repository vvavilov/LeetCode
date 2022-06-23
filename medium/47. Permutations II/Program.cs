public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        Array.Sort(nums);
        
        List<IList<int>> result = new();
        BacktrackingPermute(nums, new HashSet<int>(), result);
        
        return result;
    }
    
    private void BacktrackingPermute(int[] nums, HashSet<int> acc, List<IList<int>> result) {
        if(acc.Count == nums.Length) {
            result.Add(new List<int>(acc.Select(x => nums[x])));
            return;
        }
        
        for(int i = 0; i < nums.Length; i++) {
            if(acc.Contains(i)) {
                continue;
            }
            
            if(i > 0 && nums[i] == nums[i-1] && !acc.Contains(i - 1)) {
                continue;
            }
            
            acc.Add(i);
            BacktrackingPermute(nums, acc, result);
            acc.Remove(i);
        }
        
    }
}