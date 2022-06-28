public class Solution {
    
//     142354356
    public int NumDecodings(string s) {
        if(s.Length == 1) {
            return s[0] == '0' ? 0 : 1;
        }

        var decodings = new int[s.Length];
        decodings[0] = IsDecodable(s, 0, 0) ? 1 : 0;
        decodings[1] = (IsDecodable(s, 0, 1) ? 1 : 0)
            + (IsDecodable(s,0,0) && IsDecodable(s,1,1) ? 1 : 0);
        
        for(int i = 2; i < s.Length; i++) {
            decodings[i] = 0;
            if(IsDecodable(s, i, i)) {
                decodings[i] += decodings[i - 1];
            }
            if(IsDecodable(s,i - 1, i)) {
                decodings[i] += decodings[i-2];
            }
        }
        
        return decodings[s.Length - 1];
    }
    
    
    
    
    
    IDictionary<int, int> mem = new Dictionary<int, int>();

    public int NumDecodingsTopDown(string s) {
        return Count(s, 0);
    }
    
    private int Count(string s, int start) {
        if(mem.ContainsKey(start)) {
            return mem[start];
        }
        
        var length = s.Length - start;
        var count = 0;

        if(length == 2) {
            count += IsDecodable(s, start, start + 1) ? 1 : 0;
            count += IsDecodable(s, start, start) && IsDecodable(s, start + 1, start + 1) ? 1 : 0;
            
            return count;
        }
        
        if(length == 1) {
            return IsDecodable(s,start,start) ? 1 : 0;
        }
        
        
        if(IsDecodable(s, start, start)) {
            count += Count(s, start + 1);
        }
        
        if(IsDecodable(s, start, start + 1)) {
            count += Count(s, start + 2);
        }
        
        mem[start] = count;
        return count;
    }
    
    private bool IsDecodable(string s, int start, int end) {
        if(end < start) {
            return false;
        }

        var first = s[start];
        var second = s[end];
        
        if(first == '0') {
            return false;
        }
        
        if(start == end) {
            return true;
        }
        
        return first == '1' || first == '2' && second < '7';
    } 
}
