public class Solution {
    public string DecodeString(string s) {
        var result = DecodeToken("1[" + s + ']', 0);
        return result.decoded;
    }
    
    // responsible for handling string including [];
    private (string decoded, int nextPos) DecodeText(string s, int pos) {
        if(s[pos] != '[') {
            throw new Exception("Invalid token");
        }

        var output = new StringBuilder();
        pos += 1;
        
        while(s[pos] != ']') {
            if(!IsEncoded(s, pos)) {
                output.Append(s[pos]);
                pos++;
                continue;
            }
            
            (var decoded, var nextPos) = DecodeToken(s, pos);
            output.Append(decoded);
            pos = nextPos;
        }
        
        return (output.ToString(), pos + 1);
        
    }
    
    private (string decoded, int nextPos) DecodeToken(string s, int pos) {
        var output = new StringBuilder();
        var countSubstring = CountSubstring(s, pos);
        (var text, var nextPos) = DecodeText(s, pos + countSubstring.Length);
        var count = Int32.Parse(countSubstring);
        
        while(count-- > 0) {
            output.Append(text);
        }
        
        return (output.ToString(), nextPos);
    }
    
    private string CountSubstring(string s, int pos) {
        var end = pos;
        
        while(s[end + 1] != '[') {
            end++;
        }
        
        return s.Substring(pos, end - pos + 1);
    }
    
    private bool IsEncoded(string s, int pos) {
        return Char.IsDigit(s[pos]);
    }
}