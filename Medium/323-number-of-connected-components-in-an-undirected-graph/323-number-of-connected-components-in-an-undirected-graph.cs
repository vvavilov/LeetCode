public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var roots = new int[n];
        
        for(int i = 0; i < roots.Length; i++) {
            roots[i] = i;
        }
        
        foreach(var edge in edges) {
            Union(roots, edge[0], edge[1]);
        }
        
        return SetsCount(roots);
    }

    
    private int SetsCount(int[] roots) {
        var count = 0;
        
        for(int i = 0; i < roots.Length; i++) {
            if(roots[i] == i) {
                count++;
            } 
        }
        
        return count;
    }
    
    private int Root(int[] roots, int i) {
        // Compression
        while(roots[i] != i) {
            i = roots[i];
        }
        
        return i;
    }
    
    public void Union(int[] roots, int i, int j) {
        // Ranking
        var leftRoot = Root(roots, j);
        var rightRoot = Root(roots, i);
        
        if(leftRoot == rightRoot) {
            return;
        }
        
        roots[rightRoot] = leftRoot;
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
}

public class SolutionOneArrayPass {
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