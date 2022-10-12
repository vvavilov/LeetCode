public class Solution {
    public string CustomSortString(string order, string s) {
        var chars = new Dictionary<char, int>();
        var output = new StringBuilder();
        
        foreach(var x in s) {
            chars.TryGetValue(x, out var count);
            chars[x] = count + 1;
        }
        
        foreach(var x in order) {
            if(chars.ContainsKey(x)) {
                output.Append(x, chars[x]);
                chars.Remove(x);
            }
        }
        
        foreach(var x in chars) {
            output.Append(x.Key, x.Value);
        }
        
        return output.ToString();
    }
}
