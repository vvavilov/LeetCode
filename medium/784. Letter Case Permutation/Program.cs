public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        List<string> result = new();
        Permutate(s.ToCharArray(), 0, result);
        return result;
    }
    
    private void Permutate(char[] s, int pos, List<string> result) {
        if(pos == s.Length) {
            result.Add(new string(s));
            return;
        }
        
        if (Char.IsDigit(s[pos])) {
            Permutate(s, pos + 1, result);
            return;
        }
        
        s[pos] = Char.ToUpper(s[pos]);
        Permutate(s, pos + 1, result);
        s[pos] = Char.ToLower(s[pos]);
        Permutate(s, pos + 1, result);
    }
}
public class SolutionBacktracking {
    public IList<string> LetterCasePermutation(string s) {
        List<string> result = new();
        
        Permutate(new StringBuilder(), 0, s, result);
        
        return result;
    }
    
    private void Permutate(StringBuilder cur, int pos, string s, List<string> result) {
        if(pos == s.Length) {
            result.Add(cur.ToString());
            return;
        }
        
        var charVariants = Char.IsLetter(s[pos])
            ? new [] {
                Char.ToLower(s[pos]),
                Char.ToUpper(s[pos])
            } : new[] { s[pos] };

        foreach(var x in charVariants) {
            cur.Append(x);
            Permutate(cur, pos + 1, s, result);
            cur.Remove(cur.Length - 1, 1);
        }
    }
}