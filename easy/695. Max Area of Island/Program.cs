public class Solution {
    int[][] grid;
    
    public int MaxAreaOfIsland(int[][] grid) {
        this.grid = grid;
        var maxSize = 0;
        
        for(int i = 0; i < grid.Length; i++) {
            for(int j = 0; j < grid[i].Length; j++) {
                maxSize = Math.Max(maxSize, AreaOfIsland(j,i));
            }
        }
        return maxSize;
    }
    
    private int AreaOfIsland(int x, int y) {
        var isOutside = y < 0 || y >= grid.Length || x < 0 || x >= grid[y].Length;

        
        if (isOutside || grid[y][x] == 0) { return 0; }
        
        grid[y][x] = 0;
        return 
            1
            + AreaOfIsland(x-1,y)
            + AreaOfIsland(x,y-1)
            + AreaOfIsland(x+1,y)
            + AreaOfIsland(x, y+1);   
    }
}