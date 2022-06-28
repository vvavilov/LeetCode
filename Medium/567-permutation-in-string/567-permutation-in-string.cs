public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var lastWindowPos = s2.Length - s1.Length;
        
        for(int i = 0; i <= lastWindowPos; i++) {
            var dict = new Dictionary<int, int>();
            for(int k = 0; k < s1.Length; k++) {
                if(dict.ContainsKey(s1[k])) {
                    dict[s1[k]]++;
                } else {
                    dict[s1[k]] = 1;
                }
            }
            
            var j = i;
            var windowEnd = s1.Length + i;
            for(; j < s1.Length + i; j++) {
                if(dict.ContainsKey(s2[j]) && dict[s2[j]] > 0) {
                    dict[s2[j]]--;
                } else {
                    break;
                }
            }
            
            if(j == windowEnd) {
                return true;
            }
        }
        
        return false;
    }
}