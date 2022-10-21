public class Solution {
    public int NumDecodings(string s) {
        var dp = new int[s.Length];
        Array.Fill(dp, -1);

        return DP(s.Length - 1, s, dp);
    }
    
    private int DP(int pos, string s, int[] dp) {
        if(pos == -1) {
            return 1;
        }
        
        if(dp[pos] != -1) {
            return dp[pos];
        }
        
        var count = 0;
        
        if(IsDecodable(s[pos])) {
            count += DP(pos - 1, s, dp);
        }
        
        if(pos >= 1 && IsDecodable(s.Substring(pos - 1, 2))) {
            count += DP(pos - 2, s, dp);
        }
        
        dp[pos] = count;
        return count;
    }
    
    private bool IsDecodable(char c) {
        return c != '0';
    }
    
    private bool IsDecodable(string s) {
        return s[0] == '1' || s[0] == '2' && s[1] < '7';
    }
}