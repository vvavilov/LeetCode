public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        List<int[]> result = new();
        
        var firstPos = 0;
        var secondPos = 0;
        firstList = firstList.OrderBy(x => x[0]).ToArray();
        secondList = secondList.OrderBy(x => x[0]).ToArray();
        
        while(firstPos < firstList.Length && secondPos < secondList.Length) {
            var firstInterval = firstList[firstPos];
            var secondInterval = secondList[secondPos];
            var intersection = GetIntersection(firstInterval, secondInterval);
            
            if(intersection != null) {
                result.Add(intersection);
            }
            
            if(firstInterval[1] >= secondInterval[1]) {
                secondPos++;
            }
            
            if(firstInterval[1] <= secondInterval[1]) {
                firstPos++;
            }

        }
        
        return result.ToArray();
    }
    
    public int[] GetIntersection(int[] x, int[] y) {
        var hasIntersection = IntersectsWith(x, y) || IntersectsWith(y, x);
        
        if(!hasIntersection) {
            return null;
        }
        
        return new int[] {
            Math.Max(x[0], y[0]),
            Math.Min(x[1], y[1])
        };
    }
    
    private bool IntersectsWith(int[] source, int[] target) {
        return source[0] >= target[0] && source[0] <= target[1];
    }
}