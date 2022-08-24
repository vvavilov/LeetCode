public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        List<int> result = new();

        if(s.Length == 0 || p.Length == 0) {
            return result;
        }
        
        var state = InitState(p);
        ProcessFirstWindow(state, s, p.Length);
        
        if(IsAnagram(state)) {
            result.Add(0);
        }
        
        for(int i = 1; i <= s.Length - p.Length; i++) {
            Remove(state, s[i-1]);
            
            var newWindowValuePos = i + p.Length - 1;
            Add(state, s[newWindowValuePos]);
            
            if(IsAnagram(state)) {
                result.Add(i);
            }
        }
        
        return result;
        
    }
    
    private void ProcessFirstWindow(int[] state, string s, int patternLength) {
        foreach(var x in s.Take(patternLength)) {
            Add(state, x);
        }
    }
    
    private void Add(int[] state, char c) {
        state[Pos(c)]--;
    }
    
    private void Remove(int[] state, char c) {
        state[Pos(c)]++;
    }
    
    private int Pos(char c) {
        return (int)(c - 'a');
    }
    
    private bool IsAnagram(int[] state) {
        return state.All(x => x == 0);
    }
    
    private int[] InitState(string p) {
        var state = new int[26];
        
        foreach(var x in p) {
            Remove(state, x);
        }
        
        return state;
    }
}