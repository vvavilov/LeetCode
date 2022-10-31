public class Solution {
    public long NumberOfWays(string s) {
        return NumberOneInMiddle(s) + NumberZeroInMiddle(s);
    }
    
    private long NumberOneInMiddle(string s) {
        var zerosSoFar = new int[s.Length];
        var prevZeros = 0;
        var count = 0L;
        
        for(int i = 0; i < s.Length; i++) {
            zerosSoFar[i] = prevZeros + (s[i] == '0' ? 1 : 0);
            prevZeros = zerosSoFar[i];
        }
        
        for(int i = 0; i < s.Length; i++) {
            if(s[i] == '1') {
                var zerosToLeft = zerosSoFar[i];
                var zerosToRight = zerosSoFar[zerosSoFar.Length - 1] - zerosToLeft;
                count += (long)zerosToLeft * zerosToRight;
            }
        }
        
        return count;
    }
    
    private long NumberZeroInMiddle(string s) {
        var onesSoFar = new int[s.Length];
        var prevOnes = 0;
        var count = 0L;
        
        for(int i = 0; i < s.Length; i++) {
            onesSoFar[i] = prevOnes + (s[i] == '1' ? 1 : 0);
            prevOnes = onesSoFar[i];
        }
        
        for(int i = 0; i < s.Length; i++) {
            if(s[i] == '0') {
                var onesToLeft = onesSoFar[i];
                var onesToRight = onesSoFar[onesSoFar.Length - 1] - onesToLeft;
                count += (long)onesToLeft * onesToRight;
            }
        }
        
        return count;
    }
}