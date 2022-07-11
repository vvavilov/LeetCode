public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        List<int[]> result = new();
        
        var firstPos = 0;
        var secondPos = 0;
        
        while(firstPos < firstList.Length && secondPos < secondList.Length) {
            var firstInterval = firstList[firstPos];
            var secondInterval = secondList[secondPos];
            
            var left = Math.Max(firstInterval[0], secondInterval[0]);
            var right = Math.Min(firstInterval[1], secondInterval[1]);
            
            if(left <= right) {
                result.Add(new int[] {left, right});
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
}