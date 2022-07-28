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
    
    private int TopDown(string t1, string t2, int pos1, int pos2) {
        if(pos1 == t1.Length || pos2 == t2.Length) {
            return 0;
        }
        
        if(hash[pos1][pos2] != -1) {
            return hash[pos1][pos2];
        }
        
        if(t1[pos1] == t2[pos2]) {
            return 1 + TopDown(t1, t2, pos1 + 1, pos2 + 1);
        }
        
        hash[pos1][pos2] = Math.Max(
            TopDown(t1, t2, pos1 + 1, pos2),
            TopDown(t1, t2, pos1, pos2 + 1)
        );
        
        return hash[pos1][pos2];
    }
}