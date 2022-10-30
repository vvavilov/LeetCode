/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        Dictionary<Node, Node> copies = new();
        return Copy(head, copies);
    }
    
    private Node Copy(Node node, Dictionary<Node, Node> copies) {
        if(node == null) {
            return null;
        }

        if(copies.ContainsKey(node)) {
            return copies[node];
        }
        
        var copy = new Node(node.val);
        copies[node] = copy;
        
        copy.next = Copy(node.next, copies);
        copy.random = Copy(node.random, copies);
        return copy;
    }
}