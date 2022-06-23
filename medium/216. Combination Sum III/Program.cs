public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        List<IList<int>> result = new();
        
        Combination(1, k, n, new LinkedList<int>(), result);
        
        return result;
    }
    
    private void Combination(int startWith, int k, int n, LinkedList<int> acc, List<IList<int>> result) {
        if (k == 0 && n != 0) {
            return;
        }
        
        if(k == 0 && n == 0) {z
            result.Add(new List<int>(acc));
            return;
        }
        
        if(n < 0) {
            return;
        }
        
        for(int i = startWith; i < 10; i++) {
            acc.AddLast(i);
            Combination(i + 1, k - 1, n - i, acc, result);
            acc.RemoveLast();
        }
    }
}