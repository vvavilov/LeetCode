public class Solution {
    IDictionary<int, int> mem = new Dictionary<int, int>();
    public int CoinChange(int[] coins, int amount) {
        if(mem.ContainsKey(amount)) {
            return mem[amount];
        }
        
        if(amount < 0) {
            return -1;
        }
        
        if(amount == 0) {
            return 0;
        }
        
        var min = -1;
        
        for(int i = 0; i < coins.Length; i++) {
            var rest =  amount - coins[i];
            var child = CoinChange(coins, rest);
            if(child >= 0) {
                min = min == -1 
                    ? child + 1
                    : Math.Min(min, child + 1);
            }
        }
        
        mem[amount] = min;
        return min;

    }
    
}