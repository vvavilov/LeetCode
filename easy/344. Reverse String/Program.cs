static void ReverseString(char[] s) {
    var left = 0;
    var right = s.Length - 1;
    
    while (left < right) {
        var temp = s[left];
        s[left] = s[right];
        s[right] = temp;
        
        left++;
        right--;
    }
}