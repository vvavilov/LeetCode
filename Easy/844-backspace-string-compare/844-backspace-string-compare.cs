public class Solution {    
    public bool BackspaceCompare(string s, string t) {
        var i = s.Length - 1;
        var j = t.Length - 1;

        while (true) {
            i = NextValuablePosition(s, i);
            j = NextValuablePosition(t, j);
            
            if(i < 0 && j < 0) {
                return true;
            }
            
            if(i < 0 || j < 0) {
                return false;
            }
            
            if(s[i] != t[j]) {
                return false;
            }
                        
            i--;
            j--;
        }
        
        return false;
    }
    
    private int NextValuablePosition(string s, int i) {
       var skip = 0;
            
        while(i >= 0 && (skip > 0 || s[i] == '#')) {
            if(s[i] == '#') {
                skip++;
            } else {
                skip--;
            }
            i--;
        }
        
        return i;
    }
    
}

public class SolutionStack {
    
    public bool BackspaceCompare(string s, string t) {
        var sStack = BuildStack(s);
        var tStack = BuildStack(t);
        
        return AreEqual(sStack, tStack);
    }
    
    private Stack<char> BuildStack(string s) {
        var stack = new Stack<char>();
        
        foreach(var x in s) {
            if(x != '#') {
                stack.Push(x);
            } else {
                if(stack.Count > 0) {
                    stack.Pop();
                }
            }
        }
        
        return stack;
    }
    
    private bool AreEqual(Stack<char> first, Stack<char> second) {
        while(first.Count > 0 && second.Count > 0) {
            if(first.Pop() != second.Pop()) {
                return false;
            }
            
        }
        return first.Count == 0 && second.Count == 0;

    }
}