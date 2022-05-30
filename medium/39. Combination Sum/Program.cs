public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        List<IList<int>> result = new();
        Array.Sort(candidates);
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
            
            if(i > index && curItem == candidates[i-1]) {
                continue;
            }
            
            cur.AddLast(curItem);
            CombinationSum(candidates, target - curItem, i, result, cur);
            cur.RemoveLast();
        }
    }
}