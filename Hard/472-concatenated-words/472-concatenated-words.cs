public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        HashSet<string> wordsSet = new(words);
        HashSet<string> splittable = new();
        
        foreach(var x in words) {
            CanBeSplitted(x, wordsSet, splittable);
        }
        
        List<string> result = new();
        
        foreach(var x in words) {
            if(splittable.Contains(x)) {
                result.Add(x);
            }
        }
        
        return result;
    }
    
    private void CanBeSplitted(string word, HashSet<string> availableWords, HashSet<string> splittable) {
        for(int i = 0; i < word.Length; i++) {
            for(int j = 0; j <= i; j++) {                
                var left = word.Substring(0, j + 1);
                
                if(!KnownAsSplittable(left, availableWords, splittable)) {
                    continue;
                }
                
                if(j == word.Length - 1) {
                    continue;
                }
                
                var right = word.Substring(j + 1, i - j);
                
                if(KnownAsSplittable(right, availableWords, splittable)) {
                    splittable.Add(word.Substring(0, i + 1));
                    break;
                }
            }
        }
        
    }
    
    private bool KnownAsSplittable(string substring, HashSet<string> available, HashSet<string> splittable) {
        return available.Contains(substring) || splittable.Contains(substring);
    }
}