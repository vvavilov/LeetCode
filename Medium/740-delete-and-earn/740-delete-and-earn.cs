public class Solution {
    public int DeleteAndEarn(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        if(nums.Length == 1) {
            return nums[0];
        }
        
        var profit = new Dictionary<int, int>();
        var max = 0;

        foreach(var x in nums) {
            var current = 0;
            profit.TryGetValue(x, out current);
            profit[x] = current + x;
            max = Math.Max(max, x);
        }
        
        if(max == 1) {
            return profit[1];
        }
        
        var result = new int[max + 1];
        
        profit.TryGetValue(1, out result[1]);
        result[2] = Math.Max(profit.TryGetValue(2, out var val2) ? val2 : 0, result[1]);
        
        
        for(int i = 3; i <= max; i++) {
            var cur = profit.TryGetValue(i, out var value) ? value : 0;
            var maxSoFar = Math.Max(result[i - 2] + cur, result[i - 1]);
            result[i] = maxSoFar;
        }
        
        return result[max];
    }
}