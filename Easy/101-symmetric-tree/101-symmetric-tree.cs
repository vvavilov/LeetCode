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
 
 
                    1
                    
        2                       3
    4      5             6               7
  8    9  10  11     12    13         14    15

 */

public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return root == null || IsSymmetric(root.left, root.right);
    }
    
    public bool IsSymmetric(TreeNode node, TreeNode sibling) {
        if(node == null && sibling == null) {
            return true;
        }
        
        if(node == null || sibling == null) {
            return false;
        }
        
        var selfSymmetric = node.val == sibling.val;
        
        return selfSymmetric && IsSymmetric(node.left, sibling.right) && IsSymmetric(node.right, sibling.left);
    }
}