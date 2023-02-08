public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length == 0) {
            return 0;
        }
        
        var max = 0;
        var stock = prices[0];
        
        foreach(var x in prices) {
            max = Math.Max(x - stock, max);
            stock = Math.Min(stock, x);
        }
        
        return max;
    }
}