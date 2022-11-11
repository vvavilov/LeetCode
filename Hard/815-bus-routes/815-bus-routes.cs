public class Solution {
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        var graph = BuildGraph(routes);
        var bestRides = new PriorityQueue<(int stop, int bus, int busesTaken), int>();
        // var busesUsed = new HashSet<int>();
        var visited = new HashSet<(int bus, int stop)>();
        
        if(!graph.ContainsKey(source)) {
            return -1;
        }
        
        if(source == target) {
            return 0;
        }
        
        foreach(var ride in graph[source]) {
            bestRides.Enqueue((ride.destination, ride.bus, 1), 1);
        }
        
        while(bestRides.Count > 0) {
            var ride = bestRides.Dequeue();
            
            if(ride.stop == target) {
                return ride.busesTaken;
            }
            
            visited.Add((ride.bus, ride.stop));
            
            if(!graph.ContainsKey(ride.stop)) {
                continue;
            }
            
            foreach(var nextRide in graph[ride.stop]) {
                if(visited.Contains((nextRide.bus, nextRide.destination))) {
                    continue;
                }
                
                var busesCount = nextRide.bus == ride.bus ? ride.busesTaken : (ride.busesTaken + 1);
                bestRides.Enqueue((nextRide.destination, nextRide.bus, busesCount), busesCount);
            }
        }
        
        return -1;
    }
    
    private Dictionary<int, List<(int destination, int bus)>> BuildGraph(int[][] routes) {
        Dictionary<int, List<(int destination, int bus)>> graph = new();
        
        for(int busPos = 0; busPos < routes.Length; busPos++) {
            var bus = routes[busPos]; 
            var prev = bus[0];
            
            for(int stopPos = 1; stopPos <= bus.Length; stopPos++) {
                var stop = stopPos == bus.Length ? bus[0] : bus[stopPos];
                
                graph.TryGetValue(prev, out var existing);
                graph[prev] = existing ?? new List<(int destination, int bus)>();
                graph[prev].Add((stop, busPos));
                prev = stop;
            }
            
            
        }
        
        return graph;
    }
}