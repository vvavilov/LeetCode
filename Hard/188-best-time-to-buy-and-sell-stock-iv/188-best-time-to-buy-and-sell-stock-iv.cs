public class Solution {
    public int MaxProfit(int k, int[] prices) {
        return DP(0, false, prices, k, new Dictionary<(int day, int available, bool hold), int>());
    }
    
    private int DP(int day, bool holdStock, int[] prices, int available, Dictionary<(int day, int available, bool hold), int> dp) {
        if(available == 0) {
            return 0;
        }
        
        if(day == prices.Length) {
            return 0;
        }
        
        if(dp.ContainsKey((day, available, holdStock))) {
            return dp[(day, available, holdStock)];
        }
        
        var sell = 0;
        var buy = 0;
        
        if(holdStock) {
            sell = prices[day] + DP(day + 1, false, prices, available - 1, dp);
        } else {
            buy = -prices[day] + DP(day + 1, true, prices, available, dp);
        }
        
        var nothing = DP(day + 1, holdStock, prices, available, dp);
        dp[(day, available, holdStock)] = Math.Max(Math.Max(sell, buy), nothing);
        return dp[(day, available, holdStock)];
    }
    
    /*
        var sell = prev + prices[n];
        var buy = prev - prices[n];
        var nothing = prev
    */
}