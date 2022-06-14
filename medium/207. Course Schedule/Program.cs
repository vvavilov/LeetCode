public class SolutionDfs {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = BuildGraph(numCourses, prerequisites);
        var processed = new HashSet<int>();
        
        for(int i = 0; i < numCourses; i++) {
            if(HasCycle(graph, i, new HashSet<int>(), processed)) {
                return false;
            }
        }
        
        return true;
        
        
    }
    
    private bool HasCycle(List<List<int>> graph, int node, HashSet<int> processing, HashSet<int> processed) {
        if(processed.Contains(node)) {
            return false;
        }
        
        if(processing.Contains(node)) {
            return true;
        }
        
        processing.Add(node);
        foreach(var neigh in graph[node]) {
            if(HasCycle(graph, neigh, processing, processed)) {
                return true;
            }
        }
        
        processed.Add(node);        
        return false;
    }
    
    private List<List<int>> BuildGraph(int n, int[][] prereq) {
        List<List<int>> graph = new();
        
        for(int i = 0; i < n; i++) {
            graph.Add(new List<int>());
        }
        
        for(int i = 0; i < prereq.Length; i++) {
            var dependsOn = prereq[i][1];
            var dependy = prereq[i][0];
            graph[dependsOn].Add(dependy);
        }
        
        return graph;
    }
}

public class SolutionTopological {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = BuildGraph(numCourses, prerequisites);
        
        var inboundCount = new int[numCourses];
        
        foreach(var node in graph) {
            foreach(var child in node) {
                inboundCount[child]++;
            }
        }
        
        Queue<int> queue = new();
        int processedCount = 0;
        
        for(int i = 0; i < inboundCount.Length; i++) {
            if(inboundCount[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        while(queue.Count > 0) {
            var node = queue.Dequeue();
            processedCount++;
            
            foreach(var child in graph[node]) {
                inboundCount[child]--;
                
                if(inboundCount[child] == 0) {
                    queue.Enqueue(child);
                }
            }
        }
        
        return numCourses == processedCount;
    }
    
    private List<List<int>> BuildGraph(int n, int[][] prereq) {
        List<List<int>> graph = new();
        
        for(int i = 0; i < n; i++) {
            graph.Add(new List<int>());
        }
        
        for(int i = 0; i < prereq.Length; i++) {
            var dependsOn = prereq[i][1];
            var dependy = prereq[i][0];
            graph[dependsOn].Add(dependy);
        }
        
        return graph;
    }
}