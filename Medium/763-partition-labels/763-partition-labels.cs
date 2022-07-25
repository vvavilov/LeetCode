public class Solution {
    public IList<int> PartitionLabels(string s) {
        int pos = 0;
        
        var lastOccurence = new int[26];
        
        for(int i = 0; i < s.Length; i++) {
            lastOccurence[s[i] - 'a'] = i;
        }
        
        List<int> result = new();
        
        while(pos < s.Length) {         
            var intervalEnd = ExpandInterval(s, pos, pos, lastOccurence);
            result.Add(intervalEnd - pos + 1);
            pos = intervalEnd + 1;
        }
        
        return result;
        
    }
    
    private int ExpandInterval(string s, int start, int end, int[] lastOccurence) {
        var endSoFar = end;
        
        for(int i = start; i <= endSoFar; i++) {
            endSoFar = Math.Max(endSoFar, lastOccurence[s[i] - 'a']);
            
            if(endSoFar == s.Length - 1) {
                break;
            }
        }
        
        return endSoFar;
    }
    
}