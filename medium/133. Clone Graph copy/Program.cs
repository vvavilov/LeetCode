/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<int, Node> cloned = new();
    
    public Node CloneGraph(Node node) {
        if(node == null) {
            return null;
        }

        if(cloned.ContainsKey(node.val)) {
            return cloned[node.val];
        }

        var clone = new Node(node.val, new List<Node>());
        cloned[node.val] = clone;
        
        foreach(var x in node.neighbors) {
            clone.neighbors.Add(CloneGraph(x));
        }
        
        return clone;
    }
}