public class Solution {
    public int MinSwaps(string s) {
        if(s.Length == 0) {
            return 0;
        }
        
        var startsWithZerosResult = SwapsCount(s, '0');
        var startsWithOnesResult = SwapsCount(s, '1');
        
        if(startsWithZerosResult.possible && startsWithOnesResult.possible) {
            return Math.Min(startsWithZerosResult.count, startsWithOnesResult.count);
        }
        
        if(startsWithZerosResult.possible) {
            return startsWithZerosResult.count;
        }
        
        if(startsWithOnesResult.possible) {
            return startsWithOnesResult.count;
        }
        
        return -1;
    }
    
    private (bool possible, int count) SwapsCount(string s, char startsWith) {
        var outOfPlaceOnesCount = 0;
        
        var expected = startsWith;
        var count = 0;
        
        foreach(var c in s) {
            if(c != expected) {
                if(c == '0') {
                    outOfPlaceOnesCount--;
                    count++;
                } else {
                    outOfPlaceOnesCount++;
                }
            }
            
            expected = Other(expected);

        }
        
        return outOfPlaceOnesCount == 0
            ? (true, count)
            : (false, 0);
    }
    
    private char Other(char c) {
        if(c == '0') {
            return '1';
        }
        
        return '0';
    }
}