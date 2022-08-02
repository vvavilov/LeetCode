/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/

public class Solution {
    public Node TreeToDoublyList(Node root) {
        if(root == null) {
            return null;
        }
        
        var result = Traverse(root);
        result.last.right = result.first;
        result.first.left = result.last;
        
        return result.first;
        
        
    }
    
    private (Node first, Node last) Traverse(Node node) {
        if(node == null) {
            return (null, null);
        }
        
        var left = Traverse(node.left);
        var right = Traverse(node.right);
        
        if(left.first != null) {
            left.last.right = node;
            node.left = left.last;
        } else {
            left.first = node;
        }
        
        if(right.first != null) {
            node.right = right.first;
            right.first.left = node;
        } else {
            right.last = node;
        }
        
        return (left.first, right.last);
    }
}