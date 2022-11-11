public class Solution {
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        var busesPerStops = new Dictionary<int, List<int>>();
        
        for(int i = 0; i < routes.Length; i++) {
            foreach(var stop in routes[i]) {
                if(!busesPerStops.ContainsKey(stop)) {
                    busesPerStops[stop] = new List<int>();
                }
                
                busesPerStops[stop].Add(i);
            }
        }
        
        var visited = new HashSet<int>();
        var visitedBuses = new HashSet<int>();

        var queue = new Queue<(int stop, int buses)>();
        queue.Enqueue((source, 0));
        visited.Add(source);
        
        while(queue.Count > 0) {
            var item = queue.Dequeue();
            
            if(item.stop == target) {
                return item.buses;
            }
            
            var availableBuses = busesPerStops[item.stop];
            
            foreach(var bus in availableBuses) {
                if(visitedBuses.Contains(bus)) {
                    continue;
                }
                
                visitedBuses.Add(bus);
                
                foreach(var busStop in routes[bus]) {
                    if(visited.Contains(busStop)) {
                        continue;
                    }
                    
                    visited.Add(busStop);
                    queue.Enqueue((busStop, item.buses + 1));
                }
            }
        }
        
        return -1;
        
    }
}