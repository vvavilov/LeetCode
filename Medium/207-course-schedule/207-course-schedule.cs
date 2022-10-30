public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = BuildGraph(numCourses, prerequisites);
        return TopologicalSort(graph);
    }
    
    private List<int>[] BuildGraph(int n, int[][] prereq) {
        var graph = new List<int>[n];
        
        for(int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        
        foreach(var x in prereq) {
            graph[x[1]].Add(x[0]);
        }
        
        return graph;
    }
    
    private bool TopologicalSort(List<int>[] graph) {
        var inboundCount = new int[graph.Length];
        
        foreach(var node in graph) {
            foreach(var neigh in node) {
                inboundCount[neigh]++;
            }
        }
        
        Queue<int> nodes = new();
        var processedNodes = 0;
        
        for(int i = 0; i < inboundCount.Length; i++) {
            if(inboundCount[i] == 0) {
                nodes.Enqueue(i);
            }
        }
        
        while(nodes.Count > 0) {
            var node = nodes.Dequeue();
            processedNodes++;
            
            foreach(var x in graph[node]) {
                inboundCount[x]--;
                
                if(inboundCount[x] == 0) {
                    nodes.Enqueue(x);
                }
            }
            
        }
        
        return processedNodes == graph.Length;
    }
}