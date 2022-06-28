/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root==null) { return 0; }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        var depth = 0;
        
        while(queue.Count > 0) {
            var count = queue.Count;
            depth++;

            while(count > 0) {
                var node = queue.Dequeue();
                if(node.left != null) {
                    queue.Enqueue(node.left);
                }
                
                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
                count--;
                
            }
        }
        
        return depth;

    }
}

public class SolutionDFS {
    public int MaxDepth(TreeNode root) {
        /*
            bfs\dfs
            walk over nodes, if null -> return zero, else 1 + Math.Max(MaxDepth(left), MaxDepth(right).
            if both left and right are 0, than return 1
        */
        
        if(root is null) {
            return 0;
        }
        
        var leftDepth = MaxDepth(root.left);
        var rightDepth = MaxDepth(root.right);
        
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}