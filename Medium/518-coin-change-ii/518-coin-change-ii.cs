

public class Solution {
    int[] coins;

    public int Change(int amount, int[] coins) {
        this.coins = coins;
        return DP(amount, 0, new Dictionary<(int, int), int>());
    }
    
    public int DP(int amount, int coinPos, Dictionary<(int, int), int> dp) {
        if(amount == 0) {
            return 1;
        }
        
        if(amount < 0 || coinPos == coins.Length) {
            return 0;
        }
        
        var state = (amount, coinPos);
        
        if(dp.ContainsKey(state)) {
            return dp[state];
        }
    
        var count = DP(amount - coins[coinPos], coinPos, dp) + DP(amount, coinPos + 1, dp);

        dp[state] = count; 
        return count;
        
    }
}