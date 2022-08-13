public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        if(words.Length == 0) {
            return new List<int>();
        }
        
        var initDict = BuildDictionary(words);    

        
        var wordLength = words[0].Length;
        var result = new List<int>();

        for(int i = 0; i < s.Length; i++) {
            var wordsFound = 0;
            var dict = new Dictionary<string, int>(initDict);

            for(int j = i; j <= s.Length - wordLength; j += wordLength) {
                var word = GetWord(j, s, wordLength);
                
                if(dict.ContainsKey(word) && dict[word] > 0) {
                    dict[word]--;
                    wordsFound++;
                } else {
                    break;
                }
                
                if(wordsFound == words.Length) {
                    result.Add(i);
                    break;
                }
            }
        }
        
        return result;
    }
    
    private string GetWord(int pos, string s, int length) {
        return s.Substring(pos, length);
    }
    
    
    
    private Dictionary<string, int> BuildDictionary(string[] words) {
        Dictionary<string, int> dict = new();
        
        foreach(var x in words) {
            dict.TryGetValue(x, out var existing);
            dict[x] = existing + 1;
        }
        
        return dict;
    }
}