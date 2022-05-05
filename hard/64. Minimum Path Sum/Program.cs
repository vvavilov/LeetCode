public class Solution {
    public int MinPathSum(int[][] grid) {
        //Fill 0-row
        for(int i = 1; i < grid[0].Length; i++) {
            grid[0][i] = grid[0][i-1] + grid[0][i];
        }
        
        //Fill 0-column
        for(int i = 1; i < grid.Length; i++) {
            grid[i][0] = grid[i-1][0] + grid[i][0];
        }
        
        for(int i = 1; i < grid.Length; i++) {
            for(int j = 1; j < grid[0].Length; j++) {
                grid[i][j] = Math.Min(grid[i-1][j], grid[i][j-1]) + grid[i][j];

            }
        }
        
        return grid[grid.Length - 1][grid[0].Length - 1];
    }
}