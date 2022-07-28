public class Solution {
    public int MaximalSquare(char[][] matrix) {
        // If m or n 0 -> early return;
        
        var dp = new int[matrix.Length][];
        
        for(int i = 0; i < dp.Length; i++) {
            dp[i] = new int[matrix[0].Length];
            Array.Fill(dp[i], -1);
        }
        
        var max = 0;

        for(int i = 0; i < matrix.Length; i++) {
            for(int j = 0; j < matrix[0].Length; j++) {
                max = Math.Max(max, TopDown(matrix, i, j, dp));
            }
        }
        
        return max * max;
    }
    
    private int TopDown(char[][] matrix, int i, int j, int[][] dp) {
        var val = matrix[i][j];

        if(dp[i][j] != -1) {
            return dp[i][j];
        }
        
        if(i == 0 || j == 0 || val == '0') {
            dp[i][j] = val == '0' ? 0 : 1;
            return dp[i][j];
        }
        
        var top = TopDown(matrix, i - 1, j, dp);
        var left = TopDown(matrix, i, j - 1, dp);
        var right = TopDown(matrix, i - 1, j - 1, dp);
        
        dp[i][j] = 1 + Math.Min(Math.Min(top, left), right);
        return dp[i][j];
    }
}