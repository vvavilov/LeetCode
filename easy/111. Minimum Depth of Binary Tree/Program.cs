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
//     BFS
    public int MinDepth(TreeNode root) {
        if(root == null) {
            return 0;
        }
//         BFS, increasing depth each level. if enounter list - > return depth
        var queue = new Queue<TreeNode>();
        var depth = 0;
        queue.Enqueue(root);
        
        while(queue.Count > 0) {
            
            var levelCount = queue.Count;
            depth++;
            
            for(int i = levelCount; i > 0; i--) {
                var node = queue.Dequeue();

                if(node.left is null && node.right is null) {
                    return depth;
                }

                if(node.left != null) {
                    queue.Enqueue(node.left);
                }

                if(node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
        }
        
        return 0;

    }
    
    public int MinDepthDFS(TreeNode root) {
        if(root == null) { return 0; }
        
        
        var leftDepth = MinDepth(root.left);
        var rightDepth = MinDepth(root.right);
        
        if(leftDepth == 0 || rightDepth == 0) {
            return leftDepth + 1 + rightDepth;
        }
        
        return Math.Min(leftDepth, rightDepth) + 1;
    }
}