public class Solution {
    public Node ConnectDFS(Node root) {
        if(root == null) {
            return null;
        }
        
        if (root.left != null) {
            root.left.next = root.right;
            root.right.next = root.next?.left;
            
            Connect(root.left);
            Connect(root.right);
        }
        
        return root;
    }
    
    public Node ConnectBFS(Node root) {
        if(root == null) {
            return null;
        }
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while(queue.Count > 0) {
            Node right = null;
            var currentLevelCount = queue.Count;
            for (int i = 0; i < currentLevelCount; i++) {
                var current = queue.Dequeue();
                current.next = right;
                right = current;
                if(current.left != null) {
                    queue.Enqueue(current.right);
                    queue.Enqueue(current.left);
                }
                
            }
        }
        
        return root;
    }
    
}