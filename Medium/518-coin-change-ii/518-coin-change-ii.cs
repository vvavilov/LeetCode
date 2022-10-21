public class Solution {
    int[] coins;

    public int Change(int amount, int[] coins) {
        this.coins = coins;
        Array.Sort(this.coins);
        return DP(amount, 0, new Dictionary<(int, int), int>());
    }
    
    public int DP(int amount, int minCoinPos, Dictionary<(int, int), int> dp) {
        
        if(amount == 0) {
            return 1;
        }
        
        var state = (amount, minCoinPos);
        
        if(dp.ContainsKey(state)) {
            return dp[state];
        }
    
        var count = 0;
        
        for(int i = minCoinPos; i < coins.Length; i++) {
            if(coins[i] > amount) {
                break;
            }
            
            count += DP(amount - coins[i], i, dp);
        }
        
        dp[state] = count; 
        return count;
        
    }
}