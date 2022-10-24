public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        List<IList<int>> result = new();
        CombinationSum(candidates, target, 0, result, new LinkedList<int>());
        
        return result;
    }
    
    private void CombinationSum(int[] candidates, int target, int index, IList<IList<int>> result, LinkedList<int> cur) {
        if(target == 0) {
            result.Add(new List<int>(cur));
            return;
        }
        
        if(target < 0) {
            return;
        }
        
        for(int i = index; i < candidates.Length; i++) {
            var curItem = candidates[i];
            cur.AddLast(curItem);
            CombinationSum(candidates, target - curItem, i, result, cur);
            cur.RemoveLast();
        }
    }
}