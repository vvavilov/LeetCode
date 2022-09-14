public class Solution {
    public int GetFood(char[][] grid) {
        if(grid.Length == 0) {
            return 0;
        }
        
        var pathLength = -1;
        var start = FindStart(grid);
        var visited = new HashSet<(int y, int x)>();
        var queue = new Queue<(int y, int x)>();
        
        queue.Enqueue(start);
        
        while(queue.Count > 0) {
            pathLength++;
            var count = queue.Count;
            
            while(count-- > 0) {
                var cell = queue.Dequeue();
                var y= cell.y;
                var x = cell.x;

                if(y < 0 || y >= grid.Length || x < 0 || x >= grid[0].Length) {
                    continue;
                }

                if(visited.Contains((y, x))) {
                    continue;
                }
                
                visited.Add(cell);

                if(grid[y][x] == 'X') {
                    continue;
                }

                if(grid[y][x] == '#') {
                    return pathLength;
                }


                foreach(var dir in directions) {
                    queue.Enqueue((y + dir.y, x + dir.x));
                }
            }
        }   

        return -1;
    }
    
    private (int y, int x) FindStart(char[][] grid) {
        for(var i = 0; i < grid.Length; i++) {
            for(var j = 0; j < grid[0].Length; j++) {
                if(grid[i][j] == '*') {
                    return (i, j);
                }
            }
        }
        
        return (0, 0);
    }
    
    private (int y, int x)[] directions = new (int y , int x)[] {
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0)
    };
}