internal class Node {
    public bool isEnding = false;
    public Node[] children = new Node[26];
    
    private static int Position(char c) => c - 'a';
    
    public Node GetChild(char c) {
        return children[Position(c)];
    }
    
    public Node AddChild(char c) {
        if(GetChild(c) != null) {
            throw new Exception("Children is already added");
        }
        
        var child = new Node();

        children[Position(c)] = child;
        return child;
    }
}

public class Trie {
    Node root;
    
    public Trie() {
        root = new Node();
    }
    
    public void Insert(string word) {
        var parent = root;
        
        foreach(var c in word) {
            var existingNode = parent.GetChild(c);
            
            if(existingNode != null) {
                parent = existingNode;
                continue;
            }
            
            parent = parent.AddChild(c);
        }
        
        parent.isEnding = true;  
    }
    
    public bool Search(string word) {
        var tail = FindPrefixTail(word);
        
        return tail != null && tail.isEnding;
    }
    
    public bool StartsWith(string prefix) {
        return FindPrefixTail(prefix) != null;
    }
    
    private Node FindPrefixTail(string prefix) {
        var parent = root;

        foreach(var c in prefix) {
            parent = parent.GetChild(c);
            
            if(parent == null) {
                return null;
            }
        }
        
        return parent;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */