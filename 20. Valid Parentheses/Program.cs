public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        
        var brackets = new Dictionary<char, char> {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };
        
        foreach(var bracket in s) {
            if(brackets.ContainsKey(bracket)) {
                stack.Push(bracket);
            } else {
                if(stack.Count == 0) {
                    return false;
                }
                
                if(brackets[stack.Pop()] != bracket) {
                    return false;
                }
            }
        }
        
        return stack.Count == 0;
    }
}