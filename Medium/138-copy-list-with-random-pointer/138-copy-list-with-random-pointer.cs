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
        if(head == null) {
            return null;
        }

        Dictionary<Node, Node> copies = new();
        return Dfs(head, copies);
    }
    
    private Node Dfs(Node node, Dictionary<Node, Node> copies) {
        if(node == null) {
            return null;
        }
        
        if(copies.ContainsKey(node)) {
            return copies[node];
        }
        
        copies[node] = new Node(node.val);
        copies[node].next = Dfs(node.next, copies);
        copies[node].random = Dfs(node.random, copies);
        
        return copies[node];
    }
}