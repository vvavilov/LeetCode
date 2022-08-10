public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        // Array.Sort(new ByDistanceFromZeroComparer());
        if(points.Length == 0) {
            return 0;
        }
    
        var visited = new bool[points.Length];
        var priorityQueue = new PriorityQueue<int, int>();        
        var processedCount = 0;
        var total = 0;

        visited[0] = true;

        for(int i = 0; i < points.Length; i++) {
            var distanceFromFirst = Distance(points[0], points[i]);
            priorityQueue.Enqueue(i, distanceFromFirst);
        }
        
        while(processedCount < points.Length - 1) {
            priorityQueue.TryDequeue(out var node, out var weight);
            
            if(visited[node]) {
                continue;
            }
            
            total += weight;
            processedCount++;
            visited[node] = true;
            
            for(int i = 0; i < points.Length; i++) {
                priorityQueue.Enqueue(i, Distance(points[node], points[i]));
            }
        }
        
        return total;        
    }
    
    
    private int Distance(int[] left, int[] right) {
        return Math.Abs(left[0] - right[0]) + Math.Abs(left[1] - right[1]);
    }
}