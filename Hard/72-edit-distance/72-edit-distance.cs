public class Solution {    
    public int MinDistance(string word1, string word2) {
        var distances = new Dictionary<(int left, int right), int>();
        if(word1 == "" || word2 == "") {
            return Math.Max(word1.Length, word2.Length);
        }
        
        for(int i = 0; i < word1.Length; i++) {
            for (int j = 0; j < word2.Length; j++) {
                 if(word1[i] == word2[j]) {
                     distances[(i,j)] = GetValue(distances,i-1, j-1);
                     continue;
                 }
                
                var remove = GetValue(distances, i-1,j);
                var add = GetValue(distances,i,j-1);
                var replace = GetValue(distances,i-1,j-1);
                
                distances[(i,j)] = Math.Min(Math.Min(remove, add), replace) + 1;
            }
        }
        
        return distances[(word1.Length - 1, word2.Length - 1)];
        
    }
    
    private int GetValue(Dictionary<(int left, int right), int> vals, int left, int right) {
        if(left < 0 && right < 0) {
            return 0;
        }
        
        if(left < 0) {
            return right + 1;
        }
        
        if(right < 0) {
            return left + 1;
        }
        
        return vals[(left, right)];
    }
}
