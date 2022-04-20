public class Solution {
    public int RomanToInt(string s) {
        var values = new Dictionary<char, int> {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        
        var previous = 1000;
        var result = 0;
        
        for(int i = 0; i < s.Length - 1; i++) {
            var value = values[s[i]];
            var nextValue = values[s[i+1]];
            var toAdd = nextValue <= value
                ? value
                : -value;
            
            result += toAdd;
        }
        
        result += values[s[s.Length - 1]];
        return result;
    }
}