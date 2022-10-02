public class Solution {
    public int SwimInWater(int[][] grid) {
        if(grid.Length == 0) {
            return 0;
        }

        var directions = new (int y, int x)[] {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };

        var pq = new PriorityQueue<(int y, int x), int>();
        var visited = new HashSet<(int y, int x)>();

        var max = grid[0][0];
        pq.Enqueue((0, 0), grid[0][0]);
        visited.Add((0, 0));

        while(pq.Count > 0) {
            var cell = pq.Dequeue();
            max = Math.Max(max, grid[cell.y][cell.x]);

            if(cell.y == grid.Length - 1 && cell.x == grid[0].Length - 1) {
                return max;
            }

            foreach(var dir in directions) {
                (int y, int x) neigh = (cell.y + dir.y, cell.x + dir.x);

                if(neigh.x < 0 || neigh.x == grid[0].Length || neigh.y < 0 || neigh.y == grid.Length) {
                    continue;
                }

                if(visited.Contains(neigh)) {
                    continue;
                }

                visited.Add(neigh);
                pq.Enqueue(neigh, grid[neigh.y][neigh.x]);
            }

        }

        return -1;
    }
}