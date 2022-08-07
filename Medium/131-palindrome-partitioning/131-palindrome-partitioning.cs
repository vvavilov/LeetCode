public class Solution {
    public IList<IList<string>> Partition(string s) {
        List<IList<string>> result = new();
        Backtrack(s, 0, new LinkedList<string>(), result);
        return result;    
    }
    
    private void Backtrack(string s, int start, LinkedList<string> acc, List<IList<string>> result) {
        if(start == s.Length) {
            result.Add(new List<string>(acc));
            return;
        }
        
        for(int end = start; end < s.Length; end++) {
            if(!IsPalindrom(s, start, end)) {
                continue;
            }
            
            acc.AddLast(s.Substring(start, end - start + 1));
            Backtrack(s, end + 1, acc, result);
            acc.RemoveLast();
        }
    }
    
    private bool IsPalindrom(string s, int left, int right) {
        while(left < right) {
            if(s[left] != s[right]) {
                return false;
            }
            left++;
            right--;
        }
        
        return true;
    }
}