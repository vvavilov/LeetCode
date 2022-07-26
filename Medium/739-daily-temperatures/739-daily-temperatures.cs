public class Solution {
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