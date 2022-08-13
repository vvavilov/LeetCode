public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var graph = BuildGraph(equations, values);
        var result = new double[queries.Count];
        
        for(int i = 0; i < queries.Count; i++) {
            var from = queries[i][0];
            var to = queries[i][1];
            
            if(!graph.ContainsKey(from) || !graph.ContainsKey(to)) {
                result[i] = -1;
                continue;
            }

            result[i] = Dfs(graph, from, to, new HashSet<string>());
        }
        
        return result;
        
    }
    
    private double Dfs(Dictionary<string, List<(string node, double value)>> graph, string from, string to, HashSet<string> visited) {
        if(from == to) {
            return 1;
        }
        
        var adj = graph[from];
        visited.Add(from);

        foreach(var x in adj) {
            if(visited.Contains(x.node)) {
                continue;
            }
                
            var childResult = Dfs(graph, x.node, to, visited);
            
            if(childResult == -1) {
                continue;
            }
            
            return x.value * childResult;
        }
        
        return -1;
    }
    
    private Dictionary<string, List<(string node, double value)>> BuildGraph(IList<IList<string>> equations, double[] values) {
        var dict = new Dictionary<string, List<(string, double)>>();
        
        for(int i = 0; i < equations.Count; i++) {
            var from = equations[i][0];
            var to = equations[i][1];
            
            if(!dict.ContainsKey(from)) {
                dict[from] = new List<(string, double)>();
            }
            
            if(!dict.ContainsKey(to)) {
                dict[to] = new List<(string, double)>();
            }
            
            dict[from].Add((to, values[i]));
            dict[to].Add((from, 1 / values[i]));
        }
        
        return dict;
    }
    
}