public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var max = 0;
        var i = 0;
        
        var dict = new Dictionary<char, int>();

        while(i < s.Length) {
            if(!dict.ContainsKey(s[i])) {
                dict[s[i]] = i;
                i++;
                continue;
            }
            
            i = dict[s[i]] + 1;
            max = Math.Max(max, dict.Count);
            dict = new Dictionary<char, int>();
        }
        
        return Math.Max(max, dict.Count);
    }
}