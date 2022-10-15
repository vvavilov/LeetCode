public class Solution {
    public int MaximumScore(int[] scores, int[][] edges) {
        var bestNeighbours = new PriorityQueue<int, int>[scores.Length];
        
        for(int i = 0; i < scores.Length; i++) {
            bestNeighbours[i] = new PriorityQueue<int, int>();
        }
        
        foreach(var x in edges) {
            bestNeighbours[x[0]].Enqueue(x[1], scores[x[1]]);
            
            if(bestNeighbours[x[0]].Count > 3) {
                bestNeighbours[x[0]].Dequeue();
            }
            
            bestNeighbours[x[1]].Enqueue(x[0], scores[x[0]]);
            
            if(bestNeighbours[x[1]].Count > 3) {
                bestNeighbours[x[1]].Dequeue();
            }    
        }
        
        var graph = new List<int>[scores.Length];
        
        for(int i = 0; i < scores.Length; i++) {
            graph[i] = new List<int>();
            
            while(bestNeighbours[i].Count > 0) {
                graph[i].Add(bestNeighbours[i].Dequeue());
            }
        }
        
        
        
        var max = -1;
        
        foreach(var x in edges) {
            var left = x[0];
            var right = x[1];
            
            foreach(var leftNeigh in graph[left]) {
                if(leftNeigh == right) {
                    continue;
                }
                
                foreach(var rightNeigh in graph[right]) {
                    if(rightNeigh == left || leftNeigh == rightNeigh) {
                        continue;
                    }
                    
                    max = Math.Max(max, scores[right] + scores[left] + scores[leftNeigh] + scores[rightNeigh]);
                }
            }
        }
        
        return max;        
    }
}