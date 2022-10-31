public class Solution {
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var candlesFromLeftPrefixSum = new int[s.Length];
        candlesFromLeftPrefixSum[0] = (s[0] == '|' ? 1 : 0);
        
        for(int i = 1; i < s.Length; i++) {
            candlesFromLeftPrefixSum[i] = candlesFromLeftPrefixSum[i-1] + (s[i] == '|' ? 1 : 0);
        }
        
        var closestCandleFromLeft = new int[s.Length];
        var lastCandlePos = -1;
        
        for(int i = 0; i < s.Length; i++) {
            lastCandlePos = s[i] == '|' ? i : lastCandlePos;
            closestCandleFromLeft[i] = lastCandlePos;
        }
        
        var closestCandleFromRight = new int[s.Length];
        lastCandlePos = -1;
        
        for(int i = s.Length - 1; i >= 0; i--) {
            lastCandlePos = s[i] == '|' ? i : lastCandlePos;
            closestCandleFromRight[i] = lastCandlePos;
        }
        
        var result = new int[queries.Length];
        
        for(int i = 0; i < queries.Length; i++) {
            var query = queries[i];
            var leftMostCandle = closestCandleFromRight[query[0]];
            var rightMostCandle = closestCandleFromLeft[query[1]];
            
            if(leftMostCandle == -1 || rightMostCandle == -1) {
                result[i] = 0;
                continue;
            }
            
            var cellsCount = rightMostCandle - leftMostCandle - 1;
            
            if(cellsCount <= 0) {
                result[i] = 0;
                continue;
            }
            
            var candlesBetween = candlesFromLeftPrefixSum[rightMostCandle] - candlesFromLeftPrefixSum[leftMostCandle] - 1;
            result[i] = cellsCount - candlesBetween;
        }
        
        return result;
        
        
    }
}