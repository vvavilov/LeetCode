public class Solution {
    public int NumDecodings(string s) {
        if(s.Length == 1) {
            return IsDecodable(s[0]) ? 1 : 0;
        }
        
        var dp = new int[s.Length];
        
        dp[0] = IsDecodable(s[0]) ? 1 : 0;
        dp[1] = IsDecodable(s[1]) ? dp[0] : 0;
        dp[1] = IsDecodable(s.Substring(0, 2)) ? dp[1] + 1 : dp[1];
        
        for(int i = 2; i < s.Length; i++) {
            if(IsDecodable(s[i])) {
                dp[i] += dp[i - 1];
            }
            
            if(IsDecodable(s.Substring(i - 1, 2))) {
                dp[i] += dp[i - 2];
            }
        }    

        return dp[dp.Length - 1];
    }
    
    private bool IsDecodable(char c) {
        return c != '0';
    }
    
    private bool IsDecodable(string s) {
        return s[0] == '1' || s[0] == '2' && s[1] < '7';
    }
}