public class Solution {
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        var graph = BuildGraph(n, pipes, wells);
        
        var queue = new PriorityQueue<Edge, int>();
        var visited = new bool[n + 1];
        var processedCount = 0;
        var total = 0;
        
        AttachNode(0, graph, queue, visited);
        
        while(processedCount < n) {
            var edge = queue.Dequeue();
            
            if(visited[edge.Left] && visited[edge.Right]) {
                continue;
            }
            
            total += edge.Weight;
            processedCount++;
            var newNode = visited[edge.Left] ? edge.Right : edge.Left;
            AttachNode(newNode, graph, queue, visited);
        }
        
        return total;
    }
    
    private void AttachNode(int node, IList<Edge>[] graph, PriorityQueue<Edge, int> queue, bool[] visited) {
        visited[node] = true;
        
        foreach(var edge in graph[node]) {
            queue.Enqueue(edge, edge.Weight);
        }
    }
    
    private IList<Edge>[] BuildGraph(int n, int[][] edges, int[] wells) {
        var graph = new IList<Edge>[n + 1];
        
        for(int i = 0; i <= n; i++) {
            graph[i] = new List<Edge>();
        }
        
        for(int i = 0; i < n; i++) {
            graph[0].Add(new Edge {
                Weight = wells[i],
                Left = i + 1,
                Right = 0
            });
        }
        
        foreach(var x in edges) {
            var edge = new Edge {
                Weight = x[2],
                Left = x[0],
                Right = x[1]
            };
            
            graph[edge.Left].Add(edge);
            graph[edge.Right].Add(edge);
        }
        
        return graph;
    }
}

public class Edge {
    public int Weight;
    public int Left;
    public int Right;
}