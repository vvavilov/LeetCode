public class Solution {
    private List<int>[] BuildGraph(int[][] bombs) {
        var graph = new List<int>[bombs.Length];
        
        for(int i = 0; i < bombs.Length; i++) {
            graph[i] = new List<int>();
            
            for(int j = 0; j < bombs.Length; j++) {
                if(Overlaps(bombs[i], bombs[j])) {
                    graph[i].Add(j);
                }
            }
        }
        
        return graph;
    }
    
    public int MaximumDetonation(int[][] bombs) {
        var graph = BuildGraph(bombs);
        var max = 0;
        
        for(int i = 0; i < graph.Length; i++) {
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            
            queue.Enqueue(i);
            visited.Add(i);
            var count = 0;
            
            while(queue.Count > 0) {
                var bomb = queue.Dequeue();
                count++;
                
                foreach(var affected in graph[bomb]) {
                    if(visited.Contains(affected)) {
                        continue;
                    }
                    
                    visited.Add(affected);
                    queue.Enqueue(affected);
                }
            }
            
            max = Math.Max(max, count);
        }
        
        return max;

    }

    private bool Overlaps(int[] bomb, int[] neighbour) {
        var distance = Math.Sqrt(Math.Pow(bomb[0] - neighbour[0], 2) + Math.Pow(bomb[1] - neighbour[1], 2));
        return distance <= bomb[2];
    }
}
