public class Solution {
    
    private (int y, int x)[] directions = new (int y , int x)[] {
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0)
    };
    
    public int ShortestPath(int[][] grid, int k) {
        if(grid.Length == 0) {
            return 0;
        }
        
        int rows = grid.Length, cols = grid[0].Length;

        if (k >= rows + cols - 2) {
            return rows + cols - 2;
        }
        
        var length = -1;
        var visited = new HashSet<(int y, int x, int k)>();
        var queue = new Queue<(int y, int x, int k)>();
        
        queue.Enqueue((0, 0, k));

        while(queue.Count > 0) {
            var count = queue.Count;
            length++;

            while(count-- > 0) {
                var cell = queue.Dequeue();
                var y= cell.y;
                var x = cell.x;
                var removeCount = cell.k;
                
                if(cell.y == grid.Length - 1 && cell.x == grid[0].Length - 1) {
                    return length;
                }


                if(grid[y][x] == 1) {
                     removeCount--;
                }

                foreach(var dir in directions) {
                    var neighX = x + dir.x;
                    var neighY = y + dir.y;
                    
                    if(neighY < 0 || neighY >= grid.Length || neighX < 0 || neighX >= grid[0].Length) {
                        continue;
                    }
                    
                    if(visited.Contains((neighY, neighX, removeCount))) {
                        continue;
                    }
                    
                    if(grid[neighY][neighX] == 1 && removeCount == 0) {
                        continue;
                    }

                    // Console.WriteLine($"{y + dir.y}, {x + dir.x}, {removeCount}");
                    visited.Add((y + dir.y, x + dir.x, removeCount));
                    queue.Enqueue((y + dir.y, x + dir.x, removeCount));
                }
            }
        }

        return -1;
    }
}

// 0 0 1 0
