public class Solution {
    public int UniqueLetterString(string s) {
        var lastPos = new int?[26];
        var preLastPos = new int?[26];
        
        var totalSum = 0;
        var prevSum = 0;
        
        for(int i = 0; i < s.Length; i++) {
            var pos = s[i] - 'A';
            var encounteredBefore = lastPos[pos];
            var curSum = prevSum + 1;
            
            var substringWithoutLetterCount = i;
            
            if(encounteredBefore == null) {
                curSum += substringWithoutLetterCount;
            } else {
                substringWithoutLetterCount = i - encounteredBefore.Value - 1;
                curSum += substringWithoutLetterCount;

                var substringsWithLetterCount = encounteredBefore.Value + 1;
                curSum -= substringsWithLetterCount;

                var preLastEncounter = preLastPos[pos];
            
                if(preLastEncounter != null) {
                    var substringWithSeveralLettersCount = preLastEncounter.Value + 1;
                    curSum += substringWithSeveralLettersCount;
                }

            }
            
            totalSum += curSum;
            prevSum = curSum;
            preLastPos[pos] = lastPos[pos];
            lastPos[pos] = i;
        }
        
        return totalSum;
    }
}