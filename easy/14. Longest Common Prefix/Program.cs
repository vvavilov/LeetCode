public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var letter = 0;

        while(true) {
            if(!AllHasSameLetter(strs, letter)) {
                break;
            }
            
            letter++;
        }
        
        var result = new StringBuilder();
        for(int i = 0; i < letter; i++) {
            result.Append(strs[0][i]);
        }
        
        return result.ToString();
    }
    
    private bool AllHasSameLetter(string[] strings, int index) {
        if(index >= strings[0].Length) {
            return false;
        }
        
        var c = strings[0][index];

        foreach(var s in strings) {
            if(index >= s.Length) {
                return false;
            }
            
            if(s[index] != c) {
                return false;
            }
        }
        
        return true;
    }
}