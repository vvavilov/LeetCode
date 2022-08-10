public class Solution {
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        var graph = BuildGraph(n, pipes, wells);
        
        var queue = new PriorityQueue<int, int>();
        var visited = new HashSet<int>();
        var total = 0;
        
        AttachNode(0, graph, queue, visited);
        
        while(visited.Count < n + 1) {
            queue.TryDequeue(out var node, out var weight);
            
            if(visited.Contains(node)) {
                continue;
            }
            
            total += weight;
            AttachNode(node, graph, queue, visited);
        }
        
        return total;
    }
    
    private void AttachNode(
        int node,
        IList<(int node, int weight)>[] graph,
        PriorityQueue<int, int> queue,
        HashSet<int> visited
    ) {
        visited.Add(node);
        
        foreach(var edge in graph[node]) {
            queue.Enqueue(edge.node, edge.weight);
        }
    }
    
    private IList<(int node, int weight)>[] BuildGraph(int n, int[][] edges, int[] wells) {
        var graph = new IList<(int node, int weight)>[n + 1];
        
        for(int i = 0; i <= n; i++) {
            graph[i] = new List<(int node, int weight)>();
        }
        
        for(int i = 0; i < n; i++) {
            graph[0].Add((i + 1, wells[i]));
        }

        foreach(var x in edges) {
            graph[x[0]].Add((x[1], x[2]));
            graph[x[1]].Add((x[0], x[2]));
        }
        
        return graph;
    }
}