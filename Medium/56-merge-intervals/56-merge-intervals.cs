public class Solution {
    public int[][] Merge(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        List<int[]> result = new();
        
        
        for(int i = 1; i < sorted.Length; i++) {
            var previus = sorted[i - 1];
            var current = sorted[i];
            
            if(IsOverlaps(previus, current)) {
                var merged = Merge(current, previus);
                sorted[i] = merged;
                continue;
            }
            
            result.Add(previus);
        }
        
        result.Add(sorted[sorted.Length - 1]);
        return result.ToArray();
    }
    
    private bool IsOverlaps(int[] left, int[] right) {
        return left[1] >= right[0];
    }
    
    private int[] Merge(int[] left, int[] right) {
        var start = Math.Min(left[0], right[0]);
        var end = Math.Max(left[1], right[1]);
        
        return new int[] { start, end };
    }
}
