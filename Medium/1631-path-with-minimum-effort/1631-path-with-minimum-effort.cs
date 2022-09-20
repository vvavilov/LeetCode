public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var directions = new (int y, int x)[] {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };

        if(heights.Length == 0) {
            return 0;
        }

        var pq = new PriorityQueue<(int y , int x), int>();
        var visited = new HashSet<(int y , int x)>();
        var maxDiff = 0;

        pq.Enqueue((0,0), 0);

        while(pq.Count > 0) {
            pq.TryDequeue(out var cell, out var diff);
            visited.Add(cell);
            maxDiff = Math.Max(diff, maxDiff);

            if(cell.y == heights.Length - 1 && cell.x == heights[0].Length - 1) {
                return maxDiff;
            }

            foreach(var dir in directions) {
                var neighY = cell.y + dir.y;
                var neighX = cell.x + dir.x;

                if(neighY < 0 || neighY >= heights.Length || neighX < 0 || neighX >= heights[0].Length) {
                    continue;
                }

                if(visited.Contains((neighY, neighX))) {
                    continue;
                }

                pq.Enqueue((neighY, neighX), Math.Abs(heights[cell.y][cell.x] - heights[neighY][neighX]));
            }
        }

        return -1;
    }
}
