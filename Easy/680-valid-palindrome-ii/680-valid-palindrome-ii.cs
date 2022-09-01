public class Solution {
    public bool ValidPalindrome(string s) {
        var left = 0;
        var right = s.Length - 1;
        
        while(left < right) {
            if(s[left] == s[right]) {
                left++;
                right--;
                continue;
            }
            
            return IsPalindrom(s, left, right - 1) || IsPalindrom(s, left + 1, right);
        }
        
        return true;
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