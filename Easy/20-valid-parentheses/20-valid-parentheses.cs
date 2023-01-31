public class Solution {
    private Dictionary<char, char> parentheses = new() {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' },
    };
    
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        
        foreach(var letter in s) {
            if(!parentheses.ContainsKey(letter)) {
                stack.Push(letter);
                continue;
            }
            
            if(stack.Count == 0) {
                return false;
            }
            
            if(stack.Pop() != parentheses[letter]) {
                return false;
            }
        }
        
        return stack.Count == 0;
    }
}