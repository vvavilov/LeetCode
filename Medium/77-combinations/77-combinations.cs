public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        List<IList<int>> result = new();
        Combine(n, k, 1, result, new LinkedList<int>());
        
        return result;
    }
    
    private void Combine(int n, int k, int curN, IList<IList<int>> result, LinkedList<int> combination) {
        if(k == 0) {
            result.Add(new List<int>(combination));
            return;
        }
        
        for(int i = curN; i <= n - k + 1; i++) {
            combination.AddLast(i);
            Combine(n, k - 1, i + 1, result, combination);
            combination.RemoveLast();
        }
    }
}