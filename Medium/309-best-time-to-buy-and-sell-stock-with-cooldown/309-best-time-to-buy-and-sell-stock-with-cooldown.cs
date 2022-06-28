public class Solution {
    public int MaxProfit(int[] prices) {
        var profit = new Profit[prices.Length];
        profit[0] = new Profit {
            HasStock = 0 - prices[0],
            JustSold = 0,
            ReadyToBuy = 0,
        };
        
        for(int i = 1; i < prices.Length; i++) {
            var prev = profit[i-1];
            profit[i] = new Profit {
                JustSold = prev.HasStock + prices[i],
                ReadyToBuy = Math.Max(prev.JustSold, prev.ReadyToBuy),
                HasStock = Math.Max(prev.ReadyToBuy - prices[i], prev.HasStock)
            };
        }
        
        var lastDay = profit[profit.Length - 1];
        return Math.Max(lastDay.JustSold, lastDay.ReadyToBuy);
    }
}

public record struct Profit {
    public int HasStock { get; init; }
    public int JustSold { get; init; }
    public int ReadyToBuy { get; init; }
}