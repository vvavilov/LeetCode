public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
        var groupsByCharacter = new List<(string word, int letterPos)>[26];
        var count = 0;
        
        for(int i = 0; i < groupsByCharacter.Length; i++) {
            groupsByCharacter[i] = new List<(string word, int letterPos)>();
        }
        
        foreach(var word in words) {
            var firstLetter = word[0];
            groupsByCharacter[firstLetter - 'a'].Add((word, 0));
        }

        foreach(var letter in s) {
            var groupIndex = letter - 'a';
            var matchingWords = groupsByCharacter[groupIndex];
            groupsByCharacter[groupIndex] = new List<(string word, int letterPos)>();
            
            foreach(var x in matchingWords) {
                var wordLetterIndex = x.letterPos;
                var word = x.word;
                
                if(wordLetterIndex == word.Length - 1) {
                    count++;
                    continue;
                }
                
                var newGroupIndex = word[wordLetterIndex + 1] - 'a';
                groupsByCharacter[newGroupIndex].Add((word, wordLetterIndex + 1));
            }
            
            
        }

        return count;

    }
}