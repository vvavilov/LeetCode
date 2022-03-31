public class Solution {
    public int MaxProfit(int[] prices) {
        /*
            iterate 0 -> n with i
            set buy, sell
            calculate profit
            val < buy -> update buy
            val > sell -> update sell
            recalculate profit
            
            1 3 11 2 1 15
        
        */
        
        var max = Int32.MinValue;
        
        var sell = 0;
        var buy = 0;
        
        for(int i = 0; i < prices.Length; i++) {
            if(prices[i] > prices[sell]) {
                sell = i;
            }
            if(prices[i] < prices[buy]) {
                buy = i;
                sell = i;
            }
            max = Math.Max(max, prices[sell] - prices[buy]);
        }
        
        return max;
        
        
    }
}