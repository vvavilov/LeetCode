public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var graph = BuildGraph(n, edges);
        var visited = new bool[n];
        var setsCount = 0;
        
        for(var i = 0; i < n; i++) {
            if(visited[i]) {
                continue;
            }
            
            setsCount++;
            Visit(i, visited, graph);
        }
        
        return setsCount;
    }
    
    private void Visit(int node, bool[] visited, List<int>[] graph) {
        if(visited[node]) {
            return;
        }

        visited[node] = true;
        
        foreach(var x in graph[node]) {
            Visit(x, visited, graph);
        }
    }
    
    private List<int>[] BuildGraph(int n, int[][] edges) {
        var graph = new List<int>[n];
        
        for(int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        
        foreach(var edge in edges) {
            var left = edge[0];
            var right = edge[1];
            
            graph[left].Add(right);
            graph[right].Add(left);
        }
        
        return graph;
    }
}