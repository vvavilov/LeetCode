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
        if(root == null) {
            return null;
        }

        Queue<Node> queue = new();
        queue.Enqueue(root);
        
        while(queue.Count > 0) {
            var count = queue.Count;
            Node next = null;

            while(count-- > 0) {
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

public class SolutionDfs {
    public Node Connect(Node root) {
        Connect(root, null);
        return root;
    }
    
    private void Connect(Node node, Node next) {
        if(node == null) {
            return;
        }
        
        node.next = next;
        
        Connect(node.left, node.right);
        Connect(node.right, node.next?.left);
    }
}