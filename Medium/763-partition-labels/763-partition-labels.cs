public class Solution {
    public IList<int> PartitionLabels(string s) {
        int pos = 0;
        
        var lastOccurence = new LettersDictionary<int>();
        
        for(int i = 0; i < s.Length; i++) {
            lastOccurence.Set(s[i], i);
        }
        
        List<int> result = new();
        var start = 0;
        var end = 0;
        
        for(int i = 0; i < s.Length; i++) {
            end = Math.Max(end, lastOccurence.Get(s[i]));
            
            if(end == i) {
                result.Add(end - start + 1);
                start = i + 1;
            }
        }
        
        return result;
        
    }
}

public class LettersDictionary<TValue> {
    private TValue[] impl = new TValue[26];
    
    public void Set(char key, TValue value) {
        impl[key - 'a'] = value;
    }
    
    public TValue Get(char key) {
        return impl[key - 'a'];
    }
}