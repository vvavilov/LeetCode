public class Solution {
    int count = 0;
    
    public int NumIslands(char[][] grid) {
        for(int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if(DetectIsland(grid, i, j)) {
                    count++;
                }
            }
        }
        return count;
    }
    
    private bool DetectIsland(char[][] grid, int y, int x) {
        if(!IsInBoundaries(grid, y, x)) {
            return false;
        }

        if(grid[y][x] == '0') {
            return false;
        }
        
        grid[y][x] = '0';
        
        List<(int, int)> directions = new List<(int, int)>() {
            (-1, 0),
            (0, 1),
            (1, 0),
            (0, -1)
        };
        
        foreach(var (nY, nX) in directions) {
            DetectIsland(grid, y + nY, x + nX);
        }
        
        return true;
    }
    
    private bool IsInBoundaries(char[][] grid, int y, int x) {
        return x >= 0
            && x < grid[0].Length
            && y >= 0
            && y < grid.Length;
    }
}