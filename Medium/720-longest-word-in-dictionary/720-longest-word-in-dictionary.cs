public class Solution {
    public string LongestWord(string[] words) {
        var trie = new Trie(words);
        
        var longest = GetLongest(trie.root, -1);
        longest.RemoveFirst();
        
        return new String(longest.Select(x => (char)(x + 'a')).ToArray());
        
    }
    
    private LinkedList<int> GetLongest(Node node, int value) {
        if(node == null || !node.isWordEnding) {
            return new LinkedList<int>();
        }
        
        var longestChild = new LinkedList<int>();
        for(int i = 0; i < 26; i++) {
            var child = GetLongest(node.children[i], i);
            if(child.Count > longestChild.Count) {
                longestChild = child;
            }
        }
        
        longestChild.AddFirst(value);
        return longestChild;
    }
    
    
}

public class Trie {
    public Node root;
    
    public Trie(string[] words) {
        root = new Node();
        root.MaskWordEnding();

        foreach(var word in words) {
            AddWord(word);
        }
    }
    
    public void AddWord(string word) {
        var node = root;

        foreach(var c in word) {
            node = node.AddSymbol(c);
        }
        
        node.MaskWordEnding();
    }
}

public class Node {
    public Node[] children;
    public bool isWordEnding;
    
    public Node() {
        children = new Node[26];
        isWordEnding = false;
    }
    
    public Node AddSymbol(char c) {
        var pos = (int)(c - 'a');
        
        if(children[pos] == null) {
            children[pos] = new Node();
        }
        
        return children[pos];
    }
    
    public void MaskWordEnding() {
        isWordEnding = true;
    }
}

