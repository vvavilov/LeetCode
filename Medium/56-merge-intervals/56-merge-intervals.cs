public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals.Length == 0) {
            return new int[0][];
        }
        
        var sorted = SortByStart(intervals);
        return MergeSorted(sorted);
    }
    
    private int[][] SortByStart(int[][] input) {
        return input.OrderBy(x => x[0]).ToArray();
    }
    
    private int[][] MergeSorted(int[][] input) {
        List<int[]> result = new();
        
        var prevInterval = input[0];
        
        for(int i = 1; i < input.Length; i++) {
            if(!IsOverlaps(prevInterval, input[i])) {
                result.Add(prevInterval);
                prevInterval = input[i];
            } else {
                prevInterval = MergeTwoIntervals(prevInterval, input[i]);
            }
        }
        
        result.Add(prevInterval);
        return result.ToArray();
    }
    
    private bool IsOverlaps(int[] left, int[] right) {
        return right[0] <= left[1];
    }
    
    private int[] MergeTwoIntervals(int[] left, int[] right) {
        return new int[] {
            left[0],
            Math.Max(left[1], right[1])
        };
    }
}