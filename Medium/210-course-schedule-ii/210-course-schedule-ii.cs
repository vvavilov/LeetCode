public enum State {
    Completed = 0,
    Ongoing = 1,
    Initial = 2,
}

public class Solution {
    public int[] FindOrder(int n, int[][] prereq) {
        var graph = BuildGraph(n, prereq);
        var state = new State[n];
        Array.Fill(state, State.Initial);
        Stack<int> result = new();
        
        for(int i = 0; i < n; i++) {
            var success = DfsVisit(i, graph, state, result);
            
            if(!success) {
                return Array.Empty<int>();
            }
        }        
        
        return result.ToArray();
    }
    
    private bool DfsVisit(int node, List<List<int>> graph, State[] state, Stack<int> stack) {
        if(state[node] == State.Completed) {
            return true;
        }
        
        if(state[node] == State.Ongoing) {
            return false;
        }
        
        state[node] = State.Ongoing;
        
        foreach(var neigh in graph[node]) {
            var success = DfsVisit(neigh, graph, state, stack);
            if(!success) {
                return false;
            }
        }
        
        state[node] = State.Completed;
        stack.Push(node);
        return true;
    }
    
    
    
    
    public int[] FindOrderBFS(int numCourses, int[][] prerequisites) {
        var graph = BuildGraph(numCourses, prerequisites);
        
        var inDegrees = new int[numCourses];

        foreach(var node in graph) {
            foreach(var neigh in node) {
                inDegrees[neigh]++;
            }
        }
        
        var queue = new Queue<int>();
        
        for(int i = 0; i < inDegrees.Length; i++) {
            if(inDegrees[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        var processed = 0;
        var result = new List<int>();
        
        while(queue.Count > 0) {
            var node = queue.Dequeue();
            processed++;
            result.Add(node);
            
            foreach(var neigh in graph[node]) {
                inDegrees[neigh]--;
                
                if(inDegrees[neigh] == 0) {
                    queue.Enqueue(neigh);
                }
            }
        }
        
        return processed == graph.Count
            ? result.ToArray()
            : Array.Empty<int>();
    }
    
    private List<List<int>> BuildGraph(int numCourses, int[][] prerequisites) {
        List<List<int>> graph = new();
        
        for(int i = 0; i < numCourses; i++) {
            graph.Add(new List<int>());
        }
        
        foreach(var prereq in prerequisites) {
            graph[prereq[1]].Add(prereq[0]);
        }
        
        return graph;
    }
}