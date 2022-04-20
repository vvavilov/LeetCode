public class Solution {
    public bool IsAnagram(string s, string t) {
        var frequency = new Dictionary<char, int>();
        
        foreach(var c in s) {
            if(frequency.ContainsKey(c)) {
                frequency[c]++;
            } else {
                frequency[c] = 1;
            }
        }
        
        foreach(var c in t) {
            if(!frequency.ContainsKey(c)) {
                return false;
            }
            
            frequency[c]--;            
        }
        
        return frequency.Values.All(x => x == 0);
    }
}