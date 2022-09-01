public class Solution {
    public int Racecar(int target) {
        var maxDistanceToTry = target * 2;
        var minDistanceToTry = 1;
        
        var visited = new HashSet<(int distance, int speed)>();
        var queue = new Queue<(int distance, int speed)>();
        
        queue.Enqueue((0, 1));
        
        var count = -1;
        while(queue.Count > 0) {
            count++;
            var statesCount = queue.Count;
            
            while(statesCount-- > 0) {
                var state = queue.Dequeue();

                if(state.distance == target) {
                    return count;
                }
                
                visited.Add(state);

                var distanceAfterAcceleration = state.distance + state.speed;

                if(distanceAfterAcceleration >= minDistanceToTry && distanceAfterAcceleration <= maxDistanceToTry) {
                    var speedAfterAcceleration = state.speed * 2;

                    if(!visited.Contains((distanceAfterAcceleration, speedAfterAcceleration))) {
                        queue.Enqueue((distanceAfterAcceleration, speedAfterAcceleration));
                    }
                }
                
                var speedAfterReversing = state.speed < 0 ? 1 : -1;

                if(state.distance < minDistanceToTry) {
                    continue;
                }

                if(!visited.Contains((state.distance, speedAfterReversing))) {
                    queue.Enqueue((state.distance, speedAfterReversing));
                }

            }
        }
        
        return -1;    
    }
}

// c = 0
// visited: 0 1, 1 2 
// 3 4, 1 -1,