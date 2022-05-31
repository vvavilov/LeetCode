public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        List<IList<int>> result = new();
        Array.Sort(candidates);
        Combination(candidates, target, 0, result, new LinkedList<int>());        
        return result;
    }
    
    private void Combination(int[] candidates, int target, int index, List<IList<int>> result, LinkedList<int> accum) {
        if(target < 0) {
            return;
        }
        
        if(target == 0) {
            result.Add(new List<int>(accum));
            return;
        }
        
        for(int i = index; i < candidates.Length; i++) {
            var item = candidates[i];
            if(i > index && item == candidates[i-1]) {
                continue;
            }

            accum.AddLast(item);
            Combination(candidates, target - item, i + 1, result, accum);
            accum.RemoveLast();
        }   
    }
}