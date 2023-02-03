public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        List<IList<int>> result = new();
        Backtrack(candidates, 0, new LinkedList<int>(), target, result);
        return result;
        
    }
    
    private void Backtrack(int[] candidates, int pos, LinkedList<int> acc, int rest, List<IList<int>> result) {
        if(rest == 0) {
            result.Add(new List<int>(acc));
            return;
        }
        
        if(rest < 0) {
            return;
        }
        
        for(int i = pos; i < candidates.Length; i++) {
            if(rest - candidates[i] < 0) {
                break;
            }
            
            acc.AddLast(candidates[i]);
            Backtrack(candidates, i, acc, rest - candidates[i], result);
            acc.RemoveLast();
        }
        
    }
}