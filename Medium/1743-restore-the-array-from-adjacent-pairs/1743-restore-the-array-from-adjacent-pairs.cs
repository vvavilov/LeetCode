public class Solution {
    public int[] RestoreArray(int[][] adjacentPairs) {
        var head = FindHead(adjacentPairs);
        var adjacencyList = BuildAdjacencyList(adjacentPairs);
        var result = new List<int>();
        BuildArray(adjacencyList, head, new HashSet<int>(), result);
        return result.ToArray();
    }
    
    private void BuildArray(Dictionary<int, List<int>> adjacencyList, int node, HashSet<int> visited, List<int> result) {
        if(visited.Contains(node)) {
            return;
        }
        
        visited.Add(node);
        result.Add(node);
        
        foreach(var x in adjacencyList[node]) {
            BuildArray(adjacencyList, x, visited, result);
        }
    }
    
    private int FindHead(int[][] adjacentPairs) {
        Dictionary<int, int> count = new();
        
        foreach(var x in adjacentPairs) {
            count.TryGetValue(x[0], out var leftCount);
            count[x[0]] = leftCount + 1;
            count.TryGetValue(x[1], out var rightCount);
            count[x[1]] = rightCount + 1;
        }
        
        return count.Where(x => x.Value == 1).First().Key;
    }
    
    private Dictionary<int, List<int>> BuildAdjacencyList(int[][] adjacentPairs) {
        Dictionary<int, List<int>> result = new();
        
        foreach(var x in adjacentPairs) {
            if(!result.ContainsKey(x[0])) {
                result[x[0]] = new List<int>();
            }
            
            result[x[0]].Add(x[1]);
            
            if(!result.ContainsKey(x[1])) {
                result[x[1]] = new List<int>();
            }
            
            result[x[1]].Add(x[0]);
        }
        
        return result;
    }
}