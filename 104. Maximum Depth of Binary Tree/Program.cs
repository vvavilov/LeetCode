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