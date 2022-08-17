public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        var letters = new string[] {
            ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.",
            "---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."
        };
        
        var encoded = new HashSet<string>();
        
        foreach(var x in words) {
            var sb = new StringBuilder();
            
            foreach(var c in x) {
                sb.Append(letters[(int)(c - 'a')]);
            }

            var word = sb.ToString();
            
            if(!encoded.Contains(word)) {
                encoded.Add(word);
            }
        }
        
        return encoded.Count;
    }
}