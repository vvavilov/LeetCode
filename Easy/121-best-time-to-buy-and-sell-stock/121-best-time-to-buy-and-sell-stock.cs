public class Solution {
    public int MaxProfit(int[] prices) {
        var bestBuy = Int32.MaxValue;
        var bestProfit = 0;
        
        for(int i = 0; i < prices.Length; i++) {
            bestBuy = Math.Min(bestBuy, prices[i]);
            bestProfit = Math.Max(bestProfit, prices[i] - bestBuy);
        }
        
        return bestProfit;
        
        
    }
}