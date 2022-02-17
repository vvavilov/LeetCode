
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length) { return false; }
        var referenceDict = InitReferenceDictionary(s1);
        var substringDict = InitSubstringDictionary(s2, 0, s1.Length);
        
        for(int i = 0; i <= s2.Length - s1.Length;i++) {
            if(IsPermutation(referenceDict, substringDict)) {
                return true;
            }
            if(i == s2.Length - s1.Length) {
                return false;
            }
            
            substringDict[s2[i]]--;
            
            var toAdd = s2[i + s1.Length];
            Increment(substringDict, toAdd);
        }
        
        return false;
    }
    
    private bool IsPermutation(Dictionary<char, int> reference, Dictionary<char, int> substring) {
        foreach(var pair in reference) {
            if(!substring.ContainsKey(pair.Key) || substring[pair.Key] != pair.Value) return false;
        }
        return true;
    }
    
    private Dictionary<char, int> InitReferenceDictionary(string s1) {
        var referenceDict = new Dictionary<char, int>();
        foreach(char c in s1) {
            Increment(referenceDict, c);
        }
        
        return referenceDict;
    }
    
    private Dictionary<char, int> InitSubstringDictionary(string s2, int index, int count) {
        var substringDict = new Dictionary<char, int>();
        for(int i = 0; i < count; i++) {
            var val = s2[i + index];
            Increment(substringDict, val);
        }   
        return substringDict;
    }
    
    private void Increment(Dictionary<char, int> dict, char symbol) {
        dict[symbol] = dict.ContainsKey(symbol)
            ? dict[symbol] + 1
            : 1;
    }
}