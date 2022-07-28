public class Solution {
    private int[][] hash;
    
    public int LongestCommonSubsequence(string t1, string t2) {
        hash = new int[t1.Length + 1][];
        
        for(int i = 0; i < hash.Length; i++) {
            hash[i] = new int[t2.Length + 1];
        }
        
        for(int i = t1.Length - 1; i >= 0; i--) {
            for(int j = t2.Length - 1; j >= 0; j--) {
                if(t1[i] == t2[j]) {
                    hash[i][j] = hash[i+1][j+1] + 1;
                    continue;
                }
                
                hash[i][j] = Math.Max(hash[i][j+1], hash[i+1][j]);
            }
        }
        
        return hash[0][0];
    }
}