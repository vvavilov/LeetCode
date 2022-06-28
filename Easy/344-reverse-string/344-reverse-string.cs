public class Solution {
    public void ReverseString(char[] s) {
        var left = 0;
        var right = s.Length - 1;
        
        while(left < right) {
            var temp = s[right];
            s[right] = s[left];
            s[left] = temp;
            
            left++;
            right--;
        }
        
        
    }
}