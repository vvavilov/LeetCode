public class Solution {
    public int RomanToInt(string s) {
        var values = new Dictionary<char, int> {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };
        
        if(s.Length == 0) { return 0; }
        var result = 0;
        for(int i = 0; i < s.Length - 1; i++) {
            var letter = s[i];
            var next = s[i+1];
            if(values[letter] >= values[next]) {
                result += values[letter];
            } else {
                result -= values[letter];
            }
        }
        result +=values[s[s.Length - 1]];
        
        return result;
    }
}