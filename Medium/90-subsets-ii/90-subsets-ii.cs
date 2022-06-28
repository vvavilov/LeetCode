public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        Subsets(nums, 0, new List<int>(), result);
        return result;
    }
    
    private void Subsets(int[] nums, int pos, List<int> acc, IList<IList<int>> result) {
        result.Add(new List<int>(acc));
        
        for(int i = pos; i < nums.Length; i++) {
            if(i > pos && nums[i] == nums[i - 1]) {
                continue;
            }
            
            acc.Add(nums[i]);
            Subsets(nums, i + 1, acc, result);
            acc.RemoveAt(acc.Count - 1);

        }
        
    }
}