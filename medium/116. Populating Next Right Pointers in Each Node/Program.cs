/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node node) {
        if(node == null) {
            return null;
        }

        ConnectDfs(node);
        return node;
    }
    
    private void ConnectDfs(Node node) {
        if(node.left == null) {
            return;
        }
        
        var left = node.left;
        var right = node.right;
        
        left.next = right;
        right.next = node.next?.left;
        
        ConnectDfs(left);
        ConnectDfs(right);
    }
    
    public Node ConnectBFS(Node root) {
        if(root == null) {
            return null;
        }

        Queue<Node> queue = new();
        queue.Enqueue(root);
        
        while(queue.Count > 0) {
            var levelCount = queue.Count;
            Node next = null;
            
            for(var i = 0; i < levelCount; i++) {
                var node = queue.Dequeue();
                node.next = next;
                next = node;
                
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
                
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
            }
        }
        
        return root;
            
    }
}