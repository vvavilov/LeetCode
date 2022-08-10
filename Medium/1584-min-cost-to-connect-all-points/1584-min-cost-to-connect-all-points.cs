public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        // Array.Sort(new ByDistanceFromZeroComparer());
        if(points.Length == 0) {
            return 0;
        }
    
        var graph = BuildGraph(points);
        var visited = new bool[points.Length];
        var priorityQueue = new PriorityQueue<Edge, int>();        
        var processedCount = 1;
        var total = 0;
        visited[0] = true;

        foreach(var edge in graph[0]) {
            priorityQueue.Enqueue(edge, edge.Weight);
        }
        
        while(processedCount < points.Length) {
            var minEdge = priorityQueue.Dequeue();
            
            if(visited[minEdge.Left] && visited[minEdge.Right]) {
                continue;
            }
            
            total += minEdge.Weight;
            
            var newNode = visited[minEdge.Left] ? minEdge.Right : minEdge.Left;
            visited[newNode] = true;
            processedCount++;
            
            foreach(var edge in graph[newNode]) {
                priorityQueue.Enqueue(edge, edge.Weight);
            }
        }
        
        return total;        
    }
    
    private IList<Edge>[] BuildGraph(int[][] points) {
        var graph = new IList<Edge>[points.Length];
        
        for(int i = 0; i < points.Length; i++) {
            graph[i] = new List<Edge>();
        }
        
        
        for(int i = 0; i < points.Length; i++) {
            for(int j = i + 1; j < points.Length; j++) {
                var edge = new Edge {
                    Weight = Distance(points[i], points[j]),
                    Left = i,
                    Right = j
                };
                
                graph[i].Add(edge);
                graph[j].Add(edge);
            }
        }
        
        return graph;
    }
    
    private int Distance(int[] left, int[] right) {
        return Math.Abs(left[0] - right[0]) + Math.Abs(left[1] - right[1]);
    }
}

public class Edge {
    public int Weight {get;set;}
    public int Left {get;set;}
    public int Right {get;set;}
}

// public class ByDistanceFromZeroComparer : IComparer<int[]> {
//     public int Compare(int[] left, int right) {
//          var zero = new int[] { 0, 0 };
//         var leftDist = Distance(left, zero);
//         var rightDist = Distance(right, zero);

//         if(leftDist == rightDist) {
//             return 0;
//         }

//         if(leftDist > rightDist) {
//             return -1;
//         }

//         return 1;
//     }
// }
