public class Solution {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var queue = new Queue<string>();
        var indegrees = new Dictionary<string, int>();
        var ingredientsNeededFor = new Dictionary<string, List<string>>();
        
        foreach(var x in supplies) {
            indegrees.Add(x, 0);
        }
        
        
        for(int i = 0; i < ingredients.Count; i++) {
            indegrees.Add(recipes[i], ingredients[i].Count);
            
            foreach(var x in ingredients[i]) {
                ingredientsNeededFor.TryGetValue(x, out var forList);
                
                if(forList == null) {
                    ingredientsNeededFor[x] = new List<string>();
                }
                
                ingredientsNeededFor[x].Add(recipes[i]);
            }
            
        }
        
        foreach(var x in indegrees) {
            if(x.Value == 0) { 
                queue.Enqueue(x.Key);
            }
        }
        
        while(queue.Count > 0) {
            var ingredient = queue.Dequeue();
            
            if(!ingredientsNeededFor.ContainsKey(ingredient)) {
                continue;
            }
            
            var neededFor = ingredientsNeededFor[ingredient];
            
            foreach(var x in neededFor) {
                indegrees[x]--;
                
                if(indegrees[x] == 0) {
                    queue.Enqueue(x);
                }
            }
        }
        
        var result = new List<string>();
        
        foreach(var x in recipes) {
            if(indegrees[x] == 0) {
                result.Add(x);
            }
        }
        
        return result;
    }
}

public class SolutionDfs {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var prepared = new Dictionary<string, bool>();
        var graph = BuildGraph(recipes, ingredients, supplies);

        var result = new List<string>();

        foreach(var recipe in recipes) {
            if(Dfs(graph, recipe, prepared)) {
                result.Add(recipe);
            }   
        }

        return result;
    }

    private bool Dfs(Dictionary<string, IList<string>> graph, string ingredient, Dictionary<string, bool> prepared) {       
        if(prepared.ContainsKey(ingredient)) {
            return prepared[ingredient];
        }

        if(!graph.ContainsKey(ingredient)) {
            prepared[ingredient] = false;
            return false;
        }
        

        prepared[ingredient] = false;

        foreach(var subIngredient in graph[ingredient]) {
            if(Dfs(graph, subIngredient, prepared) == false) {
                return false;
            }
        }

        prepared[ingredient] = true; 
        return true;
    }

    private Dictionary<string, IList<string>> BuildGraph(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var graph = new Dictionary<string, IList<string>>();

        for(int i = 0; i < recipes.Length; i++) {
            var ingrediensList = ingredients[i];
            graph[recipes[i]] = new List<string>();

            foreach(var x in ingrediensList) {
                graph[recipes[i]].Add(x);
            }
        }
        
        foreach(var x in supplies) {
            graph[x] = new List<string>();
        }

        return graph;
    }
}