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
    public void Flatten(TreeNode root) {
        if(root == null) {
            return;
        }

        Traverse(root);
    }
    
    private TreeNode Traverse(TreeNode node) {
        var left = node.left;
        var right = node.right;
        node.left = null;
        
        if(left != null) {
            node.right = left;
            node = Traverse(left);
        }
        
        if(right != null) {
            node.right = right;
            node = Traverse(right);
        }
        
        return node;
    }
}