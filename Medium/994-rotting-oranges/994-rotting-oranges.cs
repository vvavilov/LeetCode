public class Solution {
    public int OrangesRotting(int[][] grid) {
        var directions = new (int y, int x)[] {
            (0,1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };

        Queue<(int y, int x)> queue = new();
        var tick = 0;
        var fresh = 0;
        
        for(int i = 0; i < grid.Length; i++) {
            for(int j = 0; j < grid[0].Length; j++) {
                if(grid[i][j] == 2) {
                    queue.Enqueue((i, j));
                }
                
                if(grid[i][j] == 1) {
                    fresh++;
                }
            }
        }
        
        if(fresh == 0) {
            return 0;
        }
        
        while(queue.Count > 0) {
            var count = queue.Count;
            tick++;
            
            while(count-- > 0) {
                var cell = queue.Dequeue();

                foreach(var dir in directions) {
                    var neighY = cell.y + dir.y;
                    var neighX = cell.x + dir.x;
                    
                    if(neighY < 0 || neighX < 0 || neighY == grid.Length || neighX == grid[0].Length) {
                        continue;
                    }

                    if(grid[neighY][neighX] == 1) {
                        fresh--;
                        grid[neighY][neighX] = 0;
                        queue.Enqueue((neighY, neighX));
                    }
                }
            }
            
            if(fresh == 0) {
                return tick;
            }
            
        }
        
        
        return -1;
        
        
    }
}