public class Solution {
    // ()
    // ({})()
    // {()
    public bool IsValid(string s) {
        var registry = new Dictionary<char, char> {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}

        };
        
        var stack = new Stack<char>();
        
        foreach(char c in s) {
           if(registry.ContainsKey(c)) {
               stack.Push(registry[c]);
           } else {
               if (stack.Count == 0 || stack.Pop() != c) {
                   return false;
               }
           }
        }
        
        return stack.Count == 0;
    }
}