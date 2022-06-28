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
    public Node Connect(Node root) {
        var parent = root;
        
        while(parent != null) {
            var layerIndicator = new Node();
            var current = layerIndicator;

            while(parent != null) {
                if(parent.left != null) {
                    current.next = parent.left;
                    current = current.next;
                }
                
                if(parent.right != null) {
                    current.next = parent.right;
                    current = current.next;
                }

                parent = parent.next;
            }
            parent = layerIndicator.next;
        }
        
        return root;
    }
    
    public Node Connect2Loops(Node root) {
        if(root == null) {
            return null;
        }
        
        Queue<Node> queue = new();
        queue.Enqueue(root);
        
        while(queue.Count > 0) {
            var levelCount = queue.Count;
            Node next = null;
            
            for(int i = 0; i < levelCount; i++) {
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