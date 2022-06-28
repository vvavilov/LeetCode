public class Solution {
    public int OrangesRotting(int[][] grid) {
        var height = grid.Length;
        var width = grid[0].Length;
                
        var queue = new Queue<(int y, int x)>();
        
        var fresh = 0;
        var time = -1;
        for(int i = 0; i < height; i++) {
            for(int j = 0; j < width; j++) {
                if (grid[i][j] == 1) {
                    fresh++;
                }
                if (grid[i][j] == 2) {
                    queue.Enqueue((i, j));
                }
            }
        }
        
        if(fresh == 0) { return 0; }
        
        while(queue.Count > 0) {
            time++;
            var size = queue.Count;
            for (int k = 0; k < size; k++) {
                (var i, var j) = queue.Dequeue();
                var directions = new (int i, int j)[]{
                    (0, -1),
                    (-1, 0),
                    (0, 1),
                    (1, 0),
                };

                foreach(var direction in directions) {
                    var neighborY = i + direction.i;
                    var neighborX = j + direction.j;

                    if(
                        neighborY < 0
                        || neighborY == height
                        || neighborX < 0
                        || neighborX >= width
                        || grid[neighborY][neighborX] == 2
                        || grid[neighborY][neighborX] == 0
                    ) { continue; }

                    grid[neighborY][neighborX] = 2;
                    queue.Enqueue((neighborY, neighborX));
                    fresh--;
                }
            }
        }
        
        return fresh > 0 
            ? -1
            : time;
        
    }
}