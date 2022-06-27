public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        IEnumerable<(int y, int x)> GetPacificCells() {
            for(int i = 0; i < heights[0].Length; i++) {
                yield return (0, i);
            }
        
            for(int i = 0; i < heights.Length; i++) {
                yield return (i, 0);
            }
        }
        
        IEnumerable<(int y, int x)> GetAtlanticCells() {
            for(int i = 0; i < heights[0].Length; i++) {
                yield return (heights.Length - 1, i);
            }
        
            for(int i = 0; i < heights.Length; i++) {
                yield return (i, heights[0].Length - 1);
            }
        }
        
        var flowsToAtlantic = FlowsToOcean(heights, GetAtlanticCells());
        var flowsToPacific = FlowsToOcean(heights, GetPacificCells());
        
        List<IList<int>> result = new();
        
        foreach(var cell in flowsToAtlantic) {
            if(flowsToPacific.Contains(cell)) {
                result.Add(new List<int> { cell.y, cell.x });
            }
        }
        
        return result;
    }
    
    private HashSet<(int y, int x)> FlowsToOcean(int[][] heights, IEnumerable<(int y, int x)> oceanCells) {
        var stack = new Stack<(int y, int x)>();
        var visited = new HashSet<(int y, int x)>();
        
        foreach(var x in oceanCells) {
            stack.Push(x);
        }
        
        while(stack.Count > 0) {
            var cell = stack.Pop();
            visited.Add(cell);
            
            foreach(var neighbour in GetNeighbours(heights, cell)) {
                if(visited.Contains(neighbour)) {
                    continue;
                }

                if(heights[neighbour.y][neighbour.x] >= heights[cell.y][cell.x]) {
                    stack.Push(neighbour);
                }
            }
        }
        
        return visited;
    }
    
    private IEnumerable<(int y, int x)> GetNeighbours(int[][] cells, (int y, int x) cell) {
        (var y, var x) = cell;
        
        if(x > 0) {
            yield return (y, x - 1);
        }
        
        if(x < cells[0].Length - 1) {
            yield return (y, x + 1);
        }
        
        if(y > 0) {
            yield return (y - 1, x);
        }
        
        if(y < cells.Length - 1) {
            yield return (y + 1, x);
        }
    }
        
}