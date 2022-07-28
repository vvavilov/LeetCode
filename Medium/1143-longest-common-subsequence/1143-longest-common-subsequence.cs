public class Solution {
    private int[][] hash;
    
    public int LongestCommonSubsequence(string text1, string text2) {
        hash = new int[text1.Length][];
        
        for(int i = 0; i < hash.Length; i++) {
            hash[i] = new int[text2.Length];    
        }
        
        return TopDown(text1, text2, 0, 0);    
    }
    
    private int TopDown(string t1, string t2, int pos1, int pos2) {
        if(pos1 == t1.Length || pos2 == t2.Length) {
            return 0;
        }
        
        if(hash[pos1][pos2] != 0) {
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