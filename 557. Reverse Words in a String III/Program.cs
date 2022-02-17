using System.Text;

static string ReverseWords(string s) {
    var result = new StringBuilder();
    var left = 0;
    var right = 0;
    
    while(right < s.Length) {         
        if(s[right] == ' ') {   
            Reverse(s, left, right - 1, result);
            result.Append(' ');
            
            left = right + 1;
            right++;
        }
        
        right++;
    }
    
    Reverse(s, left, s.Length - 1, result);
    return result.ToString();
}

static void Reverse(string s, int left, int right, StringBuilder result) {
    for(var i = right; i >= left; i--) {
        result.Append(s[i]);
    }
}