public class Solution {
    public int StrStr(string haystack, string needle) {
        if(needle.Length == 0) {
            return 0;
        } 
        
        if(haystack.Length == 0) {
            return -1;
        }
        
        for(int i = 0; i < haystack.Length; i++) {
            var pos = StartsWith(haystack, i, needle);
            if (pos != -1) {
                return pos;
            }
        }
        
        return -1;
    }
    
    private int StartsWith(string s, int index, string subString) {
        if(subString.Length > s.Length - index) {
            return -1;
        }
        
        for(int i = 0; i < subString.Length; i++) {
            if(s[index + i] != subString[i]) {
                return -1;
            }
        }
        
        return index;
    }
}