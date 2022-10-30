public class Solution {
    public int NumIslands(char[][] grid) {
        if(grid.Length == 0) {
            return 0;
        }
        
        var total = 0;
        
        for(int i = 0; i < grid.Length; i++) {
            for(int j = 0; j < grid[0].Length; j++) {
                total += SinkIsland(grid, i, j);
            }
        }
        
        return total;
    }
    
    private int SinkIsland(char[][] grid, int y, int x) {
        if(y < 0 || x < 0 || y == grid.Length || x == grid[0].Length) {
            return 0;
        }
        
        if(grid[y][x] == '0') {
            return 0;
        }
        
        grid[y][x] = '0';
        
        var neigh = new (int y, int x)[] {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };
        
        foreach(var n in neigh) {
            SinkIsland(grid, y + n.y, x + n.x);
        }
        
        return 1;
    }
}