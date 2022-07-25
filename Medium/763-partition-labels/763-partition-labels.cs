public class Solution {
    public IList<int> PartitionLabels(string s) {
        int pos = 0;
        
        List<int> result = new();
        
        while(pos < s.Length) {         
            var intervalEnd = ExpandInterval(s, pos, pos);
            result.Add(intervalEnd - pos + 1);
            pos = intervalEnd + 1;
        }
        
        return result;
        
    }
    
    private int ExpandInterval(string s, int start, int end) {
        var endSoFar = end;
        
        for(int i = start; i <= endSoFar; i++) {
            // What if end of string is reached?
            var currentEnd = FindLastOccurenceOfSame(s, i);
            endSoFar = Math.Max(endSoFar, currentEnd);
        }
        
        return endSoFar;
    }
    
    private int FindLastOccurenceOfSame(string s, int pos) {
        var last = pos;
        
        for(int i = pos + 1; i < s.Length; i++) {
            if(s[i] == s[pos]) {
                last = i;
            }    
        }
        
        return last;
    }
}