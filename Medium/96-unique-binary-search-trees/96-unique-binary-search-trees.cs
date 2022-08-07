public class Solution {
    public int NumTrees(int n) {
        // We don't actually nead exact trees, 2 trees of the same number of nodes give the same count;
        var countForSize = new int[n + 1];
        
        countForSize[0] = 1;
        countForSize[1] = 1;
        
        for(int length = 2; length <= n; length++) {
            for(int i = 0; i < length; i++) {
                var leftSize = i;
                var rightSize = length - 1 - leftSize;
                
                countForSize[length] += countForSize[leftSize] * countForSize[rightSize];
            }
        }
        
        return countForSize[n];
    }

    public int NumTreesByBuildingIt(int n) {
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