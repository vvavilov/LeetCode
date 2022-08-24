public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        List<int> result = new();

        if(s.Length == 0 || p.Length == 0) {
            return result;
        }
        
        var dict = InitDictionary(p);
        ProcessFirstWindow(dict, s, p.Length);
        
        if(IsAnagram(dict)) {
            result.Add(0);
        }
        
        for(int i = 1; i <= s.Length - p.Length; i++) {
            // Console.WriteLine(i);
            dict[s[i - 1]]++;
            
            var newWindowValuePos = i + p.Length - 1;
            dict.TryGetValue(s[newWindowValuePos], out var count);
            dict[s[newWindowValuePos]] = count - 1;
            
            if(IsAnagram(dict)) {
                result.Add(i);
            }
        }
        
        return result;
        
    }
    
    private void ProcessFirstWindow(Dictionary<char, int> dict, string s, int patternLength) {
        foreach(var x in s.Take(patternLength)) {
            dict.TryGetValue(x, out var count);
            dict[x] = count - 1;
        }
    }
    
    private bool IsAnagram(Dictionary<char, int> dict) {
        return dict.Values.All(x => x == 0);
    }
    
    private Dictionary<char, int> InitDictionary(string p) {
        Dictionary<char, int> result = new();
        
        foreach(var x in p) {
            result.TryGetValue(x, out var count);
            result[x] = count + 1;
        }
        
        return result;
    }
}