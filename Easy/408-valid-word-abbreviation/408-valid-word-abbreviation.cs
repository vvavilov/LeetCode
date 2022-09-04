public class Solution {
    public bool ValidWordAbbreviation(string word, string abbr) {
        var wordPos = 0;
        var abbrPos = 0;
        
        while(wordPos < word.Length && abbrPos < abbr.Length) {
            if(!Char.IsDigit(abbr[abbrPos])) {
                if(word[wordPos] != abbr[abbrPos]) {
                    return false;
                }
                
                abbrPos++;
                wordPos++;
                continue;
            }
            
            var digitStartPos = abbrPos;
            
            if(abbr[abbrPos] == '0') {
                return false;
            }
            
            while(abbrPos + 1 < abbr.Length && Char.IsDigit(abbr[abbrPos + 1])) {
                abbrPos++;
            }
            
            var count = Int32.Parse(abbr.Substring(digitStartPos, abbrPos - digitStartPos + 1));
            wordPos += count;
            abbrPos++;            
        }
        
        return wordPos == word.Length && abbrPos == abbr.Length;
        
    }
}