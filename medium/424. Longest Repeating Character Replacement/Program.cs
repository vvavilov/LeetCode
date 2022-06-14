public class Solution {
    public int CharacterReplacement(string s, int k) {
        if(s.Length == 0) {
            return 0;
        }
        
        var substring = new int[26];
        
        var start = 0;
        var stablePos = s[0] - 'A';
        var size = 0;
        
        for(int i = 0; i < s.Length; i++) {
            var pos = s[i] - 'A';
            substring[pos]++;
                        
            var stableCount = substring[stablePos];A
            var numberToReplace = i - start + 1 - stableCount;
            
            if(numberToReplace > k) {
                var startVal = s[start] - 'A';
                substring[startVal]--;
                start++;
            }
            
            stablePos = substring[pos] >= substring[stablePos]
                ? pos
                : stablePos;
        }
        
        return s.Length - start;
        
    }
}