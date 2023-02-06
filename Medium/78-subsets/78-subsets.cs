public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> result = new();
        Backtrack(nums, 0, new LinkedList<int>(), result);
        return result;
    }
    
    private void Backtrack(int[] nums, int pos, LinkedList<int> acc, List<IList<int>> result) {
        result.Add(new List<int>(acc));
        
        for(int i = pos; i < nums.Length; i++) {
            acc.AddLast(nums[i]);
            Backtrack(nums, i + 1, acc, result);
            acc.RemoveLast();
        }
    }
}