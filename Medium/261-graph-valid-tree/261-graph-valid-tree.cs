public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(n == 0) {
            return true;
        }
        
        var tree = BuildTree(n, edges);
        var visited = new bool[n];
        Queue<(int node, int parent)> queue = new();
        queue.Enqueue((0, -1));
        
        while(queue.Count > 0) {
            (var node, var parent) = queue.Dequeue();
            if(visited[node]) {
                return false;
            }
            
            visited[node] = true;
            
            foreach(var neighbour in tree[node]) {
                if(neighbour != parent) {
                    queue.Enqueue((neighbour, node));
                }
            }
        }
        
        return visited.All(x => x);
    }
    
    private List<int>[] BuildTree(int n, int[][] edges) {
        var tree = new List<int>[n];
        
        for(int i = 0; i < n; i++) {
            tree[i] = new List<int>();
        }
        
        for(int i = 0; i < edges.Length; i++) {
            var left = edges[i][0];
            var right = edges[i][1];
            tree[left].Add(right);
            tree[right].Add(left);
        }
        
        return tree;
    }
}