public class Solution {
    public int[] DailyTemperatures(int[] tmps) {
        Stack<(int value, int index)> pending = new();    
        int[] result = new int[tmps.Length];
        
        for(int i = 0; i < tmps.Length; i++) {
            var cur = tmps[i];
            
            while(pending.Count > 0 && pending.Peek().value < cur) {
                var prev = pending.Pop();
                result[prev.index] = i - prev.index;
            }
            
            pending.Push((cur, i));
        }
        
        while(pending.Count > 0) {
            var prev = pending.Pop();
            result[prev.index] = 0;
        }
        
        return result;
        
    }
}

public class SolutionHashTable {
    public int[] DailyTemperatures(int[] tmps) {
        Dictionary<int, int> dict = new();

        var result = new int[tmps.Length];
        
        for(int i = tmps.Length - 1; i >= 0; i--) {
            dict[tmps[i]] = i;
            
            var min = Int32.MaxValue;
            
            for(int j = tmps[i] + 1; j <= 100; j++) {
                if(dict.ContainsKey(j)) {
                    min = Math.Min(min, dict[j]);
                }
            }
            
            result[i] = min == Int32.MaxValue ? 0 : min - i;
        }
        
        return result;
    }
}