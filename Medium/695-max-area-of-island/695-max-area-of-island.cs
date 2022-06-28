public class Solution {
    /*
    
      iterate i->n, j->n.
        - if 1 -> mark 0, DFS\BFS + 1
    
    */
    
    public int MaxAreaOfIsland(int[][] grid) {
        var max = Int32.MinValue;
        
        for(int i = 0; i< grid.Length; i++) {
            for(int j = 0; j< grid[0].Length; j++) {
                max = Math.Max(max, Area(grid, i,j));
            }
        }
        
        return max;
    }
    
    private int Area(int[][] grid, int i, int j) {
        if(i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length) {
            return 0;
        }
        
        if(grid[i][j] == 0) { return 0; }
        
        grid[i][j] = 0;
        return 1 + Area(grid, i-1,j) + Area(grid, i+1,j) + Area(grid, i, j+1) + Area(grid, i,j-1);
        
    }
}