public class Solution {
    public int MaximalSquare(char[][] matrix) {
        // If m or n 0 -> early return;
        
        var dp = new int[matrix.Length][];
        
        for(int i = 0; i < dp.Length; i++) {
            dp[i] = new int[matrix[0].Length];
            Array.Fill(dp[i], -1);
        }
        
        var maxSoFar = 0;
        
        for(int i = 0; i < matrix.Length; i++) {
            dp[i][0] = matrix[i][0] == '0' ? 0 : 1;
            
            if(dp[i][0] == 1) {
                maxSoFar = 1;
            }
        }
        
        for(int i = 0; i < matrix[0].Length; i++) {
            dp[0][i] = matrix[0][i] == '0' ? 0 : 1;
            
            if(dp[0][i] == 1) {
                maxSoFar = 1;
            }
        }
        
        var max = 0;

        for(int i = 1; i < matrix.Length; i++) {
            for(int j = 1; j < matrix[0].Length; j++) {
                if(matrix[i][j] == '0') {
                    dp[i][j] = 0;
                    continue;
                }
                
                var top = dp[i - 1][j];
                var left =  dp[i][j - 1];
                var topLeft = dp[i - 1][j - 1];
                
                dp[i][j] = 1 + Math.Min(Math.Min(top, left), topLeft);
                
                maxSoFar = Math.Max(maxSoFar, dp[i][j]);
            }
        }
        
        return maxSoFar * maxSoFar;
    }
}