public class Solution {
    public int UniquePaths(int m, int n) {
        var paths = new int[m][];
        for(int i = 0; i < m; i++) {
            paths[i] = new int[n];
            paths[i][0] = 1;
        }
        Array.Fill(paths[0], 1);
        
        paths[0][0] = 1;
        for(int i = 1; i < m; i++) {
            for(int j = 1; j < n; j++) {
                var leftCount = paths[i][j-1];
                var topCount = paths[i - 1][j];
                paths[i][j] = leftCount + topCount;
            }
        }
        
        return paths[m-1][n-1];
    }
}