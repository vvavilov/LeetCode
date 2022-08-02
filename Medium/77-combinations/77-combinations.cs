public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        List<IList<int>> result = new();
        Backtrack(n, 1, k, new LinkedList<int>(), result);
        return result;
    }
    
    private void Backtrack(int n, int start, int k, LinkedList<int> cur, List<IList<int>> result) {
        if(k == 0) {
            result.Add(new List<int>(cur));
            return;
        }
        
        for(int i = start; i <= n - k + 1; i++) {
            cur.AddLast(i);
            Backtrack(n, i + 1, k - 1, cur, result);
            cur.RemoveLast();
        }
        
    }
}