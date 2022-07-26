public class Solution {
    public int CountSubstrings(string s) {
        var storage = InitStorage(s.Length);
        var count = 0;

        count += FillOneSymbolPalindroms(s, storage);
        count += FillTwoSymbolPalindroms(s, storage);
        
        for(int length = 3; length <= s.Length; length++) {
            Func<int, int> End = (int x) => x + length - 1;
        
            for(int start = 0; End(start) < s.Length; start ++) {
                if(s[start] == s[End(start)] && storage[start+1][End(start) - 1]) {
                    storage[start][End(start)] = true;
                    count++;
                } 
            }
        }
        
        return count;
    }
    
    private int FillOneSymbolPalindroms(string s, bool[][] storage) {
        for(int i = 0; i < s.Length; i++) {
            storage[i][i] = true;
        }
        
        return s.Length;
    }
    
    private int FillTwoSymbolPalindroms(string s, bool[][] storage) {
        var count = 0;

        for(int i = 0; i < s.Length - 1; i++) {
            if(s[i] == s[i+1]) {
                storage[i][i+1] = true;
                count++;
            }
        }
        
        return count;
    }
    
    private bool[][] InitStorage(int length) {
        var storage = new bool[length][];
        
        for(int i = 0; i < length; i++) {
            storage[i] = new bool[length];
        }
        
        return storage;
    }
    
}