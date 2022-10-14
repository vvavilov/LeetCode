public class Solution {
    public int MaximumDetonation(int[][] bombs) {
        if(bombs.Length == 0) {
            return 0;
        }

        var max = 0;
        
        for(int i = 0; i < bombs.Length; i++) {
            HashSet<int> visited = new();
            var affectedBombs = new Queue<int>();
            affectedBombs.Enqueue(i);
            visited.Add(i);
            var count = 0;
            
            while(affectedBombs.Count > 0) {
                var bomb = affectedBombs.Dequeue();
                count++;
                
                for(int j = 0; j < bombs.Length; j++) {
                    if(visited.Contains(j)) {
                        continue;
                    }
                    
                    if(!Overlaps(bombs[bomb], bombs[j])) {
                        continue;
                    }
                    
                    visited.Add(j);
                    affectedBombs.Enqueue(j);
                }
            }
            
            max = Math.Max(max, count);
        }

        return max;

    }

    private bool Overlaps(int[] bomb, int[] neighbour) {
        var distance = Math.Sqrt(Math.Pow(bomb[0] - neighbour[0], 2) + Math.Pow(bomb[1] - neighbour[1], 2));
        return distance <= bomb[2];
    }
}
