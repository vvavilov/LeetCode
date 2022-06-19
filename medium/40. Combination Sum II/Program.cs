public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        List<IList<int>> result = new();
        Backtrack(candidates, target, new List<int>(), result, 0);
        return result;
    }
    
    private void Backtrack(int[] candidates, int target, List<int> current, IList<IList<int>> result, int pos) {
        if(target == 0) {
            result.Add(new List<int>(current));
            return;
        }
        
        if(target < 0) {
            return;
        }
                
        for(int i = pos; i < candidates.Length; i++) {
            if(i > pos && candidates[i] == candidates[i-1]) {
                continue;
            }
            var val = candidates[i];
            current.Add(val);
            Backtrack(candidates, target - val, current, result, i + 1);
            current.RemoveAt(current.Count - 1);
        }
    }
}