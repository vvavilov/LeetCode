public class Solution {
    
    public string ReverseWords(string s) {
        var result = new StringBuilder();
        var word = new List<char>();
        
        foreach(var c in s) {
            if(c != ' ') {
                word.Add(c);
            } else {
                for(int i = word.Count - 1; i>=0; i--) {
                    result.Append(word[i]);
                }
                result.Append(' ');
                word = new List<char>();
            }
        }
        
        for(int i = word.Count - 1; i>=0; i--) {
            result.Append(word[i]);
        }
        
        return result.ToString();
    }
}