public class Solution {
    public int NumTrees(int n) {
        var dp = new int[n][];
        
        for(int i = 0; i < n; i++) {
            dp[i] = new int[n];
            dp[i][i] = 1;
        }
        
        for(int length = 2; length <= n; length++) {
            for(int i = 0; i + length - 1 < n; i++) {
                var left = i;
                var right = left + length - 1;
                dp[left][right] = dp[left + 1][right] + dp[left][right - 1];
                
                for(int j = left + 1; j <=  right - 1; j++) {
                    dp[left][right] += dp[left][j - 1] * dp[j + 1][right];    
                }
            }
        }
        
        return dp[0][n-1];
    }
    
    public int TopDown(int left, int right) {
        if(left >= right) {
            return 1;
        }
        
        var count = 0;
        
        for(int root = left; root <= right; root++) {
            count += TopDown(left, root - 1) * TopDown(root + 1, right);    
        }
        
        return count;
    }
}