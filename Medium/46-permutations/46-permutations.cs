public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new();
        Backtrack(nums, new HashSet<int>(), new LinkedList<int>(), result);
        return result;
        
    }
    
    private void Backtrack(int[] nums, HashSet<int> used, LinkedList<int> permutation, List<IList<int>> result) {
        if(permutation.Count == nums.Length) {
            result.Add(new List<int>(permutation));
            return;
        }
        
        foreach(var x in nums) {
            if(used.Contains(x)) {
                continue;
            }
            
            permutation.AddLast(x);
            used.Add(x);
            Backtrack(nums, used, permutation, result);
            permutation.RemoveLast();
            used.Remove(x);
        }
        
        return;
    }
}