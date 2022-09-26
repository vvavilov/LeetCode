public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        if(grid.Length == 0) {
            return 0;
        }

        if(grid[0][0] == 1 || grid[grid.Length - 1][grid[0].Length - 1] == 1) {
            return -1;
        }

        if(grid.Length == 1 && grid[0].Length == 1) {
            return 1;
        }

        var directions = new (int y, int x)[] {
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1),
            (-1, -1),
            (-1, 0),
            (-1, 1)
        };
        
        var visited = new HashSet<(int y, int x)>();
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue((0, 0));
        visited.Add((0, 0));
        var length = 1;

        while(queue.Count > 0) {
            var count = queue.Count;
            length++;

            while(count-- > 0) {
                var cell = queue.Dequeue();
                visited.Add(cell);

                foreach(var dir in directions) {
                    (int y, int x) neigh = (cell.y + dir.y, cell.x + dir.x);

                    if(neigh.y == grid.Length - 1 && neigh.x == grid[0].Length - 1) {
                        return length;
                    }
                    

                    if(neigh.y < 0 || neigh.y == grid.Length || neigh.x < 0 || neigh.x == grid[0].Length) {
                        continue;
                    }

                    if(visited.Contains(neigh) || grid[neigh.y][neigh.x] == 1) {
                        continue;
                    }
                    
                    visited.Add(neigh);
                    queue.Enqueue(neigh);
                }
            }
        }

        return -1;

    }
}