public class Solution {
    public int FirstUniqChar(string s) {
        var frequency = new Dictionary<char, int>();
        foreach(var c in s) {
            if(frequency.ContainsKey(c)) {
                frequency[c]++;
            } else {
                frequency[c] = 1;
            }
        }
        
        for(var i = 0; i < s.Length; i++) {
            if(frequency[s[i]] == 1) {
                return i;
            }
        }
        
        return -1;
    }
}